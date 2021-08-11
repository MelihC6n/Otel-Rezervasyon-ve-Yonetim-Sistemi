using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class Odalar
    {
        public int id { get; set; }
        public int otelID { get; set; }
        public int kat { get; set; }
        public int odaNo { get; set; }
        public int tipID { get; set; }
        public string durum { get; set; }
        public Oteller oteller { get; set; }
        public OdaTip odaTip { get; set; }
        public Odalar(Oteller inOteller, OdaTip inOdaTip)
        {
            oteller = inOteller;
            odaTip = inOdaTip;
        }
    }
}
