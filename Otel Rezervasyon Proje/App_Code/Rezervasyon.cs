using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class Rezervasyon
    {
        public int id { get; set; }
        public Boolean gelisAmaci { get; set; }
        public int musteriID { get; set; }
        public DateTime gelisTarihi { get; set; }
        public DateTime gidisTarihi { get; set; }
        public string rezervasyonTarihi { get; set; }
        public string rezervasyonKodu { get; set; }
        public int odaID { get; set; }
        public int indirimOrani { get; set; }
        public double ucret { get; set; }
        public Odalar odalar { get; set; }
        public Musteri musteri { get; set; }
        public Rezervasyon(Musteri inMusteri, Odalar inOdalar)
        {
            musteri = inMusteri;
            odalar = inOdalar;
        }

    }
}
