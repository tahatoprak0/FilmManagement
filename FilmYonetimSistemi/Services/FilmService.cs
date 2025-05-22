using FilmYonetimSistemi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmYonetimSistemi.Models;

namespace FilmYonetimSistemi.Services
{
    public class FilmService
    {
        public void AddFilm(EFContext context)
        {
            Console.WriteLine("Film Bilgilerini Giriniz:");

            Console.Write("Film Adı: ");
            string filmAdi = Console.ReadLine();

            while (string.IsNullOrEmpty(filmAdi))
            {
                Console.Write("Film adı boş olamaz. Lütfen bir film adı girin: ");
                filmAdi = Console.ReadLine();
                if (!string.IsNullOrEmpty(filmAdi))
                {
                    break;
                }
            }


            if (context.Filmler.Any(f => f.filmAdi.Equals(filmAdi, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"{filmAdi} zaten mevcut.");
                return;

            }


            Console.Write("Yapım Yılı: ");
            string yapimYili = Console.ReadLine();
            int yapimYili1;

            while (!int.TryParse(yapimYili, out yapimYili1))
            {
                Console.Write("Geçersiz yapım yılı. Lütfen rakamlarla yıl girin: ");
                yapimYili = Console.ReadLine();
            }

            Console.Write("Yönetmen ID: ");
            int yonetmenId;
            while (!int.TryParse(Console.ReadLine(), out yonetmenId) || !context.Yonetmenler.Any(y => y.yonetmenId == yonetmenId))
            {
                Console.Write("Geçersiz ID. Lütfen geçerli bir Id girin: ");
            }

            var film = new Film()
            {
                filmAdi = filmAdi,
                yapimYili = yapimYili,
                yonetmenId = yonetmenId
            };
            context.Filmler.Add(film);
            context.SaveChanges();
            Console.WriteLine("Film başarıyla eklendi.");

        }
        public void RemoveFilm(EFContext context)
        {
            Console.Write("Silmek istediğiniz filmin ID'sini girin: ");
            int filmId;
            while (!int.TryParse(Console.ReadLine(), out filmId) || !context.Filmler.Any(f => f.filmId == filmId))
            {
                Console.Write("Geçersiz ID. Lütfen Geçerli Id girin: ");

            }

            var film = context.Filmler.Find(filmId);
            if (film != null)
            {
                context.Filmler.Remove(film);
                context.SaveChanges();
                Console.WriteLine($"{film.filmAdi} başarıyla silindi.");
            }
            else Console.WriteLine("Film bulunamadı.");
        }
        public void UpdateFilm(EFContext context)
        {

            Console.Write("Güncellemek İstediğiniz Filmin Id sini Girin: ");
            int filmId;
            while (!int.TryParse(Console.ReadLine(), out filmId) || !context.Filmler.Any(f => f.filmId == filmId))
            {
                Console.Write("Geçersiz ID. Lütfen geçerli bir Id girin: ");
            }

            var film = context.Filmler.Find(filmId);
            if (film != null)
            {
                Console.WriteLine($"Seçtiğiniz Film: {film.filmAdi}");
                Console.WriteLine($"-----------------------------------------");
                Console.Write("Film Adı:");
                film.filmAdi = Console.ReadLine();
                while (string.IsNullOrEmpty(film.filmAdi))
                {
                    Console.Write("Film adı boş olamaz. Lütfen bir film adı girin: ");
                    film.filmAdi = Console.ReadLine();
                    if (!string.IsNullOrEmpty(film.filmAdi))
                    {
                        break;
                    }
                }

                Console.Write("Yapım Yılı: ");
                film.yapimYili = Console.ReadLine();
                int yapimYili;
                while (!int.TryParse(film.yapimYili, out yapimYili) || yapimYili > DateTime.Today.Year)
                {
                    Console.Write("Geçersiz yapım yılı. Lütfen rakamlarla yıl girin: ");
                    film.yapimYili = Console.ReadLine();
                }
                
                Console.Write("Yönetmen ID: ");
                int yonetmenId;
                bool durum = true;
                while (durum)
                {
                    while (!int.TryParse(Console.ReadLine(), out yonetmenId) || !context.Yonetmenler.Any(y => y.yonetmenId == yonetmenId))
                    {
                        Console.Write("Geçersiz ID. Lütfen geçerli bir Id girin: ");
                    }
                    if (yonetmenId != null)
                    {
                        film.yonetmenId = yonetmenId;
                        durum = false;
                    }

                }


            }
            context.SaveChanges();
            Console.WriteLine("Film başarıyla güncellendi.");

        }
        public void ListFilms(EFContext context)
        {
            var filmler = context.Filmler.ToList();
            if (filmler.Count == 0)
            {
                Console.WriteLine("Film bulunamadı.");
            }
            else
            {
                foreach (var film in filmler)
                {
                    Console.WriteLine($"ID: {film.filmId}, Film Adı: {film.filmAdi}, Yapım Yılı: {film.yapimYili}, Yönetmen ID: {film.yonetmenId}");
                }
            }
        }




    }
}
