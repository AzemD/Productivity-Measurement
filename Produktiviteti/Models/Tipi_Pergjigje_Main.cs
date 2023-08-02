using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;



namespace Produktiviteti.Models
{
    public class Tipi_Pergjigje_Main
    {

        [Key]
        public int PergjigjaMainId { get; set; }
        public string? PergjigjaMain { get; set; }

        public int? PergjigjaId { get; set; }
        public Pergjigja? Pergjigja { get; set; }

        [ForeignKey("Main_Table")]
        public int? Main_Table_Id { get; set; }
        public Main_Table? Main_Table { get; set; }

        public string? userId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("Tipi_Kerkeses")]
        public int? KerkesaId { get; set; }
        public Tipi_Kerkeses? Tipi_Kerkeses { get; set; }
    }
}
