using Microsoft.AspNetCore.Mvc.Rendering;

namespace Produktiviteti.Models
{
    public class MainTable1ViewModel
    {




        public int Main_Table_Id { get; set; }
        //public MainTables mainTables { get; set; }
        public List<Pergjigja> Pergjigjas { get; set; }
        public List<Tipi_Kerkeses> tipi_Kerkeses { get; set; }
        public Main_Table Main_Table { get;  set; }
        public Main_Table MainTables { get;  set; }

        public string ora { get; set; }
        public string data_sot { get; set; }
        public string Depertamenti { get; set; }
        public string LlojiKerkeses { get; set; }
        public string Delegimi { get; set; }
        public string Pauza { get; set; }
        public string PerfundimiDetyres { get; set; }
        public string Tjetjer { get; set; }

      
    }
}
