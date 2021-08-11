using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class OdaOzellik
    {
        //Veritabanýnda ManzaraTip bu class da ise manzaraId olarak tutulan manzara tipinin deðerlerine göre açýklamasý :
        //Manzara Yok = 0
        //Deniz Manzarasý = 1
        //Orman Manzarasý = 2
        //Dað Manzarasý = 3
        //Þehir Manzarasý = 4

        public int id { get; set; }
        public int tipID { get; set; }
        public Boolean klima { get; set; }
        public Boolean sauna { get; set; }
        public Boolean televizyon { get; set; }
        public int manzaraId { get; set; }
        public Boolean sacKurutmaMakinasi { get; set; }
        public Boolean jakuzi { get; set; }
        public Boolean sesYalitimi { get; set; }
        public Boolean mutfak { get; set; }
        public Boolean balkon { get; set; }
        public OdaTip odaTip { get; set; }
        public OdaOzellik(OdaTip inOdaTip)
        {
            odaTip = inOdaTip;
        }
    }
}