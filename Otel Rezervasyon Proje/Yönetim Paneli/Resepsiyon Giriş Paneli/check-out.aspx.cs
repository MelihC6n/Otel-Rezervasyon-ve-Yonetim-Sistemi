using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Yönetim_Paneli_Resepsiyon_Giriş_Paneli_check_out : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "resepsiyon")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        if (Page.IsPostBack != true)
        {
        kisiBilgiGoster();
        digerKisileriGoster();
        lblUcretKontrol.Visible = false;
        lblHata.Visible = false;
        lblOnay.Visible = false;
        txtCheckOutMisafirAlınanUCret.Enabled = true;
        }
        
    }
    protected void btnUcretAl_Click(object sender, EventArgs e)
    {
        if (txtCheckOutMisafirAlınanUCret.Text.Length > 0)//ucret alınma kısmına bir miktar girildi ise işlem yapar
        {
            lblUcretKontrol.Visible = false;
            //ödenen ücret ödenecek ücreti aşmıyorsa işlem yapar
            if ((Convert.ToDouble(txtCheckOutMisafirToplamUCret.Text)) - (Convert.ToDouble(txtCheckOutMisafirAlınanUCret.Text)) >= 0)
            {
                lblHata.Visible = false;
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {
                    odaNo = Convert.ToInt32(txtCheckOutMisafirOdaNo.Text),
                    alinanUcret = (Convert.ToDouble(txtCheckOutMisafirToplamUCret.Text)) - (Convert.ToDouble(txtCheckOutMisafirAlınanUCret.Text))
                };
                db.KonaklamalarUpdate(konaklamalar);
                kisiBilgiGosterUcretAlindiktanSonra();
                txtCheckOutMisafirAlınanUCret.Text = "";
            }
            else
            {
                lblHata.Visible = true;
                lblHata.Text = "Odenecek toplam ucret aşılamaz.";
            }
        }
        else
        {
            lblUcretKontrol.Visible = true;
            lblUcretKontrol.Text = "Miktar belirtmediniz.";
            lblHata.Visible = false;
        }
    }

    void kisiBilgiGoster()
    {
        string data = Request.QueryString["D"];//sayfaya gelen bilgileri hex' ten stringe çevirir ve nesnelere yerleştirilir
        if (data != null)
        {
            string StrValue = "";
            while (data.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(data.Substring(0, 2), 16)).ToString();
                data = data.Substring(2, data.Length - 2);
            }
            string[] degerler = StrValue.Split('&');

            string[] tcKimlik = degerler[0].Split('=');
            Konaklamalar konaklama = new Konaklamalar(null)
            {
                tcKimlik = tcKimlik[1],               
            };
            List<Konaklamalar> checkOut = new List<Konaklamalar>();
            checkOut = db.odaBulunanKonaklamalarSelectCheckOut(konaklama);

            konaklama = checkOut[0];
            txtCheckOutMisafirAd.Text = konaklama.ad.ToString();
            txtCheckOutMisafirGelisTarihi.Text = konaklama.gelisTarihi.ToString().Substring(0, 9);
            txtCheckOutMisafirGidisTarihi.Text = konaklama.gidisTarihi.ToString().Substring(0, 10);
            txtCheckOutMisafirOdaNo.Text = konaklama.odaNo.ToString();
            txtCheckOutMisafirSoyad.Text = konaklama.soyad.ToString();
            txtCheckOutMisafirTelefon.Text = konaklama.telefonNo.ToString();
            txtCheckOutMisafirToplamUCret.Text = konaklama.Ucret.ToString();
            txtKimlikNo.Text = konaklama.tcKimlik.ToString();
        }
    }
    void digerKisileriGoster()//işlem yapılan kişi dışında o odada kalan diğer kişileri yan kısımda gösterir
    {
        string data = Request.QueryString["D"];
        if (data != null)
        {
            string StrValue = "";
            while (data.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(data.Substring(0, 2), 16)).ToString();
                data = data.Substring(2, data.Length - 2);
            }
            string[] degerler = StrValue.Split('&');

            string[] tcKimlik = degerler[0].Split('=');
            string[] odaNo = degerler[1].Split('=');
            Konaklamalar digerKisiler = new Konaklamalar(null)
            {
                tcKimlik = tcKimlik[1],
                odaNo = Convert.ToInt32(odaNo[1])
            };
            List<Konaklamalar> odadaKalanDİgerKisileriGetir = new List<Konaklamalar>();
            odadaKalanDİgerKisileriGetir = db.odadaBulunanDigerKisileriGetir(digerKisiler);

            if(odadaKalanDİgerKisileriGetir.Count>0)
            { 
            digerKisiler = odadaKalanDİgerKisileriGetir[0];            
            rptDigerKisiler.DataSource = odadaKalanDİgerKisileriGetir;
            rptDigerKisiler.DataBind();
            }
        }
    }
    protected void rptDigerKisiler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Cikis")//odada kalan diğer kişilerden tıklananı işlem yapılan kişi kısmına alır
        {
            lblOnay.Visible = false;
            Konaklamalar digerKisilerdenGelenBigi = new Konaklamalar(null)
            {
                tcKimlik = Convert.ToString(e.CommandArgument)
            };
            List<Konaklamalar> digerKisiBilgi = new List<Konaklamalar>();
            digerKisiBilgi = db.odaBulunanKonaklamalarSelectCheckOut(digerKisilerdenGelenBigi);

            digerKisilerdenGelenBigi = digerKisiBilgi[0];
            txtCheckOutMisafirAd.Text = digerKisilerdenGelenBigi.ad.ToString();
            txtCheckOutMisafirGelisTarihi.Text = digerKisilerdenGelenBigi.gelisTarihi.ToString().Substring(0, 9);
            txtCheckOutMisafirGidisTarihi.Text = digerKisilerdenGelenBigi.gidisTarihi.ToString().Substring(0, 10);
            txtCheckOutMisafirOdaNo.Text = digerKisilerdenGelenBigi.odaNo.ToString();
            txtCheckOutMisafirSoyad.Text = digerKisilerdenGelenBigi.soyad.ToString();
            txtCheckOutMisafirTelefon.Text = digerKisilerdenGelenBigi.telefonNo.ToString();
            txtCheckOutMisafirToplamUCret.Text = digerKisilerdenGelenBigi.Ucret.ToString();
            txtKimlikNo.Text = digerKisilerdenGelenBigi.tcKimlik.ToString();


            List<Konaklamalar> digerKisiGetir = new List<Konaklamalar>();
            digerKisiGetir = db.odadaBulunanDigerKisileriGetir2(int.Parse(txtCheckOutMisafirOdaNo.Text), e.CommandArgument.ToString());
            rptDigerKisiler.DataSource = digerKisiGetir;
            rptDigerKisiler.DataBind();
            
        }
    }
    void temizle()
    {
        txtKimlikNo.Text = "";
        txtCheckOutMisafirToplamUCret.Text = "";
        txtCheckOutMisafirTelefon.Text = "";
        txtCheckOutMisafirSoyad.Text = "";
        txtCheckOutMisafirOdaNo.Text = "";
        txtCheckOutMisafirGidisTarihi.Text = "";
        txtCheckOutMisafirGelisTarihi.Text = "";
        txtCheckOutMisafirAlınanUCret.Text = "";
        txtCheckOutMisafirAd.Text = "";
    }
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        if (rptDigerKisiler.Items.Count == 0 && Convert.ToDouble(txtCheckOutMisafirToplamUCret.Text) > 0)//odada kalan son kişi ücreti ödemedii sürece çıkış verilmez
        {
            lblHata.Visible = true;
            lblHata.Text = "Ücret almadınız.Çıkış onaylanmadı.";
        }
        else if ((txtCheckOutMisafirToplamUCret.Text == "" || Convert.ToDouble(txtCheckOutMisafirToplamUCret.Text) == 0) && rptDigerKisiler.Items.Count == 0)
        {
            Konaklamalar misafirCikisVer = new Konaklamalar(null)
            {
                tcKimlik = txtKimlikNo.Text
            };
            db.KonaklamalarDelete(misafirCikisVer);

            Odalar odalar = new Odalar(null, null)
            {
                odaNo = Convert.ToInt32(txtCheckOutMisafirOdaNo.Text)
            };

            List<Konaklamalar> konaklamalarListele = new List<Konaklamalar>();
            konaklamalarListele = db.odaBulunanKonaklamalarSelect(odalar.odaNo);

            DolulukTakvimi dolulukTakvimi = new DolulukTakvimi()
            {
                odaID = db.OdalarNoyuIdyeCevir(odalar).id
            };

            if (konaklamalarListele.Count >= 0)//odada kalan son kişi de çıkış yaptığında erken çıkışta oda dolalık takviminde gereksiz dolu gözükmesini önlemek için 
            {                                  //çıkıştan bir sonraki günden başlanarak odada kalan kişilerin normal çıkış tarihine kadar odayı doluluk takviminden silerek boş gösterir
                db.DolulukTakvimiDelete(dolulukTakvimi, DateTime.Today.AddDays(1), Convert.ToDateTime(txtCheckOutMisafirGidisTarihi.Text));
            }

            lblOnay.Visible = true;
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "3;url=konaklamalar.aspx";
            this.Page.Controls.Add(meta);
            lblOnay.Text = "İşlem gerçekleştirildi.3 saniye sonra Konaklamalar sayfasına yönlendiriliyorsunuz.";
        }
        else
        {
            lblHata.Visible = false;
            Konaklamalar misafirCikisVer = new Konaklamalar(null)
            {
                tcKimlik = txtKimlikNo.Text
            };
            db.KonaklamalarDelete(misafirCikisVer);
            lblOnay.Visible = true;
            lblOnay.Text = "İşlem gerçekleştirildi.";
            temizle();
        }
    }
    void kisiBilgiGosterUcretAlindiktanSonra()//ücret alınınca verilerin yenilenmesi için
    {
        List<Konaklamalar> kisiBilgiSelectUcretAlindiktanSonra = new List<Konaklamalar>();
        Konaklamalar konaklama = new Konaklamalar(null) 
        {
        tcKimlik=txtKimlikNo.Text
        };

        kisiBilgiSelectUcretAlindiktanSonra = db.ucretAlindiktanSonraKisiBilgi(konaklama);

        konaklama = kisiBilgiSelectUcretAlindiktanSonra[0];
        txtCheckOutMisafirAd.Text = konaklama.ad.ToString();
        txtCheckOutMisafirGelisTarihi.Text = konaklama.gelisTarihi.ToString().Substring(0, 9);
        txtCheckOutMisafirGidisTarihi.Text = konaklama.gidisTarihi.ToString().Substring(0, 10);
        txtCheckOutMisafirOdaNo.Text = konaklama.odaNo.ToString();
        txtCheckOutMisafirSoyad.Text = konaklama.soyad.ToString();
        txtCheckOutMisafirTelefon.Text = konaklama.telefonNo.ToString();
        txtCheckOutMisafirToplamUCret.Text = konaklama.Ucret.ToString();
        txtKimlikNo.Text = konaklama.tcKimlik.ToString();

    }
}