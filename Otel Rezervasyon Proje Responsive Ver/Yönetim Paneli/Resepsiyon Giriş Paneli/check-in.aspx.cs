using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;

public partial class Yönetim_Paneli_Resepsiyon_Giriş_Paneli_check_in : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    Odalar idAlinanOda = new Odalar(null, null);
    Rezervasyon rezervasyon = new Rezervasyon(null, null);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "resepsiyon")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        string data = Request.QueryString["D"];//gelen bilgi hex ten stringe çevrilir
        string StrValue = "";
        while (data.Length > 0)
        {
            StrValue += System.Convert.ToChar(System.Convert.ToUInt32(data.Substring(0, 2), 16)).ToString();
            data = data.Substring(2, data.Length - 2);
        }
        string[] degerler = StrValue.Split('&');//string veri ayrıştırılır ve nesnelerine atanır.

        string[] ad = degerler[2].Split('=');
        txtAd.Text = ad[1];

        string[] soyad = degerler[3].Split('=');
        txtSoyad.Text = soyad[1];

        string[] telefon = degerler[4].Split('=');
        txtTelefon.Text = telefon[1];

        string[] gelis = degerler[0].Split('=');
        txtGelis.Text = gelis[1];

        string[] gidis = degerler[1].Split('=');
        txtGidis.Text = gidis[1];

        string[] indirim = degerler[5].Split('=');
        txtIndirim.Text = indirim[1];

        string[] odaIDal = degerler[6].Split('=');

        string[] rezID = degerler[7].Split('=');
        rezervasyon.id = Convert.ToInt32(rezID[1]);

        string[] ucret = degerler[8].Split('=');
        rezervasyon.ucret = Convert.ToDouble(ucret[1]);

        Odalar oda = new Odalar(null, null)
        {
            id = Convert.ToInt32(odaIDal[1])
        };
        idAlinanOda = oda;


        List<Odalar> odalar = new List<Odalar>();
        odalar = db.OdalarSelectTekOda(oda);//gelen odanın id sine göre bilgileri yerleştirilir
        oda = odalar[0];
        txtOda.Text = oda.odaNo.ToString();
        txtKat.Text = oda.kat.ToString();

        List<OdaTip> odaTipler = new List<OdaTip>();
        odaTipler = db.OdaTipFiyatSelect(oda);

        OdaTip odaTip = new OdaTip(null);
        odaTip = odaTipler[0];
        txtUcret.Text = rezervasyon.ucret.ToString();
    }

    protected void btnCheckInOnayla_Click(object sender, EventArgs e)
    {
        Konaklamalar konaklamalar = new Konaklamalar(null)
        {
            otelID = 1,
            ad = txtAd.Text,
            soyad = txtSoyad.Text,
            gelisTarihi = Convert.ToDateTime(txtGelis.Text),
            gidisTarihi = Convert.ToDateTime(txtGidis.Text),
            indirimOrani = Convert.ToInt32(txtIndirim.Text),
            kat = Convert.ToInt32(txtKat.Text),
            odaNo = Convert.ToInt32(txtOda.Text),
            tcKimlik = txtKimlik.Text,
            telefonNo = txtTelefon.Text,
            Ucret = Convert.ToDouble(txtUcret.Text)
        };

        db.KonaklamalarInsert(konaklamalar);//rezervasyonu yapılan kişi konaklamaya eklenerek check-in yapılmış olur

        db.RezervasyonCheckIn(rezervasyon);//kişi rezervasyonda isAsctivi false yapılarak tekrar check-in yapılması engellenir

        DateTime atananTarih = konaklamalar.gelisTarihi;
        while (atananTarih <= konaklamalar.gidisTarihi)
        {
            DolulukTakvimi dolulukTakvimi = new DolulukTakvimi()
            {
                odaID = idAlinanOda.id,
                doluTarih = atananTarih
            };
            atananTarih = atananTarih.AddDays(1);

            db.DolulukTakvimiInsert(dolulukTakvimi);
        }



        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "2;url=rezervasyonlar.aspx";
        this.Page.Controls.Add(meta);
        lblOnay.Visible = true;
        lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
    }
}