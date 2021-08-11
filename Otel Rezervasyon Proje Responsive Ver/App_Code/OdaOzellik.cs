using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelRezervasyon
{
    public class OdaOzellik
    {
        //Veritaban�nda ManzaraTip bu class da ise manzaraId olarak tutulan manzara tipinin de�erlerine g�re a��klamas� :
        //Manzara Yok = 0
        //Deniz Manzaras� = 1
        //Orman Manzaras� = 2
        //Da� Manzaras� = 3
        //�ehir Manzaras� = 4

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