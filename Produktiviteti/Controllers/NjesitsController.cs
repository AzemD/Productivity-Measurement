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
    public class NjesitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NjesitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Njesits
        public async Task<IActionResult> Index()
        {
              return _context.Njesit != null ? 
                          View(await _context.Njesit.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Njesit'  is null.");
        }

        // GET: Njesits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Njesit == null)
            {
                return NotFound();
            }

            var njesit = await _context.Njesit
                .FirstOrDefaultAsync(m => m.NjesitId == id);
            if (njesit == null)
            {
                return NotFound();
            }

            return View(njesit);
        }

        // GET: Njesits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Njesits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NjesitId,Njesit_Etc")] Njesit njesit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(njesit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(njesit);
        }

        // GET: Njesits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Njesit == null)
            {
                return NotFound();
            }

            var njesit = await _context.Njesit.FindAsync(id);
            if (njesit == null)
            {
                return NotFound();
            }
            return View(njesit);
        }

        // POST: Njesits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NjesitId,Njesit_Etc")] Njesit njesit)
        {
            if (id != njesit.NjesitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(njesit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NjesitExists(njesit.NjesitId))
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
            return View(njesit);
        }

        // GET: Njesits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Njesit == null)
            {
                return NotFound();
            }

            var njesit = await _context.Njesit
                .FirstOrDefaultAsync(m => m.NjesitId == id);
            if (njesit == null)
            {
                return NotFound();
            }

            return View(njesit);
        }

        // POST: Njesits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Njesit == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Njesit'  is null.");
            }
            var njesit = await _context.Njesit.FindAsync(id);
            if (njesit != null)
            {
                _context.Njesit.Remove(njesit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NjesitExists(int id)
        {
          return (_context.Njesit?.Any(e => e.NjesitId == id)).GetValueOrDefault();
        }
    }
}
