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
    public class CharitiesController : Controller
    {
        private readonly FoodWasteManagerContext _context;

        public CharitiesController(FoodWasteManagerContext context)
        {
            _context = context;
        }

        // GET: Charities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Charity.ToListAsync());
        }

        // GET: Charities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity
                .FirstOrDefaultAsync(m => m.CharityId == id);
            if (charity == null)
            {
                return NotFound();
            }

            return View(charity);
        }

        // GET: Charities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Charities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharityId,CharityName,CharityPhone,CharityEmail,CharityAddress")] Charity charity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(charity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(charity);
        }

        // GET: Charities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity.FindAsync(id);
            if (charity == null)
            {
                return NotFound();
            }
            return View(charity);
        }

        // POST: Charities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharityId,CharityName,CharityPhone,CharityEmail,CharityAddress")] Charity charity)
        {
            if (id != charity.CharityId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(charity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharityExists(charity.CharityId))
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
            return View(charity);
        }

        // GET: Charities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity
                .FirstOrDefaultAsync(m => m.CharityId == id);
            if (charity == null)
            {
                return NotFound();
            }

            return View(charity);
        }

        // POST: Charities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charity = await _context.Charity.FindAsync(id);
            if (charity != null)
            {
                _context.Charity.Remove(charity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharityExists(int id)
        {
            return _context.Charity.Any(e => e.CharityId == id);
        }
    }
}
