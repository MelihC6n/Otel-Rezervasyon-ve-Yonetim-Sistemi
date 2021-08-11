using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;
public partial class odaDuzenle : System.Web.UI.Page
{
    Oteller oteller = new Oteller();
    DbProcess dbProcess = new DbProcess();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "yönetici")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        txtTipAciklama.ReadOnly = true;
        if (Page.IsPostBack==false) //odatipleri ve oteldeki katlar dropdownlar a doldurulur
        {
            drpİslemYapilanKat.Items.Insert(0, "Kat Seçiniz");
            drpİslemYapilanOda.Items.Insert( 0,"Oda Seçiniz");
            drpOdaTip.Items.Insert(0, "Tip Seçiniz");
            OdaTip odaTip = new OdaTip(oteller);
            Odalar odalar = new Odalar(oteller, odaTip);
            List<Odalar> katlarliste = new List<Odalar>();
            katlarliste = dbProcess.katGetir();
            for (int i = 0; i <= katlarliste.Count - 1; i++)
            {
                odalar = katlarliste[i];
                drpİslemYapilanKat.Items.Add((odalar.kat).ToString());
            }


            List<OdaTip> odaTipleriList = new List<OdaTip>();
            odaTipleriList = dbProcess.tipAdlari(odaTip);

            for (int i=0;i<=odaTipleriList.Count-1;i++)
            {
                odaTip = odaTipleriList[i];
                drpOdaTip.Items.Add((odaTip.ad));

            }


        }
      


    }
  
    protected void drpİslemYapilanKat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpİslemYapilanKat.SelectedIndex != 0)//seçilen katdaki bulunan odalar dropdowna eklenir
        {
            drpİslemYapilanOda.Items.Clear();
            drpİslemYapilanOda.Items.Insert(0, "Oda Seçiniz");
            if (drpİslemYapilanKat.SelectedIndex != 0)
            {
                OdaTip odaTip = new OdaTip(oteller);

                Odalar odalar = new Odalar(oteller, odaTip);

                odalar.kat = int.Parse(drpİslemYapilanKat.Text);
                List<Odalar> odalarliste = new List<Odalar>();
                odalarliste = dbProcess.kataGoreOdalarGetir(odalar);

                for (int j = 0; j <= odalarliste.Count - 1; j++)
                {
                    odalar = odalarliste[j];
                    drpİslemYapilanOda.Items.Add((odalar.odaNo).ToString());
                }
            }
        }
        drpİslemYapilanOda.Text = null;
        drpOdaTip.Text = null;
        txtTipAciklama.Text = null;
    }

    protected void btnOdaDuzenle_Click(object sender, EventArgs e)//oda yapılan değişiklere göre update edilir
    {
        if (drpOdaTip.SelectedIndex == 0 && drpİslemYapilanOda.SelectedIndex == 0 && drpOdaTip.SelectedIndex == 0)
        {
            
        }
        else
        { 
        OdaTip odaTip = new OdaTip(oteller);
        odaTip.ad = drpOdaTip.Text;

        List<OdaTip> list = new List<OdaTip>();
        list = dbProcess.tipIDGetir(odaTip);
        odaTip = list[0];
        Odalar odalar = new Odalar(oteller, odaTip)
        {
            tipID = odaTip.id,
            odaNo=int.Parse(drpİslemYapilanOda.Text)
          
        };
        drpİslemYapilanKat.Text = null;
        drpİslemYapilanOda.Text = null;
        drpOdaTip.Text = null;
        txtTipAciklama.Text = null;

        dbProcess.OdalarUpdate(odalar);

        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "2;url=odaDuzenle.aspx";
        this.Page.Controls.Add(meta);
        lblOnay.Visible = true;
        lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
        }
    }

    protected void drpİslemYapilanOda_SelectedIndexChanged(object sender, EventArgs e)
    {
      //oda değiştirildiğinde o odanın verileri getirilir
            if (drpİslemYapilanOda.SelectedIndex != 0)
            {
                OdaTip odaTip = new OdaTip(oteller);
                Odalar odalar = new Odalar(oteller, odaTip);


                odalar.odaNo = int.Parse(drpİslemYapilanOda.Text);
                List<OdaTip> odatipcek = new List<OdaTip>();
                odatipcek = dbProcess.tipAdAra(odalar);

                odaTip = odatipcek[0];
                drpOdaTip.Text = odaTip.ad;
                txtTipAciklama.Text = odaTip.aciklama;
            }
    

    }

    protected void drpOdaTip_SelectedIndexChanged(object sender, EventArgs e)
    {//odatipi değiştilidiğinde o odaTiipinin verileri getirilir
        if (drpOdaTip.SelectedIndex != 0)
        {
            OdaTip odaTip = new OdaTip(oteller);
            odaTip.ad = drpOdaTip.Text;
            List<OdaTip> listAciklama = new List<OdaTip>();
            listAciklama = dbProcess.aciklamaAra(odaTip);

            odaTip = listAciklama[0];
            txtTipAciklama.Text = odaTip.aciklama;
        }
        else
        {
            txtTipAciklama.Text = "";
        }
       
    }
}