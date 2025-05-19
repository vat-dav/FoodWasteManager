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
        public async Task<IActionResult> Index()
        {
            var foodPosts = await _context.FoodPosts
                .Include(f => f.FoodTypes)
                .ToListAsync();

            return View(foodPosts);
        }


        // GET: FoodPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPost = await _context.FoodPosts.Include(ft=> ft.FoodTypes).FirstOrDefaultAsync(m => m.FoodPostId == id); //lets me nav to the foodtype table in views

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
                var fileName = Path.GetFileName(imageFile.FileName);// gets the filename of the image uploaded
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName); // creates the name of filepath AND saves the to the wwwroot folder

                var img = Image.FromFile(filePath);
                var scaleImage = ImageResize.Scale(img, 100, 100);
                scaleImage.SaveAs("wwwroot/images" + fileName);



                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

               foodPost.FoodImage = "/images/" + fileName;

                
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

        // POST: FoodPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodPost = await _context.FoodPosts.FindAsync(id);
            if (foodPost != null)
            {
                _context.FoodPosts.Remove(foodPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodPostExists(int id)
        {
            return _context.FoodPosts.Any(e => e.FoodPostId == id);
        }
    }
}
