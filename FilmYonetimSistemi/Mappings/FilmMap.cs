using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FilmYonetimSistemi.Models;

namespace FilmYonetimSistemi.Mappings
{
    class FilmMap : EntityTypeConfiguration<Film>
    {

        public FilmMap()
        {
            this.ToTable("Filmler");
            this.HasKey(f => f.filmId);
            this.Property(f => f.filmId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(f => f.filmAdi).IsRequired().HasMaxLength(50);
            this.Property(f => f.yapimYili).IsRequired().HasMaxLength(5);
            this.HasRequired(f => f.yonetmen).WithMany(y => y.filmler).HasForeignKey(f => f.yonetmenId);
        }
       
    }
}
