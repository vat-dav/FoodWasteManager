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
using Microsoft.Extensions.Hosting;
using TuitionDbv1.Helpers;

namespace FoodWasteManager.Controllers
{
    public class FoodPostsController : Controller
    {
        private readonly FoodWasteManagerContext _context;
        private readonly UserManager<FoodWasteManagerUser> _userManager;
        public FoodPostsController(FoodWasteManagerContext context, UserManager<FoodWasteManagerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]

        // GET: FoodPosts
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";
            ViewData["DatePostedSortParm"] = sortOrder == "dateposted" ? "dateposted_desc" : "dateposted";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var foodPosts = from f in _context.FoodPosts.Include(f => f.FoodTypes)
                            select f;

            // filtering
            if (!string.IsNullOrEmpty(searchString))
            {
                foodPosts = foodPosts.Where(f => f.FoodName.Contains(searchString));
            }

            // sorting
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

            // additional sort by DatePosted desc after other sorting (optional — or remove if redundant)
            // foodPosts = foodPosts.OrderByDescending(f => f.DatePosted);

            // pagination
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

            return View(pagedFoodPosts);
        }


        // GET: FoodPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPost = await _context.FoodPosts.Include(ft => ft.FoodTypes).FirstOrDefaultAsync(m => m.FoodPostId == id); //lets me nav to the foodtype table in views

            if (foodPost == null)
            {
                return NotFound();
            }

            return View(foodPost);
        }

        // GET: FoodPosts/Create
        public IActionResult Create()
        {

            ViewBag.FoodTypeId = new SelectList(_context.FoodTypes, "FoodTypeId", "FoodTypeName");


            return View();
        }

        // POST: FoodPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodPostId,FoodTypeId,FoodImage,FoodName,FoodQuantity,FoodPrice,FoodBestBefore,DatePosted,ImageFile")] FoodPost foodPost, IFormFile imageFile)

        {
            //if imagefile has been uploaded and is not null, the following runs
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

                _context.Add(foodPost);
                await _context.SaveChangesAsync();

                await _userManager.AddToRoleAsync(user, "Seller");
                return RedirectToAction(nameof(Index));
            }

            return View(foodPost);
        }

        // GET: FoodPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var foodPost = await _context.FoodPosts.FindAsync(id);
            if (foodPost == null)
            {
                return NotFound();
            }

            ViewBag.FoodTypeId = new SelectList(_context.FoodTypes, "FoodTypeId", "FoodTypeName", foodPost.FoodTypeId);
            return View(foodPost);

        }
        // POST: FoodPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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


                var existingPost = await _context.FoodPosts.AsNoTracking().FirstOrDefaultAsync(f => f.FoodPostId == id);
                if (existingPost == null)
                {
                    return NotFound();
                }

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

                    // This saves the new image
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
                    // No new file — retain existing image
                    foodPost.FoodImage = existingPost.FoodImage;
                }

                _context.Update(foodPost);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

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
                var foodPost = await _context.FoodPosts
                        .Include(f => f.FoodTypes)
                        .FirstOrDefaultAsync(m => m.FoodPostId == id);

                if (foodPost == null)
                {
                    return NotFound();
                }

                return View(foodPost);
            }
        }


        // POST: FoodPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)

        {


            var foodPost = _context.FoodPosts.Where(a => a.FoodPostId == id).FirstOrDefault();

            if (foodPost == null)
            {
                return NotFound();
            }

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

