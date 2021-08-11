using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;

public partial class Kullanıcı_Sayfası_RezervasyonOnayi : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        //gelen rezervasyon koduna göre rezervsayon bilgilerini kullanıcıya sunar
        string data = Request.QueryString["D"];
        string rezKod = "";
        if (data == null)
        {
            Response.Redirect("Default.aspx");
        }
        while (data.Length > 0)
        {
            rezKod += System.Convert.ToChar(System.Convert.ToUInt32(data.Substring(0, 2), 16)).ToString();
            data = data.Substring(2, data.Length - 2);
        }

        Rezervasyon rez = new Rezervasyon(null, null)
        {
            rezervasyonKodu = rezKod
        };

        List<Rezervasyon> rezervasyonGetir = new List<Rezervasyon>();
        rezervasyonGetir = db.RezervasyonSorgulaSelect(rez);

        rptRezervasyonGetir.DataSource = rezervasyonGetir;
        rptRezervasyonGetir.DataBind();

        lblRezKod.Text = rez.rezervasyonKodu;
    }
    protected void AnaSayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}