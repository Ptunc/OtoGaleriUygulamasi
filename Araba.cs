using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasi
{
    internal class Araba
    {

        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaUcreti { get; set; }
        public ARACTIPI ArabaTipi { get; set; }
        public DURUM Durum { get; set; }
        public int KiralanmaSayisi
        {

            get
            {
                return this.KiralanmaSureleri.Count;
            }
        }
        public int ToplamKiralanmaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (int item in this.KiralanmaSureleri)
                {
                    toplam += item;
                }
                return toplam;
            }
        }

        public List<int> KiralanmaSureleri = new List<int>();
        public Araba()
        {
            this.Durum = DURUM.Galeride;
        }
        public Araba(string plaka, string marka, float kUcreti, ARACTIPI aTipi)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaUcreti = kUcreti;
            this.ArabaTipi = aTipi;
            //kurucu metotları default değer atamak için kullanabiliriz
            this.Durum = DURUM.Galeride;
        }

    }
    public enum DURUM
    {
        Empty, Galeride, Kirada
    }
    public enum ARACTIPI
    {
       Empty, SUV, Hatchback, Sedan
    }

}
