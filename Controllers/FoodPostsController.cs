using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodWasteManager.Data;
using FoodWasteManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FoodWasteManager.Areas.Identity.Data;
using LazZiya.ImageResize;
using System.Drawing;
using System.Security.Claims;
using Stripe;
using Stripe.Checkout;
using Microsoft.Extensions.Options;

namespace FoodWasteManager.Controllers
{
    public class FoodPostsController : Controller
    {
        //references the DbContext to access the database
        private readonly FoodWasteManagerContext _context;

        //injects ASP's usermanager to access user operations (like current logged-in users info)
        private readonly UserManager<FoodWasteManagerUser> _userManager;

        //injects Stripe payment settings for processing transactions
        private readonly StripeSettings _stripeSettings;

        public FoodPostsController(IOptions<StripeSettings> stripeSettings, FoodWasteManagerContext context, UserManager<FoodWasteManagerUser> userManager)
        {
         
            _context = context;
            _userManager = userManager;
            _stripeSettings = stripeSettings.Value;
        }


        [Authorize]// ensures user is logged in before starting a payment session

        public async Task<IActionResult> Payment(int ApplicationId)

        {

 //configure Stripe with secret API key
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

            //load an application along with linked user and foodpost details, based on ApplicationId
            var application = _context.Applications.Where(a => a.ApplicationId == ApplicationId).Include(a => a.Users).Include(a => a.FoodPost).FirstOrDefault();

            //create a Stripe session with line items and success/cancel URLs
            var Options = new SessionCreateOptions

            {
                LineItems = new List<SessionLineItemOptions>(),
                CustomerEmail = User.Identity.Name,
                SuccessUrl = Url.Action("PaymentSuccess", "Applications", new { applicationId = ApplicationId }, Request.Scheme),              
                CancelUrl = Url.Action("Index", "Applications", new { viewType = "applicationsmade" }, Request.Scheme),


                Mode = "payment",
                ClientReferenceId = User.FindFirstValue(ClaimTypes.NameIdentifier)

            };

            //create a line item for the foodpost being purchased
            var foodPostApplication = new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)((application.FoodPost.FoodPrice / application.FoodPost.FoodQuantity) * 100),
                    Currency = "nzd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Description = "Payment for: " + application.FoodPost.FoodName,
                        Name = application.FoodPost.FoodName
                    }
                },
                Quantity = application.QuantityRequired,
            };
            Options.LineItems.Add(foodPostApplication);

            //send Stripe session to user for payment
            var service = new SessionService();
            var session = service.Create(Options);
            return Redirect(session.Url);

}


        // GET: FoodPosts

        [Authorize] // user must be logged in to view foodposts
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            //sorting parameters for UI controls in the index
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";
            ViewData["DatePostedSortParm"] = sortOrder == "dateposted" ? "dateposted_desc" : "dateposted";


            //reset page to first page if user searches something
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //load all foodposts including their linked foodtypes
            var foodPosts = from f in _context.FoodPosts.Include(f => f.FoodTypes)
                            select f;

         
            // filtering by search (FoodName or FoodType)
            if (!string.IsNullOrEmpty(searchString))
            {
                foodPosts = foodPosts.Where(f => f.FoodName.Contains(searchString) || f.FoodTypes.FoodTypeName.Contains(searchString));

            }

            // sorting based on UI tabs - FoodName and BestBefore
            switch (sortOrder)
            {
                case "name_desc":
                    foodPosts = foodPosts.OrderByDescending(f => f.FoodName);
                    break;
                case "date":
                    foodPosts = foodPosts.OrderBy(f => f.FoodBestBefore);
                    break;
                case "date_desc":
                    foodPosts = foodPosts.OrderByDescending(f => f.FoodBestBefore);
                    break;
                case "price":
                    foodPosts = foodPosts.OrderBy(f => f.FoodPrice);
                    break;
                case "price_desc":
                    foodPosts = foodPosts.OrderByDescending(f => f.FoodPrice);
                    break;
                case "dateposted":
                    foodPosts = foodPosts.OrderBy(f => f.DatePosted);
                    break;
                case "dateposted_desc":
                    foodPosts = foodPosts.OrderByDescending(f => f.DatePosted);
                    break;
                default:
                    foodPosts = foodPosts.OrderBy(f => f.FoodName);
                    break;
            }

            //pagination logic which allows for 20 posts per page, makes variables for use in the index views.
            int pageSize = 20;
            int currentPage = pageNumber ?? 1;
            int totalItems = await foodPosts.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var pagedFoodPosts = await foodPosts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

           
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;

            //return the paginated/sorted/filtered foodposts to the view.
            return View(pagedFoodPosts);
        }

        [Authorize]

        public async Task<IActionResult> MyFoodPosts()
        {
            var currentUserId = _userManager.GetUserId(User);

            var myFoodPosts = await _context.FoodPosts.Include(f => f.FoodTypes)
        .Where(f => f.UserId == currentUserId)
        .OrderByDescending(f => f.DatePosted)
        .ToListAsync();

            return View(myFoodPosts);
        }



        // GET: FoodPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//lets navigation to the foodtype table in views
            var foodPost = await _context.FoodPosts.Include(f => f.FoodTypes).FirstOrDefaultAsync(m => m.FoodPostId == id);
            

            if (foodPost == null)
            {
                return NotFound();
            }

            return View(foodPost);
        }

        // GET: FoodPosts/Create
        public IActionResult Create()
        {
            //populate dropdown list for food types
            ViewBag.FoodTypeId = new SelectList(_context.FoodTypes, "FoodTypeId", "FoodTypeName");


            return View();
        }

        // POST: FoodPosts/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodPostId,FoodTypeId,FoodImage,FoodName,FoodQuantity,FoodPrice,FoodBestBefore,DatePosted,ImageFile")] FoodPost foodPost, IFormFile imageFile)

        {
            //if imagefile has been uploaded and is not null, the image is resized before saved.
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(stream);
                    stream.Position = 0;

                    var img = Image.FromStream(stream);
                    var scaleImage = ImageResize.Crop(img, 500, 500);
                    scaleImage.Save(filePath); // Save resized image

                    foodPost.FoodImage = "/images/" + fileName;
                }
            }



            if (!ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User); // get the currently logged-in user
                foodPost.UserId = user.Id; // sets the foreign key manually

                foodPost.DatePosted = DateTime.Now; //takes in the users date and time when they post it

                //add the foodpost to the dbcontect
                _context.Add(foodPost);
                await _context.SaveChangesAsync();

                //assign the user to the Seller role and return the user to the index view
                await _userManager.AddToRoleAsync(user, "Seller");
                return RedirectToAction(nameof(Index));
            }

            //returns view with data from the resized image
            return View(foodPost);
        }

        // GET: FoodPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            //find foodpods depending on the id
            var foodPost = await _context.FoodPosts.FindAsync(id);
            if (foodPost == null)
            {
                return NotFound();
            }

            //populate dropdown with foodtypes
            ViewBag.FoodTypeId = new SelectList(_context.FoodTypes, "FoodTypeId", "FoodTypeName", foodPost.FoodTypeId);
            return View(foodPost);

        }
        // POST: FoodPosts/Edit/5
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodPostId,FoodTypeId,FoodImage,FoodName,FoodQuantity,FoodPrice,FoodBestBefore,DatePosted")] FoodPost foodPost, IFormFile imageFile)
        {
            if (id != foodPost.FoodPostId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User); // get the currently logged-in user
                foodPost.UserId = user.Id; // sets the foreign key manually

                //checks if post is in the dbcontext
                var existingPost = await _context.FoodPosts.AsNoTracking().FirstOrDefaultAsync(f => f.FoodPostId == id);
                if (existingPost == null)
                {
                    return NotFound();
                }


                //if a new image is uploaded, replace the old one
                if (imageFile != null && imageFile.Length > 0)
                {
                    // this deletes the original image
                    if (!string.IsNullOrEmpty(existingPost.FoodImage))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingPost.FoodImage.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // below saves the new image
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var fileName = Path.GetFileName(imageFile.FileName);
                    var newFilePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(newFilePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    foodPost.FoodImage = "/images/" + fileName;
                }
                else
                {
                    // no new file, so keep the existing image
                    foodPost.FoodImage = existingPost.FoodImage;
                }

                //update and save changes to the database
                _context.Update(foodPost);
                await _context.SaveChangesAsync();

                //return to the index of foodposts
                return RedirectToAction(nameof(Index));
            }

            //return to the view, passing the foodposts parameter
            return View(foodPost);
        }



        // GET: FoodPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            {
                if (id == null)
                {
                    return NotFound();
                }

                //load variable with the foodtype details
                var foodPost = await _context.FoodPosts
                        .Include(f => f.FoodTypes)
                        .FirstOrDefaultAsync(m => m.FoodPostId == id);

                if (foodPost == null)
                {
                    return NotFound();
                }

                //sends user to the deleteconfirmed view
                return View(foodPost);
            }
        }


        // POST: FoodPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)

        {

            //find the foodpost by the ID given
            var foodPost = _context.FoodPosts.Where(a => a.FoodPostId == id).FirstOrDefault();

            if (foodPost == null)
            {
                return NotFound();
            }

            //checks if any foodpost has applications connected to them
            bool hasApps = await _context.Applications.AnyAsync(a => a.FoodPostId == id);

            // if foodpost has applications, send them to details view and show the message
            if (hasApps)
            {

                TempData["Message"] = "This food post has applications and cannot be deleted.";

                return RedirectToAction("Details", new { id = foodPost.FoodPostId });

            }

            //ensure that the user is either the owner of the post or is an admin, to allow for deleting the foodpost
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) == foodPost.UserId || User.IsInRole("Admin"))
            {


                _context.FoodPosts.Remove(foodPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  

            }
            return Unauthorized();
        }
            
        

        private bool FoodPostExists(int id)
            {
                return _context.FoodPosts.Any(e => e.FoodPostId == id);
            }
        }
    }

