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
    public class PozitasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PozitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pozitas
        public async Task<IActionResult> Index()
        {
              return _context.Pozitat != null ? 
                          View(await _context.Pozitat.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pozitat'  is null.");
        }

        // GET: Pozitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pozitat == null)
            {
                return NotFound();
            }

            var pozita = await _context.Pozitat
                .FirstOrDefaultAsync(m => m.PozitaId == id);
            if (pozita == null)
            {
                return NotFound();
            }

            return View(pozita);
        }

        // GET: Pozitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pozitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PozitaId,Pozita_punes")] Pozita pozita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozita);
        }

        // GET: Pozitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pozitat == null)
            {
                return NotFound();
            }

            var pozita = await _context.Pozitat.FindAsync(id);
            if (pozita == null)
            {
                return NotFound();
            }
            return View(pozita);
        }

        // POST: Pozitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PozitaId,Pozita_punes")] Pozita pozita)
        {
            if (id != pozita.PozitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozitaExists(pozita.PozitaId))
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
            return View(pozita);
        }

        // GET: Pozitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pozitat == null)
            {
                return NotFound();
            }

            var pozita = await _context.Pozitat
                .FirstOrDefaultAsync(m => m.PozitaId == id);
            if (pozita == null)
            {
                return NotFound();
            }

            return View(pozita);
        }

        // POST: Pozitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pozitat == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pozitat'  is null.");
            }
            var pozita = await _context.Pozitat.FindAsync(id);
            if (pozita != null)
            {
                _context.Pozitat.Remove(pozita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozitaExists(int id)
        {
          return (_context.Pozitat?.Any(e => e.PozitaId == id)).GetValueOrDefault();
        }
    }
}
