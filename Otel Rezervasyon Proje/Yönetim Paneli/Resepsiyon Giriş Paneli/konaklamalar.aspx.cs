using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;

public partial class konaklamalar : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "resepsiyon")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        if (Page.IsPostBack==false)//odalar dolu boş olarak listelenir
        {
            List<Odalar> odaDurumListele = new List<Odalar>();
            odaDurumListele = db.OdaDurumSelect("");
            rptOdaDurum.DataSource = odaDurumListele;
            rptOdaDurum.DataBind();
        }
    }

    protected void rptOdaDurum_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "BilgiGetir")//tıklanan odanın içeriği gelir
        {
            List<Konaklamalar> konaklamalarListele = new List<Konaklamalar>();
            konaklamalarListele = db.odaBulunanKonaklamalarSelect(Convert.ToInt32(e.CommandArgument));
            rptKisiBilgi.DataSource = konaklamalarListele;
            rptKisiBilgi.DataBind();
        }
    }

    protected void odaNo_TextChanged(object sender, EventArgs e)//oda arama kısmı
    {
            List<Odalar> odaDurumListele = new List<Odalar>();
            odaDurumListele = db.OdaDurumSelect(txtOdaNo.Text);
            rptOdaDurum.DataSource = odaDurumListele;
            rptOdaDurum.DataBind();
    }


    protected void btnTemizle_Click(object sender, EventArgs e)//temizleye baslınca normal verilerin gelmesi sağlanır
    {
        txtOdaNo.Text = "";
        List<Odalar> odaDurumListele = new List<Odalar>();
        odaDurumListele = db.OdaDurumSelect("");
        rptOdaDurum.DataSource = odaDurumListele;
        rptOdaDurum.DataBind();
    }

    protected void MusteriAra_Click(object sender, EventArgs e)//konaklayan müşterilerde arama yapılır
    {
        if(txtAd.Text != "")
        {
            Konaklamalar konaklamalar = new Konaklamalar(null)
            {
                ad = txtAd.Text
            };
            List<Konaklamalar> konaklamalarListele = new List<Konaklamalar>();
            konaklamalarListele = db.KonaklamalarSelect(konaklamalar);
            rptKisiBilgi.DataSource = konaklamalarListele;
        }
        else
        {
            rptKisiBilgi.DataSource = null;
        }
        
         rptKisiBilgi.DataBind();
    }

    protected void MusteriTemizle_Click(object sender, EventArgs e)
    {
        txtAd.Text = "";
        rptKisiBilgi.DataSource = null;
        rptKisiBilgi.DataBind();
    }

    protected void rptKisiBilgi_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Cikis")//tıklanan kişinin bilgileri check-out.aspx 'e gönderilir ve yönlendirilir
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(',');
            Konaklamalar konaklamalar = new Konaklamalar(null)
            {
                tcKimlik = commandArgs[1].ToString(),
                odaNo= Convert.ToInt32(commandArgs[0])
            };

            string data = "tcKimlik=" + konaklamalar.tcKimlik + "&odaNo=" + konaklamalar.odaNo;
            string hex = "";
            foreach (char c in data)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            Response.Redirect("check-out.aspx?D=" + hex);
        }
    }
}