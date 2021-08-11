using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class Kullanicilar
    {
        public int id { get; set; }
        public int otelID { get; set; }
        public string kullaniciAd { get; set; }
        public string sifre { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public Boolean yetki { get; set; }
        public Oteller oteller { get; set; }
        public Kullanicilar(Oteller inOteller)
        {
            oteller = inOteller;
        }
    }
}
