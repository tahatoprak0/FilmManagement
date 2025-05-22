using FilmYonetimSistemi.Data;
using FilmYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYonetimSistemi.Services
{
    public class YonetmenService
    {
        public void AddYonetmen(EFContext context)
        {
            Console.WriteLine("Yönetmen Bilgilerini Giriniz:");
            Console.Write("Yönetmen Adı: ");
            string yonetmenAdi = Console.ReadLine();
            while (string.IsNullOrEmpty(yonetmenAdi))
            {
                Console.Write("Yönetmen adı boş olamaz. Lütfen bir yönetmen adı girin: ");
                yonetmenAdi = Console.ReadLine();
                if (!string.IsNullOrEmpty(yonetmenAdi))
                {
                    break;
                }
            }
            Console.Write("Yönetmen Soyadı: ");
            string yonetmenSoyadi = Console.ReadLine();
            while (string.IsNullOrEmpty(yonetmenSoyadi))
            {
                Console.Write("Yönetmen Soyadı boş olamaz. Lütfen bir yönetmen adı girin: ");
                yonetmenSoyadi = Console.ReadLine();
                if (!string.IsNullOrEmpty(yonetmenSoyadi))
                {
                    break;
                }
            }
            Console.Write("Yönetmen Doğum Yılı: ");
            string dogumYili = Console.ReadLine();
            int dogumYili1;
            while (!int.TryParse(dogumYili, out dogumYili1))
            {
                Console.Write("Geçersiz doğum yılı. Lütfen rakamlarla yıl girin: ");
                dogumYili = Console.ReadLine();
            }

            var mevcutYonetmen = context.Yonetmenler.FirstOrDefault(y => y.yonetmenAdi.Equals(yonetmenAdi, StringComparison.OrdinalIgnoreCase) && y.yonetmenSoyadi.Equals(yonetmenSoyadi, StringComparison.OrdinalIgnoreCase) && y.dogumYili.Equals(dogumYili, StringComparison.OrdinalIgnoreCase));

            if (mevcutYonetmen != null)
            {
                Console.WriteLine($"{mevcutYonetmen.yonetmenAdi} {mevcutYonetmen.yonetmenSoyadi} ID: {mevcutYonetmen.yonetmenId} zaten mevcut.");
            }
            else
            {
                var yonetmen = new Yonetmen();
                yonetmen.yonetmenAdi = yonetmenAdi;
                yonetmen.yonetmenSoyadi = yonetmenSoyadi;
                yonetmen.dogumYili = dogumYili;
                context.Yonetmenler.Add(yonetmen);
                context.SaveChanges();
                Console.WriteLine("Yönetmen başarıyla eklendi.");
            }



        }
        public void RemoveYonetmen(EFContext context)
        {
            Console.Write("Silmek istediğiniz yönetmenin ID'sini girin: ");
            int yonetmenId;
            if (int.TryParse(Console.ReadLine(), out yonetmenId))
            {
                var yonetmen = context.Yonetmenler.Find(yonetmenId);
                if (yonetmen != null)
                {
                    context.Yonetmenler.Remove(yonetmen);
                    context.SaveChanges();
                    Console.WriteLine($"{yonetmen.yonetmenAdi} {yonetmen.yonetmenSoyadi} başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Yönetmen bulunamadı.");
                }

            }
            else
            {
                Console.Write("Geçersiz ID. Lütfen geçerli bir Id girin: ");
            }
        }

        public void UpdateYonetmen(EFContext context)
        {
            Console.Write("Güncellemek istediğiniz yönetmenin ID'sini girin: ");
            int yonetmenId;
            if (int.TryParse(Console.ReadLine(), out yonetmenId))
            {
                var yonetmen = context.Yonetmenler.Find(yonetmenId);

                if (yonetmen != null)
                {
                    Console.WriteLine($"Güncellemek İstediğiniz Yönetmen {yonetmen.yonetmenAdi} {yonetmen.yonetmenSoyadi}\n----------------------------------------------------------");
                    Console.Write("Yönetmen Adı: ");
                    yonetmen.yonetmenAdi = Console.ReadLine();
                    Console.Write("Yönetmen Soyadı: ");
                    yonetmen.yonetmenSoyadi = Console.ReadLine();
                    Console.Write("Yönetmen Doğum Yılı: ");
                    yonetmen.dogumYili = Console.ReadLine();
                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Yönetmen bulunamadı.");
                }

            }
            else
            {
                Console.Write("Geçersiz ID. Lütfen geçerli bir Id girin: ");
            }
        }

        public void YonetmenListele(EFContext context)
        {
            var yonetmenler = context.Yonetmenler.ToList();
            if (yonetmenler.Count == 0)
            {
                Console.WriteLine("Yönetmen bulunamadı.");
                return;
            }
            else
            {
                Console.WriteLine("Yönetmen Listesi:");
                foreach (var yonetmen in yonetmenler)
                {
                    Console.WriteLine($"ID: {yonetmen.yonetmenId}, Adı: {yonetmen.yonetmenAdi}, Soyadı: {yonetmen.yonetmenSoyadi}, Doğum Yılı: {yonetmen.dogumYili}");
                }

            }

        }
    }
}
