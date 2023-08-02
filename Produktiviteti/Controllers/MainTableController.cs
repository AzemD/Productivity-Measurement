using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Produktiviteti.Data;
using Produktiviteti.Models;

namespace Produktiviteti.Controllers
{
    public class MainTableController : Controller
    {
        private readonly ApplicationDbContext _context;
      

        public MainTableController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Main_Table


        public IActionResult Index()
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var mainTables = _context.Main_Table.ToList();
            var pergjigjas = _context.Pergjigja.ToList();
            var tipiKerkeses= _context.Tipi_Kerkeses.ToList();
            var tipiKerkesesList = _context.Tipi_Kerkeses
                .Select(x => new SelectListItem
                {
                    Text = x.Emri_Kerkeses,
                    Value = x.KerkesaId.ToString()
                })
                .ToList();

            MainTableViewModel viewModel = new MainTableViewModel
            {
                MainTables = mainTables,
                Pergjigjas = pergjigjas,
                Tipi_KerkesesList = tipiKerkesesList,
                //Tipi_Kerkeses= tipiKerkeses,
                userId = currentUserId,
                //KerkesaId=2
        

            };

            return View(viewModel);
        }
    }
}




