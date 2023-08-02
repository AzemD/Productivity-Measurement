using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Produktiviteti.Models;


namespace Produktiviteti.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pozita> Pozitat { get; set; }
        public DbSet<Njesit> Njesit { get; set; }

        public DbSet<MainTableViewModel> MainTableViewModel { get; set; }
        public DbSet<Tipi_Kerkeses>Tipi_Kerkeses { get; set; }
        public DbSet<Pergjigja>Pergjigja { get; set; }
        public DbSet<Tipi_Pergjigje_Main> Tipi_Pergjigje_Main { get; set; }

        public DbSet<Main_Table>Main_Tables { get; set;  }
        public DbSet<Main_Table> Main_Table { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers{get; set;}




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainTableViewModel>().HasNoKey();


            base.OnModelCreating(modelBuilder);
        }



    }

}
