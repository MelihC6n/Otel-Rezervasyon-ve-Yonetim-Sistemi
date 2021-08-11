using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;
public partial class kullaniciEkle : System.Web.UI.Page
{
    DbProcess dbprocess = new DbProcess();
    Oteller oteller = new Oteller();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "yönetici")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        if (!IsPostBack)
        {
            //sistemdeki oteller getirilir (başta çoklu otele yönelik yapılmıştı)
            List<Oteller> liste = new List<Oteller>();
            liste = dbprocess.OtellerSelect();
            for (int i = 0; i <= liste.Count - 1; i++)
            {
                oteller = liste[i];
                drpOtel.Items.Add(oteller.ad);
            }

            drpOtel.Items.Insert(0, new ListItem("Otel Seçiniz..", "0"));
            drpkullaniciYetki.Items.Insert(0, new ListItem("Yetki Seçiniz..", "0"));
        }
    }

    protected void btnKullaniciEkle_Click(object sender, EventArgs e)
    {   //seçilen bilgilere ve yetkiye göre kullanıcı eklenir
        if (drpOtel.SelectedIndex != 0 && drpkullaniciYetki.SelectedIndex != 0)
        {
            oteller.ad = drpOtel.Text;
            Kullanicilar kullanicilar = new Kullanicilar(oteller)
            {
                ad = txtAd.Text,
                soyad = txtSoyad.Text,
                kullaniciAd = txtKullaniciAd.Text,
                sifre = txtSifre.Text,
                otelID = dbprocess.otelIDBul(oteller),
                yetki = Convert.ToBoolean(drpkullaniciYetki.SelectedIndex - 1)
            };
            dbprocess.KullanicilarInsert(kullanicilar);
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "2;url=kullaniciEkle.aspx";
            this.Page.Controls.Add(meta);
            lblOnay.Visible = true;
            lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
        }

    
    }
       
    }