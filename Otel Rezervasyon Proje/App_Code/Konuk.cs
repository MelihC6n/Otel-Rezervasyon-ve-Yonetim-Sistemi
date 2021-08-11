using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class Konuk
    {
        public int id { get; set; }
        public int musteriID { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public Boolean cinsiyet { get; set; }
        public Musteri musteri { get; set; }
        public Konuk(Musteri inMusteri)
        {
            musteri = inMusteri;
        }
    }
}
