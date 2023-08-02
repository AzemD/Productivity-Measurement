using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Produktiviteti.Data;
using Produktiviteti.Models;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Produktiviteti.Controllers
{
    public class TipiPergjigjeMainController : Controller
    {

        private readonly ApplicationDbContext _context;

        

        public TipiPergjigjeMainController(ApplicationDbContext context)
        {
            _context = context;

        }

        // GET: TipiPergjigjeMain
        public IActionResult Index()
        {

            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["UserId"] = currentUserId;



            var tipiPergjigjeMainList = _context.Tipi_Pergjigje_Main
                .Include(t => t.Pergjigja)
                .Include(t => t.Main_Table)
                .ToList();

            return View(tipiPergjigjeMainList);
        }






        [HttpPost]
        public IActionResult Create(List<KeyValuePair<int, string>> pergjigjaValues, int? Main_Table_Id, string userId, List<int> selectedTipiKerkesesIds, int KerkesaId)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Main_Table main_Table = _context.Main_Table.FirstOrDefault(m => m.Main_Table_Id == Main_Table_Id);

            var tipiKerkesesList = _context.Tipi_Kerkeses
             .Select(x => new SelectListItem
             {
                Text = x.Emri_Kerkeses,
                Value = x.KerkesaId.ToString()
             })
              .ToList();

            


            foreach (var pergjigjaValue in pergjigjaValues)
            {
                int pergjigjaId = pergjigjaValue.Key;
                string emriPergjigja = pergjigjaValue.Value;
                

                // Create a new Tipi_Pergjigje_Main object and set the values
                Tipi_Pergjigje_Main tipiPergjigjeMain = new Tipi_Pergjigje_Main
                {
                    PergjigjaId = pergjigjaId,
                    PergjigjaMain = emriPergjigja,
                    Main_Table_Id = Main_Table_Id,
                    userId = currentUserId,
                    KerkesaId = KerkesaId


                };
               
                _context.Tipi_Pergjigje_Main.Add(tipiPergjigjeMain);
               



            }

          

            _context.SaveChanges();

            // Redirect or return a response as needed

            return RedirectToAction("Index"); // Example: Redirect to the home page
        }

    }
}

