using FilmYonetimSistemi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmYonetimSistemi.Models;
using System.Runtime.Remoting.Contexts;
using FilmYonetimSistemi.Services;

namespace FilmYonetimSistemi
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var Context = new EFContext())
            {
                var filmler = new FilmService();
                var yonetmenler = new YonetmenService();
                string sec;

                while (true)
                {

                    Console.WriteLine("1- Film Yönetim Sistemi");
                    Console.WriteLine("2- Yönetmen Yönetim Sistemi");
                    Console.WriteLine("3- Çıkış");
                    sec = Console.ReadLine();
                    if (sec == "1")
                    {
                        bool durum = true;
                        while (durum)
                        {
                            Console.WriteLine("1. Film Ekle");
                            Console.WriteLine("2. Film Sil");
                            Console.WriteLine("3. Film Güncelle");
                            Console.WriteLine("4. Film Listele");
                            Console.WriteLine("5. Çıkış");

                            Console.Write("Seçiminizi yapın: ");
                            string secim = Console.ReadLine();
                            switch (secim)
                            {
                                case "1":
                                    filmler.AddFilm(Context);
                                    break;
                                case "2":
                                    filmler.RemoveFilm(Context);
                                    break;
                                case "3":
                                    filmler.UpdateFilm(Context);
                                    break;
                                case "4":
                                    filmler.ListFilms(Context);
                                    break;
                                case "5":
                                    durum = false;
                                    break;
                                default:
                                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                                    break;

                            }
                        }
                    }
                    else if (sec == "2")
                    {

                        bool durum = true;
                        while (durum)
                        {
                            Console.WriteLine("1. Yonetmen Ekle");
                            Console.WriteLine("2. Yonetmen Sil");
                            Console.WriteLine("3. Yonetmen Güncelle");
                            Console.WriteLine("4. Yonetmen Listele");
                            Console.WriteLine("5. Çıkış");

                            Console.Write("Seçiminizi yapın: ");
                            string secim = Console.ReadLine();
                            switch (secim)
                            {
                                case "1":
                                    yonetmenler.AddYonetmen(Context);
                                    break;
                                case "2":
                                    yonetmenler.RemoveYonetmen(Context);
                                    break;
                                case "3":
                                    yonetmenler.UpdateYonetmen(Context);
                                    break;
                                case "4":
                                    yonetmenler.YonetmenListele(Context);
                                    break;
                                case "5":
                                    durum = false;
                                    break;
                                default:
                                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                                    break;

                            }
                        }

                    }
                    else if (sec == "3")
                    {
                        Console.WriteLine("Çıkış yapılıyor...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");

                    }



                }
            }


        }
    }
}
