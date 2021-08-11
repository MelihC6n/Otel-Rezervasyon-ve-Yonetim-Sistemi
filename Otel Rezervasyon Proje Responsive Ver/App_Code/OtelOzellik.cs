using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class OtelOzellik
    {
        public int id { get; set; }
        public int otelID { get; set; }
        public Boolean fitness { get; set; }
        public Boolean internetErisimi { get; set; }
        public Boolean odaServisi { get; set; }
        public Boolean restoran { get; set; }
        public Boolean yuzmeHavuzu { get; set; }
        public Boolean saglikMerkezi { get; set; }
        public Boolean cocukTesisleri { get; set; }
        public Boolean otopark { get; set; }
        public Boolean toplantiOdasi { get; set; }
        public Boolean evcilHayvan { get; set; }
        public Boolean bar { get; set; }
        public Boolean havaalaniServisi { get; set; }
        public Boolean acikBufeKahvalti { get; set; }
        public Oteller oteller { get; set; }
        public OtelOzellik(Oteller inOteller)
        {
            oteller = inOteller;
        }
    }
}