using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;

public partial class rezervasyonSorgulama : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        txtRezervasyonSorgula.Focus();
        btnRezervasyonIptal.Visible = false;
       
    }
    DbProcess db = new DbProcess();
    protected void rezervasyonSorgula(object sender, EventArgs e)//rezervsayonu sorgular
    {
        Rezervasyon rez = new Rezervasyon(null,null) 
        {
         rezervasyonKodu=txtRezervasyonSorgula.Text
        };

        List<Rezervasyon> rezervasyonGetir = new List<Rezervasyon>();
        rezervasyonGetir = db.RezervasyonSorgulaSelect(rez);

        rptRezervasyonGetir.DataSource = rezervasyonGetir;
        rptRezervasyonGetir.DataBind();

        if (rezervasyonGetir.Count > 0)
        {
            btnRezervasyonIptal.Visible = true;
            lbl.Visible = true;
            lblRezKod.Visible = true;
            lblRezKod.Text = txtRezervasyonSorgula.Text;
        }
        else {
            txtRezervasyonSorgula.Text = "";
            btnRezervasyonIptal.Visible = false;
            lbl.Visible = false;
            lblRezKod.Visible = false;
        }        
    }
    protected void btnRezervasyonIptalOlay(object sender, EventArgs e)//rezervasyonu siler
    {
        Rezervasyon rez = new Rezervasyon(null, null)
        {
            rezervasyonKodu = lblRezKod.Text
        };
        List<Rezervasyon> rezervasyonGetir = new List<Rezervasyon>();
        rezervasyonGetir = db.RezervasyonSorgulaSelect(rez);
        rez.odaID = rezervasyonGetir[0].odaID;
        rez.gelisTarihi= rezervasyonGetir[0].gelisTarihi;
        rez.gidisTarihi= rezervasyonGetir[0].gidisTarihi;
        DolulukTakvimi dolulukTakvimi = new DolulukTakvimi()
        {
            odaID = rez.odaID
        };
        db.DolulukTakvimiDelete(dolulukTakvimi, rez.gelisTarihi, rez.gidisTarihi);//silinen rezervasyondaki odayı rezervasyon tarihlerinde doluluk takviminden siler

        db.RezervasyonDelete(rez);



        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "2;url=rezervasyonSorgulama.aspx";
        this.Page.Controls.Add(meta);
        lblOnay.Visible = true;
        lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
    }

}