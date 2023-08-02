using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Produktiviteti.Data;
using Produktiviteti.Models;

namespace Produktiviteti.Controllers
{
    public class PergjigjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PergjigjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pergjigjas
        public async Task<IActionResult> Index()
        {
              return _context.Pergjigja != null ? 
                          View(await _context.Pergjigja.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pergjigja'  is null.");
        }

        // GET: Pergjigjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pergjigja == null)
            {
                return NotFound();
            }

            var pergjigja = await _context.Pergjigja
                .FirstOrDefaultAsync(m => m.PergjigjaId == id);
            if (pergjigja == null)
            {
                return NotFound();
            }

            return View(pergjigja);
        }

        // GET: Pergjigjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pergjigjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PergjigjaId,Emri_Pergjigja")] Pergjigja pergjigja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pergjigja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pergjigja);
        }

        // GET: Pergjigjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pergjigja == null)
            {
                return NotFound();
            }

            var pergjigja = await _context.Pergjigja.FindAsync(id);
            if (pergjigja == null)
            {
                return NotFound();
            }
            return View(pergjigja);
        }

        // POST: Pergjigjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PergjigjaId,Emri_Pergjigja")] Pergjigja pergjigja)
        {
            if (id != pergjigja.PergjigjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pergjigja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PergjigjaExists(pergjigja.PergjigjaId))
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
            return View(pergjigja);
        }

        // GET: Pergjigjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pergjigja == null)
            {
                return NotFound();
            }

            var pergjigja = await _context.Pergjigja
                .FirstOrDefaultAsync(m => m.PergjigjaId == id);
            if (pergjigja == null)
            {
                return NotFound();
            }

            return View(pergjigja);
        }

        // POST: Pergjigjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pergjigja == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pergjigja'  is null.");
            }
            var pergjigja = await _context.Pergjigja.FindAsync(id);
            if (pergjigja != null)
            {
                _context.Pergjigja.Remove(pergjigja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PergjigjaExists(int id)
        {
          return (_context.Pergjigja?.Any(e => e.PergjigjaId == id)).GetValueOrDefault();
        }
    }
}
