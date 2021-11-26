﻿using Microsoft.EntityFrameworkCore;
using WebApplication2.Dominio;

namespace WebApplication2.Repo
{
    public class HeroiContext: DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }

        public DbSet<HeroiBatalha> HeroisBatalhas{ get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity => {

                entity.HasKey(e=>new {e.BatalhaId, e.HeroiId });
            
            });
        }
    }
}
