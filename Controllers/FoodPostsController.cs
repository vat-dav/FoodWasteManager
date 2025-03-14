using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodWasteManager.Data;
using FoodWasteManager.Models;

namespace FoodWasteManager.Controllers
{
    public class FoodPostsController : Controller
    {
        private readonly FoodWasteManagerContext _context;

        public FoodPostsController(FoodWasteManagerContext context)
        {
            _context = context;
        }

        // GET: FoodPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodPost.ToListAsync());
        }

        // GET: FoodPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPost = await _context.FoodPost
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
        public async Task<IActionResult> Create([Bind("FoodPostId,RestauarantId,FoodName,FoodImage,FoodBestBefore,DatePosted")] FoodPost foodPost)
        {
            if (ModelState.IsValid)
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

            var foodPost = await _context.FoodPost.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("FoodPostId,RestauarantId,FoodName,FoodImage,FoodBestBefore,DatePosted")] FoodPost foodPost)
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

            var foodPost = await _context.FoodPost
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
            var foodPost = await _context.FoodPost.FindAsync(id);
            if (foodPost != null)
            {
                _context.FoodPost.Remove(foodPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodPostExists(int id)
        {
            return _context.FoodPost.Any(e => e.FoodPostId == id);
        }
    }
}
