using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class Musteri
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string ePosta { get; set; }
        public string cepTelefon { get; set; }
        public Boolean cinsiyet { get; set; }
        public string notlar { get; set; }
        public int konukSayisi { get; set; }
        public string sirketKodu { get; set; }
        public string ulke { get; set; }
        public string uyruk { get; set; }
        public AnlasmaliSirketler anlasmaliSirketler { get; set; }
        public Musteri(AnlasmaliSirketler inAnlasmaliSirketler)
        {
            anlasmaliSirketler = inAnlasmaliSirketler;
        }
    }
}