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
    public class CafeteriasController : Controller
    {
        private readonly Food_to_goContext _context;

        public CafeteriasController(Food_to_goContext context)
        {
            _context = context;
        }

        // GET: Cafeterias
        public async Task<IActionResult> Index()
        {
              return _context.Cafeteria != null ? 
                          View(await _context.Cafeteria.ToListAsync()) :
                          Problem("Entity set 'Food_to_goContext.Cafeteria'  is null.");
        }

        // GET: Cafeterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cafeteria == null)
            {
                return NotFound();
            }

            var cafeteria = await _context.Cafeteria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafeteria == null)
            {
                return NotFound();
            }

            return View(cafeteria);
        }

        // GET: Cafeterias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cafeterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City,Location,HotMeal")] Cafeteria cafeteria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafeteria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cafeteria);
        }

        // GET: Cafeterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cafeteria == null)
            {
                return NotFound();
            }

            var cafeteria = await _context.Cafeteria.FindAsync(id);
            if (cafeteria == null)
            {
                return NotFound();
            }
            return View(cafeteria);
        }

        // POST: Cafeterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,Location,HotMeal")] Cafeteria cafeteria)
        {
            if (id != cafeteria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafeteria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeteriaExists(cafeteria.Id))
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
            return View(cafeteria);
        }

        // GET: Cafeterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cafeteria == null)
            {
                return NotFound();
            }

            var cafeteria = await _context.Cafeteria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafeteria == null)
            {
                return NotFound();
            }

            return View(cafeteria);
        }

        // POST: Cafeterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cafeteria == null)
            {
                return Problem("Entity set 'Food_to_goContext.Cafeteria'  is null.");
            }
            var cafeteria = await _context.Cafeteria.FindAsync(id);
            if (cafeteria != null)
            {
                _context.Cafeteria.Remove(cafeteria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeteriaExists(int id)
        {
          return (_context.Cafeteria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
