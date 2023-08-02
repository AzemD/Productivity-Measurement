
using MessagePack;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Produktiviteti.Models
{
    public class Pozita
    {
        //[Key]
        public int PozitaId { get; set; }
        public string Pozita_punes { get; set; }
    }
}
