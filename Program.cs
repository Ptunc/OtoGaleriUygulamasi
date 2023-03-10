using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Threading;

namespace OtoGaleriUygulamasi
{
    internal class Program
    {
        static int surekayit = 0;
        static char[] sayilar = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        static char[] harfler = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'O', 'I', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };
        static int count = 0;
        static Galeri G048Galerisi = new Galeri();
        static Araba araba = new Araba();
        //KULLANICI ETKİLELŞİMİ
        static void Main(string[] args)
        {
            Uygulama();

        }
        static void Uygulama()
        {
            SahteVeriGir();
            Menu();
            SecimAl();
        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                    ");
            Console.WriteLine("1- Araba Kirala (K)                 ");
            Console.WriteLine("2- Araba Teslim Al (T)              ");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)   ");
            Console.WriteLine("4- Galerideki Arabaları Listele (M) ");
            Console.WriteLine("5- Tüm Arabaları Listele (A)        ");
            Console.WriteLine("6- Kiralama İptali (I)              ");
            Console.WriteLine("7- Araba Ekle (Y)                   ");
            Console.WriteLine("8- Araba Sil (S)                    ");
            Console.WriteLine("9- Bilgileri Göster (G)             ");
        }
        static void SahteVeriGir()
        {

            G048Galerisi.ArabaEkleme("34ARB3434", "FIAT", 70, ARACTIPI.Sedan);
            G048Galerisi.ArabaEkleme("35ARB3535", "KIA", 60, ARACTIPI.SUV);
            G048Galerisi.ArabaEkleme("34US2342", "OPEL", 50, ARACTIPI.Hatchback);
            //G048Galerisi.ArabaEkleme("26AAA12", "OPEL", 220f, ARACTIPI.Hatchback);
            //G048Galerisi.ArabaEkleme("27AAA12", "OPEL", 240f, ARACTIPI.SUV);
            //G048Galerisi.ArabaEkleme("28AAAA12", "OPEL", 210.5f, ARACTIPI.Sedan);

        }

        static void SecimAl()
        {
            string secim = "";
            while (true)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                secim = Console.ReadLine().ToUpper();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKirala(); //problem yok
                        break;
                    case "2":
                    case "T":
                        ArabaTeslimAl(); //problem yok
                        break;
                    case "3":
                    case "R":
                        KiradakiArabalariListele(); //problem yok
                        break;
                    case "4":
                    case "M":
                        GaleridekiArabalariListele(); //problem yok
                        break;
                    case "5":
                    case "A":
                        TumArabalariListele(); //problem yok
                        break;
                    case "6":
                    case "I":
                        KiralamaIptali();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle(); //problem yok
                        break;
                    case "8":
                    case "S":
                        ArabaSil(); //problem yok
                        break;
                    case "9":
                    case "G":
                        BilgileriGoster();
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        count++;
                        if (count == 10) Environment.Exit(0);
                        break;
                }
            }
        }
      
        static void ArabaEkle()
        {
            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine("");
            int kontrol = 0;
            string plaka = "";

            while (true)
            {
                plaka = PlakaKontrol("Plaka: ");
                xMi(plaka);
                foreach (Araba item in G048Galerisi.Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                        kontrol = 0;
                        break;
                    }
                    else kontrol++;
                }
                if (kontrol == G048Galerisi.Arabalar.Count)
                {
                    kontrol = 0;
                    break;
                }
            }

            string marka = "";

            while (true)
            {
                Console.Write("Marka: ");
                marka = Console.ReadLine().ToUpper();
                xMi(marka);
                int sayi;
                bool Sonuc = int.TryParse(marka, out sayi);
                if (Sonuc)
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
                else
                {
                    break;
                }
            }
            int kiralamaBedeli;
            string bedel = "";
            while (true)
            {
                Console.Write("Kiralama bedeli: ");
                bedel = Console.ReadLine();
                xMi(bedel);

                int sayi;
                bool Sonuc = int.TryParse(bedel, out sayi);
                if (Sonuc)
                {
                    kiralamaBedeli = sayi;
                    break;
                }
                else
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
            }
            

            ARACTIPI aTipi = ARACTIPI.Empty;

            Console.WriteLine("Araç tipi:      ");
            Console.WriteLine("SUV için 1       ");
            Console.WriteLine("Hatchback için 2 ");
            Console.WriteLine("Sedan için 3     ");
            while (true)
            {
                Console.Write("Araba Tipi: ");
                string secim = Console.ReadLine().ToUpper();

                switch (secim)
                {
                    case "1":
                        aTipi = ARACTIPI.SUV;
                        break;
                    case "2":
                        aTipi = ARACTIPI.Hatchback;
                        break;
                    case "3":
                        aTipi = ARACTIPI.Sedan;
                        break;
                    case "X":
                        SecimAl();
                        break;
                    default:
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                        break;
                }
                if (aTipi != ARACTIPI.Empty) break;
            }

            G048Galerisi.ArabaEkleme(plaka, marka, kiralamaBedeli, aTipi);
            Console.WriteLine("");
            Console.WriteLine("Araba başarılı bir şekilde eklendi.");

        } //ekrandan bilgi alacak, galeri class'a gönderecek.
        static void ArabaKirala()
        {
            string plaka = "";
            int sure = 5;
            string kiralanmaSuresi = "";
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine("");
            if (G048Galerisi.ToplamArabaSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
            }
            else if(G048Galerisi.BekleyenArabaSayisi == 0)
            {
                Console.WriteLine("Tüm araçlar kirada.");
            }
            else
            {
                while (true)
                {
                    plaka = PlakaKontrol("Kiralanacak arabanın plakası: ");
                    foreach (Araba item in G048Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka && item.Durum == DURUM.Kirada)
                        {
                            Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                            count = 0;
                        }
                        else if (item.Plaka == plaka && item.Durum == DURUM.Galeride)
                        {
                            while (true)
                            {
                                Console.Write("Kiralanma süresi: ");
                                kiralanmaSuresi = Console.ReadLine();
                                xMi(kiralanmaSuresi);
                                bool Sonuc = int.TryParse(kiralanmaSuresi, out sure);
                                if (Sonuc)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine(plaka + " plakalı araba " + sure + " saatliğine kiralandı.");
                                    G048Galerisi.ArabaKiralama(plaka, sure);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                                    count = 0;
                                }
                            }

                        }
                        else count++;
                    }
                    if (count == G048Galerisi.Arabalar.Count)
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                        count = 0;
                    }
                }
            }
            //doğru bir plaka girilene kadar tekrar tekrar
            //plaka sorgulama işini burada yapacağız.

            //plaka olup olmadığını kontrol edecek bir metot
            //bu plakalı aracın kiralanmaya müsait olup olmadığını veya
            //böyle bir araba olup olmadığını kontrol eden bir metot
        } //ekrandan bilgi alacak, galeri class'a gönderecek.

        static void ArabaTeslimAl()
        {
            string plaka = "";
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine("");
            if (G048Galerisi.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Kirada hiç araba yok.");
            }
            else
            {
                count = 0;
                while (true)
                {
                    plaka = PlakaKontrol("Teslim edilecek arabanın plakası: ");
                    foreach (Araba item in G048Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka)
                        {
                            if (item.Durum == DURUM.Kirada)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Araba galeride beklemeye alındı.");
                                count = 0;
                                item.Durum = DURUM.Galeride;
                                return;
                            }

                            else if (item.Durum == DURUM.Galeride)
                            {
                                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");

                            }
                            count = 0;
                        }
                        else count++;
                    }
                    if (G048Galerisi.ToplamArabaSayisi == count)
                    {
                        count = 0;
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }
                }
            }
        }
        static void KiradakiArabalariListele()
        {
            Console.WriteLine("-Kiradaki Arabalar-");
            Console.WriteLine("");
            if (G048Galerisi.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in G048Galerisi.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {

                        Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + item.KiralamaUcreti.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum.ToString().PadRight(8));

                    }
                }
            }
        }

        static void GaleridekiArabalariListele()
        {
            Console.WriteLine("-Galerideki Arabalar-");
            Console.WriteLine("");
            if (G048Galerisi.BekleyenArabaSayisi == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in G048Galerisi.Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {

                        Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + item.KiralamaUcreti.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum.ToString().PadRight(8));

                    }
                }
            }
        }
        static void TumArabalariListele()
        {
            Console.WriteLine("-Tüm Arabalar-");
            Console.WriteLine("");
            if (G048Galerisi.Arabalar.Count == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in G048Galerisi.Arabalar)
                {
                    Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + item.KiralamaUcreti.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum.ToString().PadRight(8));
                }

            }
        }

        static void KiralamaIptali()
        {
            string plaka = "";
            int kontrol = 0;
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine("");
            if (G048Galerisi.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Kirada araba yok.");
            }
            else
            {
                while (true)
                {
                    plaka = PlakaKontrol("Kiralaması iptal edilecek arabanın plakası: ");
                    foreach (Araba item in G048Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka)
                        {
                            if (item.Durum == DURUM.Kirada)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("İptal gerçekleştirildi.");
                                item.KiralanmaSureleri.RemoveAt(item.KiralanmaSureleri.Count - 1);
                                item.Durum = DURUM.Galeride;
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                            }
                            kontrol = 0;
                        }
                        else kontrol++;
                    }
                    if (kontrol == G048Galerisi.Arabalar.Count)
                    {
                        kontrol = 0;
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }
                }
            }
        }
        static void ArabaSil()
        {
            string plaka = "";
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine("");
            int kontrol = 0;
            while (true)
            {
                plaka = PlakaKontrol("Silmek istediğiniz arabanın plakasını giriniz: ");
                foreach (Araba item in G048Galerisi.Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        if (item.Durum == DURUM.Galeride)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Araba silindi.");
                            G048Galerisi.Arabalar.Remove(item);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekleştirilemedi.");
                        }
                        kontrol = 0;
                    }
                    else kontrol++;
                }
                if (kontrol == G048Galerisi.Arabalar.Count)
                {
                    kontrol = 0;
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }
            }
        }

        static void BilgileriGoster()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine($"Toplam araba sayısı: {G048Galerisi.ToplamArabaSayisi}");
            Console.WriteLine($"Kiradaki araba sayısı: {G048Galerisi.KiradakiArabaSayisi}");
            Console.WriteLine($"Bekleyen araba sayısı: {G048Galerisi.BekleyenArabaSayisi}");
            Console.WriteLine($"Toplam araba kiralama süresi: {G048Galerisi.ToplamArabaKiralanmaSuresi}");
            Console.WriteLine($"Toplam araba kiralama adedi: {G048Galerisi.ToplamArabaKiralanmaAdedi}");
            Console.WriteLine($"Ciro: {G048Galerisi.Ciro}");
        }

        static string PlakaKontrol(string mesaj)
        {
            while (true)
            {
            Etiket: Console.Write(mesaj);
                string plakaNo = Console.ReadLine().ToUpper();
                xMi(plakaNo);
                count = 0;
                int kontrol = 0;
                int sayac = 0;
            if (plakaNo.Length >= 7 && plakaNo.Length <= 9)
            {
                string sayiKontrol = plakaNo.Substring(0, 2);
                string harfKontrol = plakaNo.Substring(2, 3);
                string sonKontrol = "";
                if (plakaNo.Length == 7)
                {
                    sonKontrol = plakaNo.Substring(5, 2);
                }
                else if (plakaNo.Length == 8)
                {
                    sonKontrol = plakaNo.Substring(5, 3);
                }
                else
                {
                    sonKontrol = plakaNo.Substring(5, 4);
                }

                int sayi;
                bool sonuc = int.TryParse(sayiKontrol, out sayi);
                    if (sonuc)
                    {
                        count = 0;
                        sayac = 2;
                    }
                    else
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                        goto Etiket;
                    }
                    int a;
                    if (int.TryParse(harfKontrol[0].ToString(), out a) == true)
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                        goto Etiket;
                    }


                for (int i = 0; i < harfler.Length; i++)
                {
                        if (harfKontrol[0] == harfler[i]) count++;
                        if (harfKontrol[1] == harfler[i]) count++;
                }
                for (int j = 0; j < sayilar.Length; j++)
                {
                    if (harfKontrol[1] == sayilar[j]) count++;
                }
                    if (count < 1)
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    goto Etiket;
                }
                else
                {
                    count = 0;
                    for (int i = 0; i < harfler.Length; i++)
                    {
                         if (harfKontrol[2] == harfler[i]) count++;

                    }
                    for (int i = 0; i < sayilar.Length; i++)
                    {
                            if (harfKontrol[2] == sayilar[i])
                            {
                                count++;
                                kontrol++;
                                    }

                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                        goto Etiket;
                    }
                    else count = 0;
                }
                if(kontrol > 0)
                    {
                        if(sonKontrol.Length == 4)
                        {
                            Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                            goto Etiket;
                        }
                        else
                        {
                            int sayi3;
                            bool sonuc3 = int.TryParse(sonKontrol, out sayi3);
                            if (sonuc3)
                            {
                                sayac += sonKontrol.Length;
                                if (sayac > 6)
                                {
                                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                                    goto Etiket;
                                }
                                return plakaNo;
                            }
                            else
                            {
                                Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                                goto Etiket;
                            }
                        }
                    }
                int sayi2;
                bool sonuc2 = int.TryParse(sonKontrol, out sayi2);
                    if (sonuc2)
                    {
                        sayac += sonKontrol.Length;
                        if(sayac > 6)
                        {
                            Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                            goto Etiket;
                        }
                        else return plakaNo;
                    }
                    else
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                        goto Etiket;
                    }
            }
            else
            {
                Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                goto Etiket;
            }
        }
        }

        static void xMi(string ifade)
        {
            if (ifade == "X" || ifade == "x") SecimAl();
            else return;
        }
    }
}
