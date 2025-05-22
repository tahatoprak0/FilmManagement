using FilmYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmYonetimSistemi.Mappings;

namespace FilmYonetimSistemi.Data
{
    public class EFContext : DbContext
    {
        public EFContext()
        {
            Database.SetInitializer<EFContext>(new CreateDatabaseIfNotExists<EFContext>());
        }

        public DbSet<Film> Filmler { get; set; }
        public DbSet<Yonetmen> Yonetmenler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FilmMap());
            modelBuilder.Configurations.Add(new YonetmenMap());
            base.OnModelCreating(modelBuilder);
        }

    }


}
