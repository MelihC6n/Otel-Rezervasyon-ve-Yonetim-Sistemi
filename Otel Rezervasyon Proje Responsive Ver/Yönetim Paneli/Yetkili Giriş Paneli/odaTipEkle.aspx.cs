using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;

public partial class odaTipEkle : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "yönetici")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
    }

    protected void btnTipEKle_Click1(object sender, EventArgs e)
    {
        if (Image1.ImageUrl != "")//girilen odatipini db'ye insert eder
        {
            lblResim.Visible = false;
            if (db.OdaTipAyniAddaVarMiSelect(txtTipAd.Text) == 0 && (radioDag.Checked == true || radioDeniz.Checked == true || radioOrman.Checked == true || radioSehir.Checked == true || radioYok.Checked == true))
            {
                Oteller oteller = new Oteller();
                OdaTip odaTip = new OdaTip(oteller)
                {
                    otelID = 1,
                    ad = txtTipAd.Text,
                    aciklama = txtTipAciklama.Text,
                    fiyat = Convert.ToDouble(txtFiyat.Text),
                    odaKapasite = Convert.ToInt32(txtKapasite.Text),
                    resimAd = Image1.ImageUrl
                };
                odaTip.id=db.OdaTipInsert(odaTip);
                OdaOzellik odaOzellik = new OdaOzellik(odaTip)
                {
                    tipID = odaTip.id,
                    klima = chkKlima.Checked,
                    sauna = chkSauna.Checked,
                    televizyon = chkTelevizyon.Checked,
                    sacKurutmaMakinasi = chkSacKurutmaMakinesi.Checked,
                    jakuzi = chkJakuzi.Checked,
                    sesYalitimi = chkSesYalitimi.Checked,
                    mutfak = chkMutfak.Checked,
                    balkon = chkBalkon.Checked

                };
                if (radioDeniz.Checked == true)
                {
                    odaOzellik.manzaraId = 1;
                }
                else if (radioOrman.Checked == true)
                {
                    odaOzellik.manzaraId = 2;
                }
                else if (radioDag.Checked == true)
                {
                    odaOzellik.manzaraId = 3;
                }
                else if (radioSehir.Checked == true)
                {
                    odaOzellik.manzaraId = 4;
                }
                else
                {
                    odaOzellik.manzaraId = 0;
                }
                db.OdaOzellikInsert(odaOzellik);
            }

            txtTipAd.Text = null;
            txtTipAciklama.Text = null;
            txtKapasite.Text = null;
            txtFiyat.Text = null;
            chkBalkon.Checked = false;
            chkJakuzi.Checked = false;
            chkKlima.Checked = false;
            chkMutfak.Checked = false;
            chkSacKurutmaMakinesi.Checked = false;
            chkSauna.Checked = false;
            chkSesYalitimi.Checked = false;
            chkTelevizyon.Checked = false;
            radioDag.Checked = false;
            radioDeniz.Checked = false;
            radioOrman.Checked = false;
            radioSehir.Checked = false;
            radioYok.Checked = false;

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "2;url=odaTipEkle.aspx";
            this.Page.Controls.Add(meta);
            lblOnay.Visible = true;
            lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
        }
        else
        {
            lblResim.Visible = true;
            lblResim.Text = "Lütfen resim seçiniz.";
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)//seçilen resmi sisteme yükler
    {
        string folderPath = Server.MapPath("~/Yönetim Paneli/images/onizlemeResimleri/");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        if (fuFotograf.PostedFile.ContentType == "image/jpeg" || fuFotograf.PostedFile.ContentType == "image/png")
        {
            if (fuFotograf.PostedFile.ContentLength < 2048000)//2mb'den büyük resimlerin engellemesi
            {
                lblResim.Visible = false;
                string isim = Guid.NewGuid().ToString();//benzersiz bir isim verir
                fuFotograf.SaveAs(Server.MapPath("~/Yönetim Paneli/images/onizlemeResimleri/") + isim + ".jpeg");
                Image1.ImageUrl = "~/Yönetim Paneli/images/onizlemeResimleri/" + isim + ".jpeg";
            }
        }
    }
}