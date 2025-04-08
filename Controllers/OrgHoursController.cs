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
    public class OrgHoursController : Controller
    {
        private readonly FoodWasteManagerContext _context;

        public OrgHoursController(FoodWasteManagerContext context)
        {
            _context = context;
        }

        // GET: OrgHours
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrgHours.ToListAsync());
        }

        // GET: OrgHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgHour = await _context.OrgHours
                .FirstOrDefaultAsync(m => m.OrgHourId == id);
            if (orgHour == null)
            {
                return NotFound();
            }

            return View(orgHour);
        }

        // GET: OrgHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrgHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrgHourId,Day,OpeningHours,ClosingHours")] OrgHour orgHour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orgHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orgHour);
        }

        // GET: OrgHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgHour = await _context.OrgHours.FindAsync(id);
            if (orgHour == null)
            {
                return NotFound();
            }
            return View(orgHour);
        }

        // POST: OrgHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrgHourId,Day,OpeningHours,ClosingHours")] OrgHour orgHour)
        {
            if (id != orgHour.OrgHourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgHour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgHourExists(orgHour.OrgHourId))
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
            return View(orgHour);
        }

        // GET: OrgHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgHour = await _context.OrgHours
                .FirstOrDefaultAsync(m => m.OrgHourId == id);
            if (orgHour == null)
            {
                return NotFound();
            }

            return View(orgHour);
        }

        // POST: OrgHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgHour = await _context.OrgHours.FindAsync(id);
            if (orgHour != null)
            {
                _context.OrgHours.Remove(orgHour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgHourExists(int id)
        {
            return _context.OrgHours.Any(e => e.OrgHourId == id);
        }
    }
}
