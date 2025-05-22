using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYonetimSistemi.Models
{
    public class Yonetmen
    {
        public int yonetmenId { get; set; }
        public string yonetmenAdi { get; set; }
        public string yonetmenSoyadi { get; set; }
        public string dogumYili { get; set; }
        public List<Film> filmler { get; set; } = new List<Film>();
    }
}
