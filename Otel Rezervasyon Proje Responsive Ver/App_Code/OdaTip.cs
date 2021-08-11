using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class OdaTip
    {
        public int id { get; set; }
        public int otelID { get; set; }
        public string ad { get; set; }
        public string aciklama { get; set; }
        public double fiyat { get; set; }
        public int odaKapasite { get; set; }
        public string resimAd { get; set; }
        public Oteller oteller { get; set; }
        public OdaTip(Oteller inOteller)
        {
            oteller = inOteller;
        }
    }
}