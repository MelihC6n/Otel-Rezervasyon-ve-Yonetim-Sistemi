using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;

public partial class Kullanıcı_Sayfası_yonlendir : System.Web.UI.Page
{
    DbProcess db = new DbProcess();

    OdaTip odaTip;
    Rezervasyon rezervasyon;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        OdalariGetir();
    }

    protected void FiltreClick(object sender, EventArgs e)
    {
        OdalariGetir();
    }

    private void OdalariGetir()
    {
        string data = Request.QueryString["D"];
        string StrValue = "";
        if (data == null) //yönlendirme yapılmazsa(veri gelmezse Default.aspx a gönderir)
        {
            Response.Redirect("Default.aspx");
        }

        //filtrelere göre sql sorgusu oluşturulur.
        string filtreSorgusu = "select * from OdaTip inner join OdaOzellik on OdaTip.ID=OdaOzellik.TipID where OdaKapasite>=@Kapasite and (";

        if (radHepsi.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "(ManzaraTip=0 or ManzaraTip=1 or ManzaraTip=2 or ManzaraTip=3 or ManzaraTip=4) and ";
        }
        if (radDeniz.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "ManzaraTip=1 and ";
        }
        else if (radOrman.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "ManzaraTip=2 and ";
        }
        else if (radDag.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "ManzaraTip=3 and ";
        }
        else if (radSehir.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "ManzaraTip=4 and ";
        }
        else if (radMYok.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "ManzaraTip=0 and ";
        }
        else
        {
            filtreSorgusu = filtreSorgusu + "(ManzaraTip=0 or ManzaraTip=1 or ManzaraTip=2 or ManzaraTip=3 or ManzaraTip=4) and ";
        }

        if (chkBalkon.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "Balkon=1 and ";
        }
        if (chkMutfak.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "Mutfak=1 and ";
        }
        if (chkJakuzi.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "Jakuzi=1 and ";
        }
        if (chkSauna.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "Sauna=1 and ";
        }
        if (chkKlima.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "Klima=1 and ";
        }
        if (chkTelevizyon.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "Televizyon=1 and ";
        }
        if (chkSacKurut.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "SacKurutmaMakinasi=1 and ";
        }
        if (chkSesYalit.Checked == true)
        {
            filtreSorgusu = filtreSorgusu + "SesYalitimi=1 and ";
        }

        filtreSorgusu = filtreSorgusu.Substring(0, filtreSorgusu.Length - 5);//sondaki and i siler

        filtreSorgusu = filtreSorgusu + ") and OdaTip.ID in (select TipID from Odalar where ID not in (select OdaID from DolulukTakvimi, Odalar where(DolulukTakvimi.DoluTarih >= @GelisTarih and DolulukTakvimi.DoluTarih <= @GidisTarih)))";


        radHepsi.Checked = true;

        while (data.Length > 0)//linkde gönderilen hex tipinde veriyi stringe çevirir
        {
            StrValue += System.Convert.ToChar(System.Convert.ToUInt32(data.Substring(0, 2), 16)).ToString();
            data = data.Substring(2, data.Length - 2);
        }
        string[] degerler = StrValue.Split('&');//birleşik veriyi parçalar

        string[] gelis = degerler[0].Split('=');

        string[] gidis = degerler[1].Split('=');

        string[] kapasite = degerler[2].Split('=');

        string[] sirketKod = degerler[3].Split('=');

        odaTip = new OdaTip(null)
        {
            odaKapasite = Convert.ToInt32(kapasite[1]),
        };
        rezervasyon = new Rezervasyon(null, null)
        {
            gelisTarihi = Convert.ToDateTime(gelis[1]),
            gidisTarihi = Convert.ToDateTime(gidis[1]),
        };
        List<OdaOzellik> odaOzellik = new List<OdaOzellik>();
        List<OdalarGoruntule> odalarGoruntuleList = new List<OdalarGoruntule>();
        odaOzellik = db.OdalarAnaSayfa(rezervasyon, odaTip, filtreSorgusu); //gelecek odaların sorgusu
        for (int i = 0; i < odaOzellik.Count; i++) //odaların bilgilerini hazırlar
        {
            OdalarGoruntule odalarGoruntule = new OdalarGoruntule()
            {
                id = odaOzellik[i].odaTip.id,
                otelID = odaOzellik[i].odaTip.otelID,
                ad = odaOzellik[i].odaTip.ad,
                fiyat = odaOzellik[i].odaTip.fiyat*(rezervasyon.gidisTarihi-rezervasyon.gelisTarihi).TotalDays,
                odaKapasite = odaOzellik[i].odaTip.odaKapasite,
                aciklama = odaOzellik[i].odaTip.aciklama,
                resimAd = odaOzellik[i].odaTip.resimAd
            };

            AnlasmaliSirketler anlasmaliSirketler = new AnlasmaliSirketler(null)
            {
                sirketKodu = sirketKod[1]
            };
         
            anlasmaliSirketler = db.SirketKodunaGoreIndirimSelect(anlasmaliSirketler);
            rezervasyon.indirimOrani = anlasmaliSirketler.indirimYuzdesi;

            if(odalarGoruntule.fiyat / 100 * (100 - rezervasyon.indirimOrani) == odalarGoruntule.fiyat)//kullanıcının indirimi varsa indirimli fiyat gösterir
            {
                odalarGoruntule.indirimliFiyat = "";
            }
            else
            {
                odalarGoruntule.indirimliFiyat = "İndirimli Fiyat = " + (odalarGoruntule.fiyat / 100 * (100 - rezervasyon.indirimOrani)).ToString() + " ₺";
            }

            string ozellikler = "";
            if (odaOzellik[i].manzaraId == 0)
            { ozellikler += "Manzara Tipi :Manzara Yok"; }
            else if (odaOzellik[i].manzaraId == 1)
            { ozellikler += "Manzara Tipi :Deniz Manzarası"; }
            else if (odaOzellik[i].manzaraId == 2)
            { ozellikler += "Manzara Tipi :Orman Manzarası"; }
            else if (odaOzellik[i].manzaraId == 3)
            { ozellikler += "Manzara Tipi :Dağ Manzarası"; }
            else if (odaOzellik[i].manzaraId == 4)
            { ozellikler += "Manzara Tipi :Şehir Manzarası"; }

            ozellikler += Environment.NewLine + Environment.NewLine + "Mevcut Özellikler" + Environment.NewLine+"_________________" + Environment.NewLine;


            if (odaOzellik[i].balkon == true)
            { ozellikler += "• Balkon " + Environment.NewLine; }
            if (odaOzellik[i].jakuzi == true)
            { ozellikler += "• Jakuzi " + Environment.NewLine; }
            if (odaOzellik[i].klima == true)
            { ozellikler += "• Klima " + Environment.NewLine; }
            if (odaOzellik[i].mutfak == true)
            { ozellikler += "• Mutfak " + Environment.NewLine; }
            if (odaOzellik[i].sacKurutmaMakinasi == true)
            { ozellikler += "• Saç kurutma makinası " + Environment.NewLine; }
            if (odaOzellik[i].sauna == true)
            { ozellikler += "• Sauna " + Environment.NewLine; }
            if (odaOzellik[i].sesYalitimi == true)
            { ozellikler += "• Ses yalıtımı " + Environment.NewLine; }
            if (odaOzellik[i].televizyon == true)
            { ozellikler += "• Televizyon " + Environment.NewLine; }

            ozellikler = ozellikler.Substring(0, ozellikler.Length -3);

            odalarGoruntule.ozellikler = ozellikler;
            odalarGoruntuleList.Add(odalarGoruntule);
        }
        if (odalarGoruntuleList.Count > 0)//görüntülenecek oda yoksa aranılan oda bulunamadı yazısı gösterir
        {
            OdalarGetir.DataSource = odalarGoruntuleList;
            OdalarGetir.DataBind();
            Label2.Visible = false;
        }
        else
        {

            OdalarGetir.DataSource = odalarGoruntuleList;
            OdalarGetir.DataBind();
            Label2.Visible = true;
        }
    }

    protected void OdalarGetir_ItemCommand(object source, RepeaterCommandEventArgs e)//rezervasyon getire tıklanan odanın bilgilerini ve kullanıcının bilgilerini hex'e çevirip rezervsayonbilgileri.aspx e gönderir
    {
        if (e.CommandName == "Rezervasyon")
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(',');
            chkBalkon.Text = commandArgs[0] + "," + commandArgs[1];

            string data = "OdaTipi=" + commandArgs[0] + "&Fiyat=" + Convert.ToDouble(commandArgs[1])/ 100 * (100 - rezervasyon.indirimOrani) + "&IndirimOrani=" + rezervasyon.indirimOrani + "&KisiSayisi=" + odaTip.odaKapasite+ "&GelisTarihi="+ rezervasyon.gelisTarihi + "&GidisTarihi=" + rezervasyon.gidisTarihi;
            string hex = "";
            foreach (char c in data)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            Response.Redirect("rezervasyonBilgileri.aspx?D=" + hex);
        }
    }
}