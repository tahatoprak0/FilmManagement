using FilmYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYonetimSistemi.Mappings
{
    class YonetmenMap : EntityTypeConfiguration<Yonetmen>
    {
        public YonetmenMap()
        {
            this.ToTable("Yonetmenler");
            this.HasKey(y => y.yonetmenId);
            this.Property(y => y.yonetmenId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(y => y.yonetmenAdi).IsRequired().HasMaxLength(50);
            this.Property(y => y.yonetmenSoyadi).IsRequired().HasMaxLength(50);
            this.Property(y => y.dogumYili).IsRequired().HasMaxLength(4);
            this.HasMany(y => y.filmler).WithRequired(f => f.yonetmen).HasForeignKey(f => f.yonetmenId);
        }
    }
}
