using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Web.UI.HtmlControls;

public partial class otelKur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "yönetici")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        if (!IsPostBack)
            {//default olarak eklenen özelliklerini getirir
        DbProcess dbProcess = new DbProcess();
        Oteller oteller = new Oteller();
        OtelOzellik otelOzellik = new OtelOzellik(oteller);
        List<OtelOzellik> liste = new List<OtelOzellik>();
        liste = dbProcess.OtelOzellikSelect();
        otelOzellik = liste[0];
        chkFitness.Checked = otelOzellik.fitness;
        chkInternetErisim.Checked = otelOzellik.internetErisimi;
        chkOdaServisi.Checked = otelOzellik.internetErisimi;
        chkRestoran.Checked = otelOzellik.restoran;
        chkYuzmeHavuzu.Checked = otelOzellik.yuzmeHavuzu;
        chkSaglikMerkezi.Checked = otelOzellik.saglikMerkezi;
        chkCocukTesisleri.Checked = otelOzellik.cocukTesisleri;
        chkOtopark.Checked = otelOzellik.otopark;
        chkToplantiOdasi.Checked = otelOzellik.toplantiOdasi;
        chkEvcilHayvan.Checked = otelOzellik.evcilHayvan;
        chkBar.Checked = otelOzellik.bar;
        chkHavaalanıServisi.Checked = otelOzellik.havaalaniServisi;
        chkAcikBufeKahvalti.Checked = otelOzellik.acikBufeKahvalti;
         }

    }
    protected void btnOtelKur_Click(object sender, EventArgs e)//otel girilen özelliklere göre update edilir
    {
        DbProcess dbProcess = new DbProcess();
        Oteller oteller = new Oteller();
        OtelOzellik otelOzellik = new OtelOzellik(oteller)
        {
            otelID = 1,
            fitness = Convert.ToBoolean(chkFitness.Checked),
            internetErisimi = Convert.ToBoolean(chkInternetErisim.Checked),
            odaServisi = Convert.ToBoolean(chkOdaServisi.Checked),
            restoran = Convert.ToBoolean(chkRestoran.Checked),
            yuzmeHavuzu = Convert.ToBoolean(chkYuzmeHavuzu.Checked),           
            saglikMerkezi = Convert.ToBoolean(chkSaglikMerkezi.Checked),
            cocukTesisleri = Convert.ToBoolean(chkCocukTesisleri.Checked),
            otopark = Convert.ToBoolean(chkOtopark.Checked),
            toplantiOdasi = Convert.ToBoolean(chkToplantiOdasi.Checked),
            evcilHayvan = Convert.ToBoolean(chkEvcilHayvan.Checked),
            bar = Convert.ToBoolean(chkBar.Checked),
            havaalaniServisi= Convert.ToBoolean(chkHavaalanıServisi.Checked),
            acikBufeKahvalti= Convert.ToBoolean(chkAcikBufeKahvalti.Checked)
        };
        dbProcess.OtelOzellikUpdate(otelOzellik);


        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "2;url=otelKur.aspx";
        this.Page.Controls.Add(meta);
        lblOnay.Visible = true;
        lblOnay.Text = "İşleminiz tamamlandı , 2 saniye sonra yönlendirileceksiniz.";
    }
}