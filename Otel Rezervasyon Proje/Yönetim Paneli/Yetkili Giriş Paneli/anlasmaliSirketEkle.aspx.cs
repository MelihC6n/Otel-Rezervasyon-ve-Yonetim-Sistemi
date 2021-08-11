using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;

public partial class anlasmaliSirketler : System.Web.UI.Page
{
    Oteller oteller = new Oteller();
    DbProcess dbProcess = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        drpIndirimYuzdesi.Items.Clear();
        for (int i = 1; i <= 100; i++)//indirim yüzdesi drop downa yüzdelik oranlarını ekler
        {
            drpIndirimYuzdesi.Items.Add(i.ToString());
        }
        if (Session["yetki"] != "yönetici")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        txtSirketKodu.ReadOnly = true;
        string GuvenlikKodu = "";
        int harf, bykharf, hangisi;
        Random Rharf = new Random();
        Random Rsayi = new Random();
        Random Rbykharf = new Random();
        Random Rhangisi = new Random();

        txtSirketKodu.Text = "";
        while (txtSirketKodu.Text == "")//random şirket indirim kodu oluşturur
        {
          
            for (int b = 0; b < 8; b++)
            {
                int a = 0;
                hangisi = Rhangisi.Next(1, 3);
                if (hangisi == 1)
                {
                    GuvenlikKodu += Rsayi.Next(0, 10).ToString();
                }
                if (hangisi == 2)
                {
                    harf = Rharf.Next(1, 27);
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        a++;
                        if (a == harf)
                        {
                            bykharf = Rbykharf.Next(1, 3);
                            if (bykharf == 1)
                            {
                                GuvenlikKodu += i;
                            }
                            if (bykharf == 2)
                            {
                                GuvenlikKodu += i.ToString().ToUpper();
                            }
                        }
                    }
                }

            }





            List<AnlasmaliSirketler> liste = new List<AnlasmaliSirketler>();
            Boolean deger = true;
            liste = dbProcess.AnlasmaliSirketlerSelect();

            for (int i = 0; i <= liste.Count - 1; i++)//şirket kodunun eşsiz olması için kontrol eder
            {
                AnlasmaliSirketler anlasmaliSirketler = new AnlasmaliSirketler(oteller);
                anlasmaliSirketler = liste[i];
                if (anlasmaliSirketler.sirketKodu == GuvenlikKodu)
                {

                    deger = false;
                }

            }
            if (deger == true)
            {
                txtSirketKodu.Text = GuvenlikKodu;
            }
        
        }
        
    }

    protected void btnSirketEkle_Click(object sender, EventArgs e)//şirket eklenir
    {
            Oteller oteller = new Oteller();

            AnlasmaliSirketler anlasmaliSirketler = new AnlasmaliSirketler(oteller)
            {
                ad = txtSirketAd.Text,
                adres = txtSirketAdres.Text,
                indirimYuzdesi = Convert.ToInt32(drpIndirimYuzdesi.Text),
                telefon = txtSirketTelefon.Text,
                sirketKodu = txtSirketKodu.Text,
                otelID = 1


            };
            dbProcess.AnlasmaliSirketlerInsert(anlasmaliSirketler);
            txtSirketAd.Text = null;
            txtSirketTelefon.Text = null;
            txtSirketAdres.Text = null;


            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "2;url=anlasmaliSirketEkle.aspx";
            this.Page.Controls.Add(meta);
            lblOnay.Visible = true;
            lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
        }
}
