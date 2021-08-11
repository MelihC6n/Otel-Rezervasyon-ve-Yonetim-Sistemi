using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;

public partial class rezervasyonlar : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "resepsiyon")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        if (Page.IsPostBack == false)//mevcut gündeki rezervasyonlar listelenir
        {
            Musteri musteri = new Musteri(null)
            {
                ad = ""
            };
            List<Rezervasyon> rezervasyonListele = new List<Rezervasyon>();
            Rezervasyon rezTarihi = new Rezervasyon(null, null)
            {
                gelisTarihi = DateTime.Now
            };
            rezervasyonListele = db.RezervasyonViewSelect(rezTarihi, musteri);
            rptRezervasyon.DataSource = rezervasyonListele;
            rptRezervasyon.DataBind();
        }
    }

    protected void btnAra_Click(object sender, EventArgs e)
    {
        Musteri musteri = new Musteri(null)//rezervasyonlarda kişi araması yapılır
        {
            ad = txtad.Text
        };
        List<Rezervasyon> rezervasyonListele = new List<Rezervasyon>();
        Rezervasyon rezTarihi = new Rezervasyon(null, null)
        {
            gelisTarihi = DateTime.Now
        };
        rezervasyonListele = db.RezervasyonViewSelect(rezTarihi, musteri);
        rptRezervasyon.DataSource = rezervasyonListele;
        rptRezervasyon.DataBind();
    }

    protected void btnTemizle_Click(object sender, EventArgs e)
    {
        Response.Redirect("rezervasyonlar.aspx");
    }

    protected void rptRezervasyon_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "CheckIn")//tıklanan kişinin bilgileri check-inaspx'e yönlendirilir
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(',');
            Musteri musteri = new Musteri(null)
            {
                ad = Convert.ToString(commandArgs[2]),
                soyad = Convert.ToString(commandArgs[3]),
                cepTelefon = Convert.ToString(commandArgs[4]),
            };
            Rezervasyon rezervasyon = new Rezervasyon(musteri, null)
            {
                gelisTarihi = Convert.ToDateTime(commandArgs[0]),
                gidisTarihi = Convert.ToDateTime(commandArgs[1]),
                indirimOrani = Convert.ToInt32(commandArgs[5]),
                odaID = Convert.ToInt32(commandArgs[6]),
                id = Convert.ToInt32(commandArgs[7]),
                ucret=Convert.ToDouble(commandArgs[8])
            };
            string data = "GelisTarihi=" + rezervasyon.gelisTarihi.ToString().Substring(0, 10) + "&GidisTarihi=" + rezervasyon.gidisTarihi.ToString().Substring(0, 10) + "&Ad=" + musteri.ad + "&Soyad=" + musteri.soyad + "&Tel=" + musteri.cepTelefon + "&Indirim=" + rezervasyon.indirimOrani + "&Oda=" + rezervasyon.odaID + "&ID=" + rezervasyon.id + "&Ucret=" + rezervasyon.ucret;
            string hex = "";
            foreach (char c in data)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            Response.Redirect("check-in.aspx?D="+hex);
        }

    }
}