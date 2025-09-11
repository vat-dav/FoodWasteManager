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
    [Authorize(Roles = "Admin")] //ensures only the admin can access this controller.
    public class FoodTypesController : Controller

    {
        // references the DbContext to access the db
        private readonly FoodWasteManagerContext _context;

        public FoodTypesController(FoodWasteManagerContext context)
        {
            _context = context;
        }

        // GET: FoodTypes
        //retrieves all food types from the database and returns to the index view
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodTypes.ToListAsync());
        }

        // GET: FoodTypes/Details/5
        // shows the details of a single food type by its ID
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //fetches the foodtype record, using the ID to navigate to it
            var foodType = await _context.FoodTypes
                .FirstOrDefaultAsync(m => m.FoodTypeId == id);
            if (foodType == null)
            {
                return NotFound();
            }

            return View(foodType);
        }

        // GET: FoodTypes/Create
        // displays a create form to add a new foodtype 
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodTypes/Create
        // saves the new food type to the database after validating the users input
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodId,FoodTypeName")] FoodType foodType)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(foodType); // adds new foodtype
                await _context.SaveChangesAsync(); // saves changes to db
                return RedirectToAction(nameof(Index)); // returns user to the foodtypes index
            }

            // returns the view
            return View(foodType);
        }

        // GET: FoodTypes/Edit/5
        //loads selected food type into a form to allow the admin to edit 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // finds the food type record using the id
            var foodType = await _context.FoodTypes.FindAsync(id);
            if (foodType == null)
            {
                return NotFound();
            }
            return View(foodType);
        }

        // POST: FoodTypes/Edit/5
       //saves the updated food type in the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodId,FoodTypeName")] FoodType foodType)
        {
            if (id != foodType.FoodTypeId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodType); // updates the foodtype record in the database
                    await _context.SaveChangesAsync(); //saves changes to the db
                }
                catch (DbUpdateConcurrencyException) // handles the chance of the record no longer existing
                {
                    if (!FoodTypeExists(foodType.FoodTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // redirect back to the index after editing
            }
            return View(foodType);
        }

        // GET: FoodTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodType = await _context.FoodTypes
                .FirstOrDefaultAsync(m => m.FoodTypeId == id);
            if (foodType == null)
            {
                return NotFound();
            }

            return View(foodType);
        }

        // POST: FoodTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //deletes the food type record from the database once the user confirms.
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodType = await _context.FoodTypes.FindAsync(id);
            if (foodType != null)
            {
                _context.FoodTypes.Remove(foodType);// removes the record
            }

            await _context.SaveChangesAsync(); // save deletion to the database (delete from database)
            return RedirectToAction(nameof(Index));  // redirect the user to the foodtypes controller index
        }

        private bool FoodTypeExists(int id)
        {
            return _context.FoodTypes.Any(e => e.FoodTypeId == id);
        }
    }
}
