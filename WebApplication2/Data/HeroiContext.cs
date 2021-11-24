using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication2.Model;

namespace WebApplication1.Data
{
    public class HeroiContext: DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }

        public DbSet<HeroiBatalha> HeroisBatalhas{ get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Password=kuma1234;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=KUMA\XPTO");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity => {

                entity.HasKey(e=>new {e.BatalhaId, e.HeroiId });
            
            });
        }
    }
}
