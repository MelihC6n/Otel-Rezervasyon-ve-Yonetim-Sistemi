using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Data.SqlClient;

public partial class rezervasyonBilgileri : System.Web.UI.Page
{
    int kisiSayac;//eklenen kisileri atlamak için
    OdaTip odaTipi;
    Rezervasyon rezervasyon;
    Rezervasyon rezervasyonGir;//eklenecek rezervasyon
    DbProcess db = new DbProcess();

    protected void Page_Load(object sender, EventArgs e)
    {
        kisiSayac = 1;

        if(!Page.IsPostBack)
        {
            drpUlke.SelectedValue = "Türkiye";
            drpUyruk.SelectedValue = "Türkiye";
        }


        if(Request.QueryString["D2"]!=null)//beraber eklenirken önceki kişinin bilgileri(odaid,rezervasyonkodu,gelis ve gidis tarihleri)
        {                                   // ile aynı olması için gönderilen D2 varmı diye bakar varsa yeni kişi aynı rezervasyon tarihve odalarla yüklenir
            string data = Request.QueryString["D2"];
            string StrValue = "";
            if (data == null)
            {
                Response.Redirect("Default.aspx");
            }
            while (data.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(data.Substring(0, 2), 16)).ToString();
                data = data.Substring(2, data.Length - 2);
            }
            string[] degerler = StrValue.Split('&');

            string[] odaID = degerler[0].Split('=');

            string[] fiyat = degerler[1].Split('=');

            string[] indirim = degerler[2].Split('=');

            string[] rezervasyonKodDizi = degerler[3].Split('=');

            string[] gelis = degerler[4].Split('=');

            string[] gidis = degerler[5].Split('=');

            string[] kisiSayacDizi = degerler[6].Split('=');

            string[] kapasite = degerler[7].Split('=');

            rezervasyon = new Rezervasyon(null, null)
            {
                indirimOrani = Convert.ToInt32(indirim[1]),  //indirim yerine fiyat geliyor
                gelisTarihi = Convert.ToDateTime(gelis[1]),
                gidisTarihi = Convert.ToDateTime(gidis[1]),
                ucret = Convert.ToDouble(fiyat[1]),
                odaID = Convert.ToInt32(odaID[1]),
                rezervasyonKodu = (rezervasyonKodDizi[1])
            };
            odaTipi = new OdaTip(null)
            {
                odaKapasite = Convert.ToInt32(kapasite[1])
            };

            kisiSayac = Convert.ToInt32(kisiSayacDizi[1]);
            lblKisiBilgisiSayac.Text = kisiSayac.ToString();
            txtGelis.Text = rezervasyon.gelisTarihi.ToShortDateString();
            txtGidis.Text = rezervasyon.gidisTarihi.ToShortDateString();
            txtIndirim.Text = rezervasyon.indirimOrani.ToString();
            txtFiyat.Text = rezervasyon.ucret.ToString();
        }
        else
        { 
        string data = Request.QueryString["D"];//burası odalar.aspx den ilk gelen odatipi,ücret,gelis giidis tarihlerinin alındığı kısım
        string StrValue = "";
        if (data == null)
        {
            Response.Redirect("Default.aspx");
        }
        while (data.Length > 0)
        {
            StrValue += System.Convert.ToChar(System.Convert.ToUInt32(data.Substring(0, 2), 16)).ToString();
            data = data.Substring(2, data.Length - 2);
        }
        string[] degerler = StrValue.Split('&');

        string[] odaTip = degerler[0].Split('=');

        string[] fiyat = degerler[1].Split('=');

        string[] indirim = degerler[2].Split('=');

        string[] kapasite = degerler[3].Split('=');

        string[] gelis = degerler[4].Split('=');

        string[] gidis = degerler[5].Split('=');

        odaTipi = new OdaTip(null)
        {
            odaKapasite = Convert.ToInt32(kapasite[1]),
            ad = Convert.ToString(odaTip[1])
        };
        rezervasyon = new Rezervasyon(null, null)
        {
            indirimOrani = Convert.ToInt32(indirim[1]),
            gelisTarihi = Convert.ToDateTime(gelis[1]),
            gidisTarihi = Convert.ToDateTime(gidis[1]),
            ucret = Convert.ToDouble(fiyat[1])
        };
        txtGelis.Text = rezervasyon.gelisTarihi.ToShortDateString();
        txtGidis.Text = rezervasyon.gidisTarihi.ToShortDateString();
        txtIndirim.Text = rezervasyon.indirimOrani.ToString();
        txtFiyat.Text = rezervasyon.ucret.ToString();
        lblKisiBilgisiSayac.Text = kisiSayac.ToString();
        }
    }

    protected void OnaylaClick(object sender, EventArgs e)
    {
        if (txtAd.Text != "" && txtSoyad.Text != "" && txtEposta.Text != "" && txtCepTel.Text != "" && (radErkek.Checked == true || radKadin.Checked == true))
        {
            List<Odalar> odalarList = new List<Odalar>();

            if (kisiSayac == 1)
            {
                odalarList = db.OdaMusaitlikDogrula(rezervasyon, odaTipi);//ilk kişi eklenirken o anda istenen oda tipi başka biryerde dolmuş olabilir
                if (odalarList.Count == 0)                              //istenen oda tipinde hala boş oda olduğunu onaylamak için tekrar kontrol edilir.
                {                                       
                    Response.Redirect("Default.aspx");
                }
                rezervasyon.odaID = odalarList[0].id;//hala istenen oda tipinde boş odalar varsa bir oda kişiye atanır.

                while (rezervasyon.rezervasyonKodu == "" || rezervasyon.rezervasyonKodu==null)//random bir rezervasyon kodu oluşturulur
                {
                    int harf, bykharf, hangisi;
                    Random Rharf = new Random();
                    Random Rsayi = new Random();
                    Random Rbykharf = new Random();
                    Random Rhangisi = new Random();
                    for (int b = 0; b < 8; b++)
                    {
                        int a = 0;
                        hangisi = Rhangisi.Next(1, 3);
                        if (hangisi == 1)
                        {
                            rezervasyon.rezervasyonKodu += Rsayi.Next(0, 10).ToString();
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
                                        rezervasyon.rezervasyonKodu += i;
                                    }
                                    if (bykharf == 2)
                                    {
                                        rezervasyon.rezervasyonKodu += i.ToString().ToUpper();
                                    }
                                }
                            }
                        }
                    }
                    Rezervasyon rezervasyonKoduAra = new Rezervasyon(null, null)
                    {
                        rezervasyonKodu = rezervasyon.rezervasyonKodu
                    };
                    List<Rezervasyon> rezervasyons = new List<Rezervasyon>();
                    rezervasyons = db.RezervasyonSorgulaSelect(rezervasyonKoduAra);//rezervasyon kodunun eşsiz olması için db'de sorgu
                    if (rezervasyons.Count > 0)
                    {
                        rezervasyon.rezervasyonKodu = "";
                    }
                }

                DateTime atananTarih = rezervasyon.gelisTarihi;
                while (atananTarih <= rezervasyon.gidisTarihi)//istenen odatipinde bulunan odanın seçili rezervasyon tarihleri arasında doluluk takvimine kaydı yapılır
                {
                    DolulukTakvimi dolulukTakvimi = new DolulukTakvimi()
                    {
                        odaID = odalarList[0].id,
                        doluTarih = atananTarih
                    };
                    atananTarih = atananTarih.AddDays(1);

                    db.DolulukTakvimiInsert(dolulukTakvimi);
                }

            }

            if (kisiSayac <= odaTipi.odaKapasite)//kişilerin kişi sayısı kadar sürekli kaydı yapılır
            {

                Musteri musteri = new Musteri(null)
                {
                    ad = txtAd.Text,
                    soyad = txtSoyad.Text,
                    ePosta = txtEposta.Text,
                    cepTelefon = txtCepTel.Text,
                    ulke = drpUlke.SelectedItem.ToString(),
                    uyruk = drpUyruk.SelectedItem.ToString()
                };
                if (radErkek.Checked == true)
                {
                    musteri.cinsiyet = true;
                }
                else
                {
                    musteri.cinsiyet = false;
                }

                int musteriID;

                musteriID = db.MusteriIdGetirInsert(musteri);

                rezervasyonGir = new Rezervasyon(musteri, null)
                {
                    gelisTarihi = Convert.ToDateTime(Convert.ToDateTime(txtGelis.Text).ToShortDateString()),
                    gidisTarihi = Convert.ToDateTime(Convert.ToDateTime(txtGidis.Text).ToShortDateString()),
                    indirimOrani = Convert.ToInt32(txtIndirim.Text),
                    ucret = Convert.ToDouble(txtFiyat.Text),
                    musteriID = musteriID,
                    rezervasyonKodu = rezervasyon.rezervasyonKodu,
                    rezervasyonTarihi=DateTime.Now.ToString("yyyy-MM-dd"),
                    odaID= rezervasyon.odaID
                };

                db.RezervasyonInsert(rezervasyonGir);

                if (kisiSayac < odaTipi.odaKapasite)//hala eklenecek kişiler varsa ekleme yapıldıktan sonra sayfa yenilenmesi sonucu sonraki kişilere
                {                                // yeni oda ve farklı rezervasyyon kodu verilmesini önlemek için mevcut eklenen kişinin rezervasyon bilgileri sayfaya 'D2' olarak yeniden yönlendirilir
                    kisiSayac++;
                    string data = "OdaID=" + rezervasyonGir.odaID + "&Fiyat=" + rezervasyonGir.ucret + "&IndirimOrani=" + rezervasyonGir.indirimOrani + "&RezervasyonKodu=" + rezervasyonGir.rezervasyonKodu + "&GelisTarihi=" + rezervasyonGir.gelisTarihi + "&GidisTarihi=" + rezervasyonGir.gidisTarihi + "&KisiSayac=" + kisiSayac + "&OdaKapasite=" + odaTipi.odaKapasite;
                    string hex = "";
                    foreach (char c in data)
                    {
                        int tmp = c;
                        hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
                    }
                    Response.Redirect("rezervasyonBilgileri.aspx?D2=" + hex);
                }
            }

            if (kisiSayac == odaTipi.odaKapasite)//son kişi de eklendiğinde rezervasyon kodu ile RezervasyonOnayi.aspx ' e yönlendirilir.
            {
                string data = rezervasyonGir.rezervasyonKodu;
                string hex = "";
                foreach (char c in data)
                {
                    int tmp = c;
                    hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
                }
                Response.Redirect("RezervasyonOnayi.aspx?D=" + hex);
            }


        }
    }
    protected void IptalClick(object sender, EventArgs e)
    {
        if(rezervasyon.rezervasyonKodu!=null)
        {
            db.RezervasyonDelete(rezervasyon);
            DolulukTakvimi dolulukTakvimi = new DolulukTakvimi()
            {
                odaID = rezervasyon.odaID
            };
            db.DolulukTakvimiDelete(dolulukTakvimi, rezervasyon.gelisTarihi, rezervasyon.gidisTarihi);//iptal edilen rezervasyondaki odayı rezervasyon tarihlerinde doluluk takviminden siler
        }
        Response.Redirect("Default.aspx");

    }
}