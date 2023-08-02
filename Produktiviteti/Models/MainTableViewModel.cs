using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Produktiviteti.Models
{
    public class MainTableViewModel
    {
       
        public int? Main_Table_Id { get; set; }
        public int? PergjigjaId { get; set; }

        public string? PergjigjaMain { get; set; } // Add this property


      

        public List<Pergjigja>? PergjigjasViewModel { get; set; } // Use this property to bind the selected PergjigjaIds in the form




        internal List<Pergjigja>? Pergjigjas;

        public List<Main_Table>? Main_TablesViewModel { get; set; }
        
        public List<Main_Table>? MainTables { get; internal set; }

        public List<Tipi_Pergjigje_Main>? Tipi_Pergjigje_Main { get; set; } // Add this field



        public List<SelectListItem>? Tipi_KerkesesList { get; set; }

        public List<Tipi_Kerkeses>? Tipi_Kerkeses { get; set; }
      
        [Display(Name = "Kerkesa")]
        public int? KerkesaId { get; set; } // Add the KerkesaId property
        public string?   userId { get; set; }

        public string? ora { get; set; }
        public string? data_sot { get; set; }


        public string? Depertamenti { get; set; }
        public string? LlojiKerkeses { get; set; }
        public string? Delegimi { get; set; }
        public string? Pauza { get; set; }
        public string? PerfundimiDetyres { get; set; }
        public string? Tjetjer { get; set; }
    }
}






