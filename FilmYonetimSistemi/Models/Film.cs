using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYonetimSistemi.Models
{
   public class Film
    {
        public int filmId { get; set; }
        public string filmAdi { get; set; }
        public string yapimYili { get; set; }
        public int yonetmenId { get; set; }
        public Yonetmen yonetmen { get; set; }
    }
}
