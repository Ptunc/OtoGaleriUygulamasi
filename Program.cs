using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;

namespace OtoGaleriUygulamasi
{
    internal class Program
    {
        static int count = 0;
        static Galeri G048Galerisi = new Galeri();
        static List<Araba> Arabalar = new List<Araba>();
        //KULLANICI ETKİLELŞİMİ
        static void Main(string[] args)
        {
            Uygulama();

        }
        static void Uygulama()
        {
            SahteVeriGir();
            Menu();
            while (true)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine().ToUpper();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKirala();
                        break;
                    case "2":
                    case "T":
                        //ArabaTeslimAl();
                        break;
                    case "3":
                    case "R":
                        //KiradakiArabalariListele();
                        break;
                    case "4":
                    case "M":
                        //GaleridekiArabalariListele();
                        break;
                    case "5":
                    case "A":
                        TumArabalariListele();
                        break;
                    case "6":
                    case "I":
                        //KiralamaIptali();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle();
                        break;
                    case "8":
                    case "S":
                        //ArabaSil();
                        break;
                    case "9":
                    case "G":
                        //BilgileriGoster();
                        break;
                    default:
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        count++;
                        if (count == 10) return;
                        break;
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                    ");
            Console.WriteLine("1 - Araba Kirala(K)                 ");
            Console.WriteLine("2 - Araba Teslim Al(T)              ");
            Console.WriteLine("3 - Kiradaki Arabaları Listele(R)   ");
            Console.WriteLine("4 - Galerideki Arabaları Listele(M) ");
            Console.WriteLine("5 - Tüm Arabaları Listele(A)        ");
            Console.WriteLine("6 - Kiralama İptali(I)              ");
            Console.WriteLine("7 - Araba Ekle(Y)                   ");
            Console.WriteLine("8 - Araba Sil(S)                    ");
            Console.WriteLine("9 - Bilgileri Göster(G)             ");
        }
        static void SahteVeriGir()
        {

            G048Galerisi.ArabaEkleme("23AAAA12", "OPEL", 200f, (ARACTIPI)1);
            G048Galerisi.ArabaEkleme("24AAAA12", "OPEL", 270.5f, ARACTIPI.Hatchback);
            G048Galerisi.ArabaEkleme("25AAAA12", "OPEL", 280f, ARACTIPI.Sedan);
            G048Galerisi.ArabaEkleme("26AAAA12", "OPEL", 220f, ARACTIPI.Hatchback);
            G048Galerisi.ArabaEkleme("27AAAA12", "OPEL", 240f, ARACTIPI.SUV);
            G048Galerisi.ArabaEkleme("28AAAA12", "OPEL", 210.5f, ARACTIPI.Sedan);

        }
        static void ArabaEkle()
        {
            string plaka = "";

            string marka = "";
            float kiralamaBedeli = 340f;

            ARACTIPI aTipi = ARACTIPI.Empty;

            Console.WriteLine("Araba Tipleri:      ");
            Console.WriteLine(" - SUV için 1       ");
            Console.WriteLine(" - Hatchback için 2 ");
            Console.WriteLine(" - Sedan için 3     ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                aTipi = ARACTIPI.SUV;
            }

            G048Galerisi.ArabaEkleme(plaka, marka, kiralamaBedeli, aTipi);

        } //ekrandan bilgi alacak, galeri class'a gönderecek.
        static void ArabaKirala()
        {
            //doğru bir plaka girilene kadar tekrar tekrar
            //plaka sorgulama işini burada yapacağız.
            string plaka = "";
            //plaka olup olmadığını kontrol edecek bir metot
            //bu plakalı aracın kiralanmaya müsait olup olmadığını veya
            //böyle bir araba olup olmadığını kontrol eden bir metot


            int sure = 5;
            G048Galerisi.ArabaKiralama(plaka, sure);
        } //ekrandan bilgi alacak, galeri class'a gönderecek.

        static void TumArabalariListele()
        {
            int kontrol = 0;
            Console.WriteLine("-Tüm Arabalar-");
            foreach (Araba item in Arabalar)
            {
                Console.Write(item.Durum);
                if(item.Durum == 0)
                {
                    Console.WriteLine("Listelenecek araç yok.");
                    kontrol++;
                }
            }
            if (kontrol == 0)
            {
                Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in Arabalar)
                {
                    Console.WriteLine(item.Plaka + "     " + item.Marka + "    " + item.KiralamaUcreti + " " + item.ArabaTipi + "       " + item.KiralanmaSayisi + "     " + item.Durum);
                }
            }
            else return;
        }
    }
}
