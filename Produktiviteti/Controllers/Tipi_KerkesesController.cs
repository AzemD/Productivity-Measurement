using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Produktiviteti.Data;
using Produktiviteti.Models;

namespace Produktiviteti.Controllers
{
    public class Tipi_KerkesesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public Tipi_KerkesesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var tipiKerkeses = await _context.Tipi_Kerkeses.ToListAsync();
            return View(tipiKerkeses);
        }



        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipi_Kerkeses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KerkesaId,Emri_Kerkeses")] Tipi_Kerkeses tipi_Kerkeses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipi_Kerkeses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipi_Kerkeses);
        }
    }
}
