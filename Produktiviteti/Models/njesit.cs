using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Produktiviteti.Models
{
    public class Njesit
    {
        //[Key]
        public int NjesitId { get; set; }
        public string Njesit_Etc { get; set; }
       
    }
}
