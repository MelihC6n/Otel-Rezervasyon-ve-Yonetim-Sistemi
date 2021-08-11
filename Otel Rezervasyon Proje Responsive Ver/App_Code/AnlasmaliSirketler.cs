using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class AnlasmaliSirketler
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string adres { get; set; }
        public string telefon { get; set; }
        public int indirimYuzdesi { get; set; }
        public string sirketKodu { get; set; }
        public int otelID { get; set; }
        public Oteller oteller { get; set; }
        public AnlasmaliSirketler(Oteller inOteller)
        {
            oteller = inOteller;
        }
    }
}
