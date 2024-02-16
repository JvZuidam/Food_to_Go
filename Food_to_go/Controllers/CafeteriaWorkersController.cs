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
    public class CafeteriaWorkersController : Controller
    {
        private readonly Food_to_goContext _context;

        public CafeteriaWorkersController(Food_to_goContext context)
        {
            _context = context;
        }

        // GET: CafeteriaWorkers
        public async Task<IActionResult> Index()
        {
              return _context.CafeteriaWorker != null ? 
                          View(await _context.CafeteriaWorker.ToListAsync()) :
                          Problem("Entity set 'Food_to_goContext.CafeteriaWorker'  is null.");
        }

        // GET: CafeteriaWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CafeteriaWorker == null)
            {
                return NotFound();
            }

            var cafeteriaWorker = await _context.CafeteriaWorker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafeteriaWorker == null)
            {
                return NotFound();
            }

            return View(cafeteriaWorker);
        }

        // GET: CafeteriaWorkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CafeteriaWorkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EmployeeNumber")] CafeteriaWorker cafeteriaWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafeteriaWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cafeteriaWorker);
        }

        // GET: CafeteriaWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CafeteriaWorker == null)
            {
                return NotFound();
            }

            var cafeteriaWorker = await _context.CafeteriaWorker.FindAsync(id);
            if (cafeteriaWorker == null)
            {
                return NotFound();
            }
            return View(cafeteriaWorker);
        }

        // POST: CafeteriaWorkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EmployeeNumber")] CafeteriaWorker cafeteriaWorker)
        {
            if (id != cafeteriaWorker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafeteriaWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeteriaWorkerExists(cafeteriaWorker.Id))
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
            return View(cafeteriaWorker);
        }

        // GET: CafeteriaWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CafeteriaWorker == null)
            {
                return NotFound();
            }

            var cafeteriaWorker = await _context.CafeteriaWorker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafeteriaWorker == null)
            {
                return NotFound();
            }

            return View(cafeteriaWorker);
        }

        // POST: CafeteriaWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CafeteriaWorker == null)
            {
                return Problem("Entity set 'Food_to_goContext.CafeteriaWorker'  is null.");
            }
            var cafeteriaWorker = await _context.CafeteriaWorker.FindAsync(id);
            if (cafeteriaWorker != null)
            {
                _context.CafeteriaWorker.Remove(cafeteriaWorker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeteriaWorkerExists(int id)
        {
          return (_context.CafeteriaWorker?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
