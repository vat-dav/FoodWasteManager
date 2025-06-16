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


namespace FoodWasteManager.Controllers
{
    public class ApplicationsController : Controller

    {
        

        private readonly FoodWasteManagerContext _context;
        private readonly UserManager<FoodWasteManagerUser> _userManager; // injected usermanager
        private readonly SignInManager<FoodWasteManagerUser> _signInManager; //injected signinmanager
        

        public ApplicationsController(FoodWasteManagerContext context, UserManager<FoodWasteManagerUser> userManager, SignInManager<FoodWasteManagerUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [Authorize]

        // GET: Applications

   
        public async Task<IActionResult> Index(string? viewType)
        {

            if (User.IsInRole("Buyer") && viewType =="applicationsmade")
            {
                var foodWasteManagerContext = await _context.Applications.Include(a => a.FoodPost).Where(a => a.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
                ViewData["Title"] = "Applications Made";

                return View(foodWasteManagerContext);

            }

            if (User.IsInRole("Admin"))
            {
                var foodWasteManagerContext = _context.Applications.Include(a => a.FoodPost).ToListAsync();

                ViewData["Title"] = "All Applications";
                return View(await foodWasteManagerContext);
            }
            if (User.IsInRole("Seller") && viewType == "applicationsreceived")
            {
                string sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Get only applications where the FoodPost belongs to the current seller
                var applications = await _context.Applications
                    .Include(a => a.FoodPost)
                    .Where(a => a.FoodPost.UserId == sellerId) // cleaner join logic
                    .ToListAsync();

                // If there are no applications, set a custom message
                if (applications.Count == 0)
                {
                    ViewData["Title"] = "No Applications Received";
                }
                else
                {
                    ViewData["Title"] = "Applications Received";  // Optional: Set a default title for when there are applications
                }

                return View(applications);
            }



            else
            {
                ViewData["Title"] = "No Applications Found";
                return RedirectToAction(nameof(Index), new { viewType = "applicationsreceived" });

            }

        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
            ViewData["FoodPostId"] = new SelectList(_context.FoodPosts, "FoodPostId", "FoodName");


           
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,FoodPostId,QuantityRequired,EarliestPickup,LatestPickup,AStatus")] Application application)
        {



            var currentUserId = _userManager.GetUserId(User); // gets logged-in user's ID
            application.UserId = currentUserId;

            var foodPostId = await _context.FoodPosts.Include(f => f.Users).FirstOrDefaultAsync(f => f.FoodPostId == application.FoodPostId);

            if (application.UserId == foodPostId.UserId)
            {
                ModelState.AddModelError("", "You cannot apply for your own food post.");
            }

            //validation above is to ensure that users can't apply for their own foodposts

            var foodQuantityExceeded = await _context.FoodPosts.FirstOrDefaultAsync(fp => fp.FoodPostId == application.FoodPostId);

            if (application.QuantityRequired > foodQuantityExceeded.FoodQuantity)
            {
                ModelState.AddModelError("QuantityRequired", "Requested quantity exceeds available quantity.");
                return RedirectToAction("Index");
            }
            //validation above ensures that the food quantity required stated in the application does not exceed the available amount for the specific foodpost.

            var today = DateTime.Today; // Declares today to be current date set as DateTime variable
            var maxEarliestDate = today.AddMonths(1); // Declares variable to be 1 month from current date
            var maxLatestDate = application.EarliestPickup.AddDays(7); // Latest Pickup can be up to 7 days after EarliestPickup

            // Check if EarliestPickup is valid
            if (application.EarliestPickup.Date < today || application.EarliestPickup.Date > maxEarliestDate)
            {
                ModelState.AddModelError("EarliestPickup", "Earliest Pickup must be today or within the next month.");
            }

            // Check if LatestPickup is valid
            if (application.LatestPickup < application.EarliestPickup || application.LatestPickup > maxLatestDate)
            {
                ModelState.AddModelError("LatestPickup", "Latest Pickup must be within 7 days of the Earliest Pickup.");
            }


            if (!ModelState.IsValid)
            {
                application.AStatus = Application.ApplicationStatus.Processing; // default sets the application status to processing, as waiting for the other user to approve/decline the application.
              
                var user = await _userManager.GetUserAsync(User); // get the currently logged-in user - this variable works for FK and adding role to user
                application.UserId = user.Id; // sets the foreign key manually

                _context.Add(application);
                await _context.SaveChangesAsync();

                await _userManager.AddToRoleAsync(user, "Buyer");
                await _signInManager.RefreshSignInAsync(user);

                return RedirectToAction(nameof(Index));
            }


            

            ViewData["FoodPostId"] = new SelectList(_context.FoodPosts, "FoodPostId", "FoodName", application.FoodPostId);
            return View(application);
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
            ViewData["FoodPostId"] = new SelectList(_context.FoodPosts, "FoodPostId", "FoodName", application.FoodPostId);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,FoodPostId,QuantityRequired,EarliestPickup,LatestPickup,AStatus")] Application application)
        {
            if (id != application.ApplicationId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                application.AStatus = Application.ApplicationStatus.Processing; // default sets the application status to processing, as waiting for the other user to approve/decline the application.
                var user = await _userManager.GetUserAsync(User); // get the currently logged-in user - this variable works for FK and adding role to user
                application.UserId = user.Id; // sets the foreign key manually

                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ApplicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
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

            var application = await _context.Applications
                .Include(a => a.FoodPost)
                .ThenInclude(bb => bb.Users)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationId == id);
        }
    }
}
