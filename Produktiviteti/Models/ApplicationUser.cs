using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produktiviteti.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string emri { get; set; }
        public string mbiemri { get; set; }

        public int PozitaId { get; set; }
      
        public Pozita Pozita { get; set; }

        public int NjesitId { get; set; }    

        public Njesit Njesit { get; set; }


    }
}
