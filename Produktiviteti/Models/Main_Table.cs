using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;



namespace Produktiviteti.Models
{
    public class Main_Table
    {
        
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Main_Table_Id { get; set; }
        public DateTime? data_sot { get; set; }
        public string? ora { get; set; }

        //[ForeignKey("Tipi_Kerkeses")]
        //public int? KerkesaId { get; set; }
        //public Tipi_Kerkeses? Tipi_Kerkeses { get; set; }

        //public string? userId { get; set; }
        //public ApplicationUser? User { get; set; }


    }
}
