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

namespace FoodWasteManager.Controllers
{
    public class FoodPostsController : Controller
    {
        private readonly FoodWasteManagerContext _context;

        public FoodPostsController(FoodWasteManagerContext context)
        {
            _context = context;
        }
        [Authorize]


        // GET: FoodPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodPosts.ToListAsync());
        }

        // GET: FoodPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPost = await _context.FoodPosts
                .FirstOrDefaultAsync(m => m.FoodPostId == id);
            if (foodPost == null)
            {
                return NotFound();
            }

            return View(foodPost);
        }

        // GET: FoodPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodPostId,FoodImage,FoodName,FoodQuantity,FoodPrice,FoodBestBefore,DatePosted,ImageFile")] FoodPost foodPost, IFormFile imageFile)

        {
            //if imagefile has been uploaded and is not null, the following runs
            if (imageFile != null && imageFile.Length > 0)
            {

                var fileName = Path.GetFileName(imageFile.FileName);// gets the filename of the image uploaded
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName); // creates the name of filepath AND saves the to the wwwroot folder
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                foodPost.FoodImage = "/images/" + fileName;
            }

            foodPost.DatePosted = DateTime.Now; //takes in the users date and time when they post it


            if (!ModelState.IsValid)
            {
                _context.Add(foodPost);
                await _context.SaveChangesAsync();
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
            return View(foodPost);
        }

        // POST: FoodPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodPostId,FoodImage,FoodName,FoodQuantity,FoodPrice,FoodBestBefore,DatePosted")] FoodPost foodPost)
        {
            if (id != foodPost.FoodPostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodPostExists(foodPost.FoodPostId))
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
