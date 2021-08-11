using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class Konaklamalar
    {
        public int id { get; set; }
        public int otelID { get; set; }
        public string tcKimlik { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefonNo { get; set; }
        public int odaNo { get; set; }
        public int kat { get; set; }
        public DateTime gelisTarihi { get; set; }
        public DateTime gidisTarihi { get; set; }
        public int indirimOrani { get; set; }
        public double Ucret { get; set; }
        //22.08.2019
        public double alinanUcret { get; set; }
        //22.08.2019
        public Oteller oteller { get; set; }
        public Konaklamalar(Oteller inOteller)
        {
            oteller = inOteller;
        }
    }
}
