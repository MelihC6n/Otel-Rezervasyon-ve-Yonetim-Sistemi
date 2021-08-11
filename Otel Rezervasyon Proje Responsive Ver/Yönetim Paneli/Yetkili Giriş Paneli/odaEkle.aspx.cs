using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;

public partial class odaEkle : System.Web.UI.Page
{
    Oteller oteller = new Oteller();
    DbProcess dbProcess = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "yönetici")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        try {

            if (!IsPostBack)
            {

                drpOdaTip.Items.Clear();
                OdaTip odaTip = new OdaTip(oteller);
                Odalar odalar = new Odalar(oteller, odaTip);
                drpKatSayisi.Items.Insert(0, "Lütfen Kat Seçiniz");
                drpOdaTip.Items.Insert(0, "Lütfen Oda Tipini Seçiniz");
                List<OdaTip> odaTipleriList = new List<OdaTip>();
                odaTipleriList = dbProcess.tipAdlari(odaTip);

                for (int i = 0; i <= odaTipleriList.Count - 1; i++) //odatiplerinin bulunduğu dropdowna Tipleri yükler.
                {
                    odaTip = odaTipleriList[i];
                    drpOdaTip.Items.Add((odaTip.ad));

                }

            }
            
           
        }
        catch(Exception)
        {

        }


    }

    protected void btnOdaEkle_Click(object sender, EventArgs e)//seçilen kata, seçilen odaları, seçili tipe göre db'ye ekler
    {
            Oteller oteller = new Oteller();

            try
            {
                for (int i = 0; i < chkOdalar.Items.Count; i++)
                {
                    if (chkOdalar.Items[i].Selected)
                    {

                        OdaTip odaTip = new OdaTip(oteller);
                        odaTip.ad = drpOdaTip.Text;

                        List<OdaTip> list = new List<OdaTip>();
                        list = dbProcess.tipIDGetir(odaTip);
                        odaTip = list[0];

                        Odalar odalar = new Odalar(oteller, odaTip)
                        {
                            otelID = 1,
                            kat = int.Parse(drpKatSayisi.SelectedItem.Value),
                            odaNo = int.Parse(chkOdalar.Items[i].Text),
                            tipID = odaTip.id
                        };

                        dbProcess.OdalarInsert(odalar);
                    }
                }
            int secilichkbox = 0;
            while(chkOdalar.Items[secilichkbox] != null) //eklenen odaları checkboxlistten siler
            {
                if(chkOdalar.Items[secilichkbox].Selected)
                {
                    chkOdalar.Items.RemoveAt(secilichkbox);
                }
                else
                {
                    secilichkbox++;
                }
            }
            }
            catch (Exception)
            {

            }

        if(chkOdalar.Items.Count==0) // eklenecek oda kalmayınca bir sonraki kata geçilebilmesini sağlar.
        {
            drpKatSayisi.Items.RemoveAt(drpKatSayisi.SelectedIndex);
            drpKatSayisi.Enabled = true;
            btnOdaOnayla.Enabled = true;
            txtOdaSayisi.Enabled = true;
            txtOdaSayisi.Text = "";
        }
        if(chkOdalar.Items.Count==0 && drpKatSayisi.Items.Count==0)//tüm işlemler bitince yönlendirme
        {
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "2;url=Default.aspx";
            this.Page.Controls.Add(meta);
            lblOnay.Visible = true;
            lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
        }

        }
        


  

    protected void drpOdaTip_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpOdaTip.SelectedIndex != 0) //odatipinin bilgisini getirir
            {
                OdaTip odaTipp = new OdaTip(oteller);
                odaTipp.ad = drpOdaTip.Text;
                List<OdaTip> listAciklama = new List<OdaTip>();
                listAciklama = dbProcess.aciklamaAra(odaTipp);

                odaTipp = listAciklama[0];
                txtTipAciklama.Text = odaTipp.aciklama;
            }
            else
            {
                txtTipAciklama.Text = "";
            }
        }
        catch(Exception)
        {

        }
    }

    protected void btnKatOnayla_Click(object sender, EventArgs e) //kat ekler.
    {
        try
        {

            drpKatSayisi.Items.Clear();
            if (txtKatSayisi.Text != null)
            {
                txtKatSayisi.Enabled = false;
                btnKatOnayla.Enabled = false;

                for (int i = 1; i <= int.Parse(txtKatSayisi.Text); i++)
                {
                    drpKatSayisi.Items.Add(i.ToString());

                }
            }
        }
        catch(Exception)
        {

        }
    }

    protected void btnOdaOnayla_Click(object sender, EventArgs e) //seçili kata istenen sayıda oda ekler
    {
        try
        {
            chkOdalar.Items.Clear();


            if (txtOdaSayisi.Text != "")
            {
                txtOdaSayisi.Enabled = false;
                btnOdaOnayla.Enabled = false;
                drpKatSayisi.Enabled = false;

                for (int i = 1; i <= Convert.ToInt32(txtOdaSayisi.Text); i++)
                {

                    chkOdalar.Items.Add((Convert.ToInt32(drpKatSayisi.SelectedItem.Text) * 100 + i).ToString());


                }
            }
        }
        catch
        {

        }
    }

    protected void drpKatSayisi_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkOdalar.Items.Clear();
        if (drpKatSayisi.SelectedIndex != 0)
        {
            txtKatSayisi.ReadOnly = true;
        }
    }
}