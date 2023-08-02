using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Produktiviteti.Models
{
    public class Tipi_Kerkeses
    {
        [Key]
        public int KerkesaId { get; set; }
        public string Emri_Kerkeses { get; set; }
    }

}
