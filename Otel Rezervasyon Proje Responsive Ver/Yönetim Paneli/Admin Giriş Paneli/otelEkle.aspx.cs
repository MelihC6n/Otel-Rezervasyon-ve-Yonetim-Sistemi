using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;
public partial class OtelEkleme : System.Web.UI.Page
{
    DbProcess db = new DbProcess();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "admin")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
    }

    protected void btnOtelEkle_Click(object sender, EventArgs e)//default özelliklerle otel ekler
    {
        Oteller otel = new Oteller()
        {
            ad = txtad.Text,
            adres = TextBox1.Text,
            fax = TextBox2.Text,
            yildizSayisi = int.Parse(drpyildiz.SelectedValue)
        };
        db.OtellerInsert(otel);

        DbProcess dbProcess = new DbProcess();
        Oteller oteller = new Oteller();
        OtelOzellik otelOzellik = new OtelOzellik(oteller)
        {
            otelID = 1,
            fitness = false,
            internetErisimi = false,
            odaServisi = false,
            restoran = false,
            yuzmeHavuzu = false,
            saglikMerkezi = false,
            cocukTesisleri = false,
            otopark = false,
            toplantiOdasi = false,
            evcilHayvan = false,
            bar = false,
            havaalaniServisi = false,
            acikBufeKahvalti = false
        };
        dbProcess.OtelOzellikInsert(otelOzellik);

        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "2;url=otelEkle.aspx";
        this.Page.Controls.Add(meta);
        lblOnay.Visible = true;
        lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
    }
}