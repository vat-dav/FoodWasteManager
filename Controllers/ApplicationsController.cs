using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodWasteManager.Data;
using FoodWasteManager.Models;
using Microsoft.AspNetCore.Identity;
using FoodWasteManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Identity.Client;
using Stripe;
using Stripe.Checkout;



namespace FoodWasteManager.Controllers
{
    public class ApplicationsController : Controller

    {

        //references the DbContext to access the database
        private readonly FoodWasteManagerContext _context;

        //injects the ApplicationUser and ASP's usermanager to access user operations 
        private readonly UserManager<FoodWasteManagerUser> _userManager;

        //injects the ApplicationUser and ASP's signinmanager to access login operations 
        private readonly SignInManager<FoodWasteManagerUser> _signInManager; //injected signinmanager
        

        public ApplicationsController(FoodWasteManagerContext context, UserManager<FoodWasteManagerUser> userManager, SignInManager<FoodWasteManagerUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [Authorize] // ensures user is logged in
        public async Task<IActionResult> Approved(int applicationId)
        {
            //Load applications and include the linked foodposts depending on the applicationId
            var application = await _context.Applications
                .Include(a => a.FoodPost)
                .FirstOrDefaultAsync(a => a.ApplicationId == applicationId);

            if (application == null)
            {
                return NotFound();
            }

            // Set AStatus to approved once seller approves
            application.AStatus = Models.Application.ApplicationStatus.Approved;
            await _context.SaveChangesAsync();

            // Redirects user to applications made viewtype of applications controller 
            return RedirectToAction("Index", new { viewType = "applicationsmade" });
        }

        [Authorize] // ensures user is logged in
        public async Task<IActionResult> PaymentSuccess(int applicationId)
        {
            // Load application and include foodposts depending on the applicationId
            var application = await _context.Applications.Include(a => a.FoodPost).FirstOrDefaultAsync(a => a.ApplicationId == applicationId);

            
           //Set HasPaid field to true, marking payment as complete, variable used for UI manipulation
                application.HasPaid = true;

                // Subtrats the purchased food quantity from the quantity available, which prevents a negative food quantity.
                application.FoodPost.FoodQuantity = Math.Max(0, application.FoodPost.FoodQuantity - application.QuantityRequired);

            //Save updated data to the Dbcontext
                await _context.SaveChangesAsync();
           
            //redirect user to the applicationsmade view
            return RedirectToAction("Index", new { viewType = "applicationsmade" });
        }


        // GET: Applications
        [Authorize] // ensures user is logged in 
        public async Task<IActionResult> Index(string? viewType, string? searchString, string? sortOrder, int? pageNumber)
        {
            //Gets the currently logged in users userid
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            // Start a query with applications to display in the views- including both the buyer and the sellers information
            IQueryable<Models.Application> applications = _context.Applications
     .Include(a => a.Users) // applicant (buyer)
     .Include(a => a.FoodPost).ThenInclude(fp => fp.Users); // food post owner (seller)


            //Admin is able to see all applications (regardless of what AStatus is)
            if (User.IsInRole("Admin"))
            {
                applications = applications.Where(a =>
                    a.AStatus == Models.Application.ApplicationStatus.Processing ||
                    a.AStatus == Models.Application.ApplicationStatus.Approved ||
                    a.AStatus == Models.Application.ApplicationStatus.Declined);

                ViewData["Title"] = "All Applications";
            }
            else
            {
                //If viewing applications made (user is a buyer) they will see all of their applications made-regardless of AStatus.
                if (viewType == "applicationsmade")
                {


                    applications = applications.Where(a =>
                        a.UserId == userId &&
                        (a.AStatus == Models.Application.ApplicationStatus.Processing ||
                         a.AStatus == Models.Application.ApplicationStatus.Approved ||
                         a.AStatus == Models.Application.ApplicationStatus.Declined));

                    ViewData["Title"] = "Applications Made";
                }

                //If viewing applications received (user is a seller) they will see all applications received on their posting foodpost listings- regardless of AStatus.
                else if (viewType == "applicationsreceived")
                {


                    applications = applications.Where(a =>
                        a.FoodPost != null &&
                        a.FoodPost.UserId == userId &&
                        (a.AStatus == Models.Application.ApplicationStatus.Processing ||
                         a.AStatus == Models.Application.ApplicationStatus.Approved ||
                         a.AStatus == Models.Application.ApplicationStatus.Declined));

                    ViewData["Title"] = "Applications Received";
                }
                else
                {
                    return BadRequest("Invalid view type.");
                }
            }



            // --- SEARCH ---
            if (searchString != null)
            {
                //reset page to 1 if user searches something
                pageNumber = 1;
            }
            else
            {
                searchString = ViewData["CurrentFilter"] as string;
            }

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            //Sorting options for UI-namely the AStatus and by FoodName.
            ViewData["StatusSortParm"] = sortOrder == "status" ? "status_desc" : "status";
               ViewData["FoodNameSortParm"] = sortOrder == "foodname" ? "foodname_desc" : "foodname";
            
            //Filter by what the user searched 
            if (!string.IsNullOrEmpty(searchString))
            {
                applications = applications.Where(a =>
                    a.FoodPost.FoodName.Contains(searchString) ||
                    "Approved".Contains(searchString) ||
                    "Processing".Contains(searchString) ||
                    "Declined".Contains(searchString));
            }

            //Sorting logic, orders depending on the AStatus and filters by descending when clicked the other tab - for AStatus and FoodName.
            applications = sortOrder switch
            {
                "status" => applications.OrderBy(a => a.AStatus),
                "status_desc" => applications.OrderByDescending(a => a.AStatus),
                "foodname" => applications.OrderBy(a => a.FoodPost.FoodName),
                "foodname_desc" => applications.OrderByDescending(a => a.FoodPost.FoodName),
                _ => applications.OrderBy(a => a.FoodPost.FoodName)
            };

            //12 foodposts on each 'page'
            int pageSize = 12;
            int currentPage = pageNumber ?? 1;
            int totalItems = await applications.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var pagedApplications = await applications
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;

            //returns the view with the updated manipulations the user did.
            return View(pagedApplications);
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Get application with the foodpost, based on the applicationId field
            var application = await _context.Applications
                .Include(a => a.FoodPost)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create(int FoodPostId)
        {
            //Create a viewbag for the Foodpost name to use in the view
            ViewData["FoodPostId"] = new SelectList(_context.FoodPosts, "FoodPostId", "FoodName");


            //returns view
            return View();
        }

        // POST: Applications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,FoodPostId,QuantityRequired,EarliestPickup,LatestPickup,AStatus,HasPaid")] Models.Application application)
        {

            // gets logged-in user's ID
            var currentUserId = _userManager.GetUserId(User);

            //sets applications userId field to the currentuserId field collected earlier
            application.UserId = currentUserId;

            //sets haspaid variable to false, for manipulation in the views
            application.HasPaid = false;

            //ensures that the user doesn't apply for their own foodpost, throws an error
            var foodPostId = await _context.FoodPosts.Include(f => f.Users).FirstOrDefaultAsync(f => f.FoodPostId == application.FoodPostId);
            if (application.UserId == foodPostId.UserId)
            {
                ModelState.AddModelError("", "You cannot apply for your own food post.");
            }

             //ensures that the food quantity required stated in the application does not exceed the available amount for the specific foodpost.
            var foodQuantityExceeded = await _context.FoodPosts.FirstOrDefaultAsync(fp => fp.FoodPostId == application.FoodPostId);
            if (application.QuantityRequired > foodQuantityExceeded.FoodQuantity)
            {
                ModelState.AddModelError("QuantityRequired", $"Only {foodQuantityExceeded.FoodQuantity} items available.");
                ViewData["FoodPostId"] = new SelectList(_context.FoodPosts, "FoodPostId", "FoodName", application.FoodPostId);
                return View(application);
            }

           

            var today = DateTime.Today; // Declares today to be current date set as DateTime variable
            var maxEarliestDate = today.AddMonths(1); // Declares variable to be 1 month from current date
            var maxLatestDate = application.EarliestPickup.AddDays(7); // Latest Pickup can be up to 7 days after EarliestPickup

            // Check if EarliestPickup is valid based on validation
            if (application.EarliestPickup.Date < today || application.EarliestPickup.Date > maxEarliestDate)
            {
                ModelState.AddModelError("EarliestPickup", "Earliest Pickup must be today or within the next month.");
            }

            // Check if LatestPickup is valid based on the validation set
            if (application.LatestPickup < application.EarliestPickup || application.LatestPickup > maxLatestDate)
            {
                ModelState.AddModelError("LatestPickup", "Latest Pickup must be within 7 days of the Earliest Pickup.");
            }


            if (!ModelState.IsValid)
            {
                application.AStatus = Models.Application.ApplicationStatus.Processing; // default sets the application status to processing, as waiting for the other user to approve/decline the application.

                var user = await _userManager.GetUserAsync(User); // get the currently logged-in user - this variable works for FK and adding role to user
                application.UserId = user.Id; // sets the foreign key manually

                //adds the application to the context and saves changes
                _context.Add(application);
                await _context.SaveChangesAsync();

                //adds the user to the role, Buyer, and uses sign in manager to refresh and ensure the user can see the navbar headings intended based on their role.
                await _userManager.AddToRoleAsync(user, "Buyer");
                await _signInManager.RefreshSignInAsync(user);
                
                //redirects user to the applicationsmade view of applications controller
                return RedirectToAction(nameof(Index), new { viewType = "applicationsmade" });

            }



            //creates viewbag for foodpostname for manipulation in views
            ViewData["FoodPostId"] = new SelectList(_context.FoodPosts, "FoodPostId", "FoodName", application.FoodPostId);

            //returns to the applications view
            return View(application);
        }
        public async Task<IActionResult> Approve(int id)
        {
            //get application with foodpost to check who the owner is
            var application = await _context.Applications
                .Include(a => a.FoodPost) 
                .FirstOrDefaultAsync(a => a.ApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            //checks if current user is the foodpost owner
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (application.FoodPost.UserId != currentUserId)
            {
                return Forbid(); // user is not authorized to approve this application
            }

            //approves application and saves changes to the dbcontext
            application.AStatus = Models.Application.ApplicationStatus.Approved;
            await _context.SaveChangesAsync();

            //returns to applicationsreceived viewtype
            return RedirectToAction(nameof(Index), new { viewType = "applicationsreceived" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(int id)
        {
            //get application with foodpost to check who the owner is
            var application = await _context.Applications
                .Include(a => a.FoodPost) 
                .FirstOrDefaultAsync(a => a.ApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            //ensures that user is auhtorised to decline the application
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (application.FoodPost.UserId != currentUserId)
            {
                return Forbid();
            }

            //sets application status to declined and saves changes to the db context.
            application.AStatus = Models.Application.ApplicationStatus.Declined;
            await _context.SaveChangesAsync();

            //returns user to the applicationsreceived view
            return RedirectToAction(nameof(Index), new { viewType = "applicationsreceived" });
        }
        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            // Populate dropdown for food posts
            ViewData["FoodPostId"] = new SelectList(_context.FoodPosts, "FoodPostId", "FoodName", application.FoodPostId);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,FoodPostId,QuantityRequired,EarliestPickup,LatestPickup,AStatus,HasPaid")] Models.Application application)
        {
            if (id != application.ApplicationId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                application.AStatus = Models.Application.ApplicationStatus.Processing; // default sets the application status to processing, as waiting for the other user to approve/decline the application.
                var user = await _userManager.GetUserAsync(User); // get the currently logged-in user - this variable works for FK and adding role to user
                application.UserId = user.Id; // sets the foreign key manually

                try
                {
                    //Update application in the dbcontect and save changes to the database
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if another process causes application record to be changed/deleted while performing the edit, throw notfound error
                    if (!ApplicationExists(application.ApplicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //redirect to the index method of applications controller
                return RedirectToAction(nameof(Index));
            }

            //populate dropdown with foodname, based on foodpostid
            ViewData["FoodPostId"] = new SelectList(_context.FoodPosts, "FoodPostId", "FoodName", application.FoodPostId);
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Load the application with the related foodpost and user information
            var application = await _context.Applications
                .Include(a => a.FoodPost)
                .ThenInclude(bb => bb.Users)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            //Send user to the delete confirmation view
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //find application based on the id
            var application = await _context.Applications.FindAsync(id);

            //if the application is not null yet and if the user hasn't paid, remove it from the database, making it null
            if (application != null && application.HasPaid == false)
            {

                _context.Applications.Remove(application);
            }
            else
            {
                TempData["AlertMessage"] = "Cannot delete this application because payment has already been made.";

            }
            //save the deletion to the database
            await _context.SaveChangesAsync();

            //redirect viewer to the applicationsmade viewtype of the applications controller 
            return RedirectToAction(nameof(Index), new { viewType = "applicationsmade" });
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationId == id);
        }

    }
}   