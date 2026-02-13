using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RecipesApp.Models
{
    public class TarifDbContext : DbContext
    {
        public TarifDbContext() : base("name=TarifDbContext")
        {
        }

        public DbSet<Tarif> Tarifler { get; set; }
        public DbSet<Malzeme> Malzemeler { get; set; }
        public DbSet<TarifMalzeme> TarifMalzemeleri { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Many-to-many ilişkisi için yapılandırma
            modelBuilder.Entity<TarifMalzeme>()
                .HasKey(tm => new { tm.TarifID, tm.MalzemeID }); // Composite Key (Birleşik Anahtar)

            modelBuilder.Entity<TarifMalzeme>()
                .HasRequired(tm => tm.Tarif)
                .WithMany(t => t.TarifMalzemeleri)
                .HasForeignKey(tm => tm.TarifID);

            modelBuilder.Entity<TarifMalzeme>()
                .HasRequired(tm => tm.Malzeme)
                .WithMany(m => m.TarifMalzemeleri)
                .HasForeignKey(tm => tm.MalzemeID);
        }
    }
}
