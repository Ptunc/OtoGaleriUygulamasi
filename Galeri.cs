using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasi
{
    internal class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();
        public List<Araba> KiralananArabalar = new List<Araba>();
        public int ToplamArabaSayisi
        {
            get
            {
                return this.Arabalar.Count;
            }
        }
        public int KiradakiArabaSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        adet++;
                        KiralananArabalar.Add(item);
                    }
                }
                return adet;
            }
        }
        public int BekleyenArabaSayisi 
        {
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        adet++;
                    }
                }
                return adet;
            } 
        }
        public int ToplamArabaKiralanmaAdedi {
            get
            {
                int toplam = 0;
                foreach (Araba item in Arabalar)
                {
                    toplam += item.KiralanmaSureleri.Count;
                }
                return toplam;
            }
        }
        public int ToplamArabaKiralanmaSuresi 
        {
            get
            {
                int toplam = 0;
                foreach (Araba item in Arabalar)
                {
                    toplam += item.ToplamKiralanmaSuresi;
                }
                return toplam;
            } 
            
        }
        public float Ciro
        {
            get
            {
                float toplam = 0f;
                foreach (Araba item in Arabalar)
                {
                    toplam += item.KiralamaUcreti * item.ToplamKiralanmaSuresi;

                }
                return toplam;
            }
         }

        public Araba ArabaBilgisi { get;  }


        public void ArabaEkleme(string plaka, string marka, int ucret, ARACTIPI aracTipi)
        {
            //Araba a = new Araba();
            //a.Plaka = plaka;
            //a.Marka = marka;
            Araba a = new Araba(plaka, marka, ucret, aracTipi);
            this.Arabalar.Add(a);
        }
        public void ArabaKiralama(string plaka, int sure)
        {


            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka==plaka)
                {
                    a = item;
                }
            }

            if (a!=null)
            {
                //a.KiralanmaSayisi++;
                a.KiralanmaSureleri.Add(sure);
                a.Durum = DURUM.Kirada;

            }
        }
        public void KiralamaIptali(string plaka, int sure)
        {
            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.KiralanmaSureleri.Remove(a.KiralanmaSureleri.Count-1);
                a.Durum = DURUM.Galeride;

            }
        }

    }
}
