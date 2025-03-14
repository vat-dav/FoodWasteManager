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
    public class RestaurantHoursController : Controller
    {
        private readonly FoodWasteManagerContext _context;

        public RestaurantHoursController(FoodWasteManagerContext context)
        {
            _context = context;
        }

        // GET: RestaurantHours
        public async Task<IActionResult> Index()
        {
            return View(await _context.RestaurantHour.ToListAsync());
        }

        // GET: RestaurantHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantHour = await _context.RestaurantHour
                .FirstOrDefaultAsync(m => m.RestaurantHourId == id);
            if (restaurantHour == null)
            {
                return NotFound();
            }

            return View(restaurantHour);
        }

        // GET: RestaurantHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestaurantHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestaurantHourId,RestaurantId,Day,OpeningHours,ClosingHours")] RestaurantHour restaurantHour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurantHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantHour);
        }

        // GET: RestaurantHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantHour = await _context.RestaurantHour.FindAsync(id);
            if (restaurantHour == null)
            {
                return NotFound();
            }
            return View(restaurantHour);
        }

        // POST: RestaurantHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestaurantHourId,RestaurantId,Day,OpeningHours,ClosingHours")] RestaurantHour restaurantHour)
        {
            if (id != restaurantHour.RestaurantHourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantHour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantHourExists(restaurantHour.RestaurantHourId))
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
            return View(restaurantHour);
        }

        // GET: RestaurantHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantHour = await _context.RestaurantHour
                .FirstOrDefaultAsync(m => m.RestaurantHourId == id);
            if (restaurantHour == null)
            {
                return NotFound();
            }

            return View(restaurantHour);
        }

        // POST: RestaurantHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantHour = await _context.RestaurantHour.FindAsync(id);
            if (restaurantHour != null)
            {
                _context.RestaurantHour.Remove(restaurantHour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantHourExists(int id)
        {
            return _context.RestaurantHour.Any(e => e.RestaurantHourId == id);
        }
    }
}
