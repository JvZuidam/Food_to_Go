using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Food_to_go.Data;
using Food_to_go.Models;

namespace Food_to_go.Controllers
{
    public class MealPackagesController : Controller
    {
        private readonly Food_to_goContext _context;

        public MealPackagesController(Food_to_goContext context)
        {
            _context = context;
        }

        // GET: MealPackages
        public async Task<IActionResult> Index()
        {
              return _context.MealPackage != null ? 
                          View(await _context.MealPackage.ToListAsync()) :
                          Problem("Entity set 'Food_to_goContext.MealPackage'  is null.");
        }

        // GET: MealPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MealPackage == null)
            {
                return NotFound();
            }

            var mealPackage = await _context.MealPackage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealPackage == null)
            {
                return NotFound();
            }

            return View(mealPackage);
        }

        // GET: MealPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ReservedFrom,ReservedTill,AdultPackage,Price,MealType")] MealPackage mealPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealPackage);
        }

        // GET: MealPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MealPackage == null)
            {
                return NotFound();
            }

            var mealPackage = await _context.MealPackage.FindAsync(id);
            if (mealPackage == null)
            {
                return NotFound();
            }
            return View(mealPackage);
        }

        // POST: MealPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,ReservedFrom,ReservedTill,AdultPackage,Price,MealType")] MealPackage mealPackage)
        {
            if (id != mealPackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealPackageExists(mealPackage.Id))
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
            return View(mealPackage);
        }

        // GET: MealPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MealPackage == null)
            {
                return NotFound();
            }

            var mealPackage = await _context.MealPackage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealPackage == null)
            {
                return NotFound();
            }

            return View(mealPackage);
        }

        // POST: MealPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MealPackage == null)
            {
                return Problem("Entity set 'Food_to_goContext.MealPackage'  is null.");
            }
            var mealPackage = await _context.MealPackage.FindAsync(id);
            if (mealPackage != null)
            {
                _context.MealPackage.Remove(mealPackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealPackageExists(int id)
        {
          return (_context.MealPackage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
