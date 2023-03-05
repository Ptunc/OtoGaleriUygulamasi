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
                    }
                }
                return adet;
            }
        }
        public int BekleyenArabaSayisi { get; }
        public int ToplamArabaKiralanmaAdedi { get; }
        public int ToplamArabaKiralanmaSuresi { get; }
        public float Ciro { get; }


        public void ArabaEkleme(string plaka, string marka, float ucret, ARACTIPI aracTipi)
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
                a.Durum = DURUM.Kirada;
                //a.KiralanmaSayisi++;
                a.KiralanmaSureleri.Add(sure);
            }
        }

    }
}
