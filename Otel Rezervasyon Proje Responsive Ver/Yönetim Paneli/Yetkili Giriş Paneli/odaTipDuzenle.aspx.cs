using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class odaTipDuzenleme : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "yönetici")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        if (!IsPostBack)//odatiplerini dropdown a ekler
        {
            drpTip.Items.Add("Düzenlenecek Oda Tipini Seçininiz..");
            Oteller oteller = new Oteller();
            oteller.id = 1;
            List<OdaTip> listOdaTip = new List<OdaTip>();
            listOdaTip = db.OdaTipSelectOtelID(oteller);
            for (int i = 0; i < listOdaTip.Count; i++)
            {
                OdaTip odaTipEkle = new OdaTip(null);
                odaTipEkle = listOdaTip[i];
                drpTip.Items.Add(odaTipEkle.ad);
            }
        }
    }

    protected void drpTip_SelectedIndexChanged(object sender, EventArgs e)
    {//odatipi değiştirildiğine o odatipinin verileri getirir ve nesnelerin mevcut durumları sıfırlanır

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

        if (drpTip.SelectedIndex != 0)
        {
            Oteller oteller = new Oteller();
            oteller.id = 1;
            OdaTip odaTipEkle = new OdaTip(null);
            odaTipEkle.ad = drpTip.Text;

            List<OdaTip> listOdaTip = new List<OdaTip>();
            listOdaTip = db.OdaTipSelectTipAd(odaTipEkle);
            odaTipEkle = listOdaTip[0];
            txtTipAd.Text = odaTipEkle.ad;
            txtTipAciklama.Text = odaTipEkle.aciklama;
            txtKapasite.Text = odaTipEkle.odaKapasite.ToString();
            txtFiyat.Text = odaTipEkle.fiyat.ToString();
            odaTipFotograf.ImageUrl = odaTipEkle.resimAd;

            List<OdaOzellik> listOdaOzellik = new List<OdaOzellik>();
            listOdaOzellik = db.OdaOzellikSelectOdaTipID(odaTipEkle);
            OdaOzellik odaOzellikEkle = new OdaOzellik(null);
            odaOzellikEkle = listOdaOzellik[0];
            chkKlima.Checked = odaOzellikEkle.klima;
            chkSauna.Checked = odaOzellikEkle.sauna;
            chkTelevizyon.Checked = odaOzellikEkle.televizyon;
            chkSacKurutmaMakinesi.Checked = odaOzellikEkle.sacKurutmaMakinasi;
            chkJakuzi.Checked = odaOzellikEkle.jakuzi;
            chkSesYalitimi.Checked = odaOzellikEkle.sesYalitimi;
            chkMutfak.Checked = odaOzellikEkle.mutfak;
            chkBalkon.Checked = odaOzellikEkle.balkon;

            if (odaOzellikEkle.manzaraId == 0)
            {
                radioYok.Checked = true;
            }
            else if (odaOzellikEkle.manzaraId == 1)
            {
                radioDeniz.Checked = true;
            }
            else if (odaOzellikEkle.manzaraId == 2)
            {
                radioOrman.Checked = true;
            }
            else if (odaOzellikEkle.manzaraId == 3)
            {
                radioDag.Checked = true;
            }
            else if (odaOzellikEkle.manzaraId == 4)
            {
                radioSehir.Checked = true;
            }

        }
    }

    protected void btnTipDuzenle_Click(object sender, EventArgs e)
    {
            if (odaTipFotograf.ImageUrl != "")//odatipini update eder
            {

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
                        resimAd = odaTipFotograf.ImageUrl
                    };
                    db.OdaTipUpdate(odaTip, drpTip.Text);
                    odaTip.id = db.odaTipIDBul(odaTip);
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
                    else if (radioYok.Checked == true)
                    {
                        odaOzellik.manzaraId = 0;
                    }
                    db.OdaOzellikUpdate(odaOzellik);
                }

                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "2;url=odaTipDuzenle.aspx";
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
                odaTipFotograf.ImageUrl = "~/Yönetim Paneli/images/onizlemeResimleri/" + isim + ".jpeg";
            }
        }
    }
}