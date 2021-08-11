using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.Data.SqlClient;
public partial class Yönetim_Paneli_Resepsiyon_Giriş_Paneli_bugunCikisYapanlar : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        { 
        if (Session["yetki"] != "resepsiyon")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        List<Konaklamalar> bugunCikisYapanMisafirGetir = new List<Konaklamalar>();

        Konaklamalar konaklamalar = new Konaklamalar(null) {
            gidisTarihi=DateTime.Now
        };

        bugunCikisYapanMisafirGetir = db.bugunCikisYapacaklar(konaklamalar);//mevcut günde çıkış yapacaklar listelenir.
        rptBugunCikisYapanlariGetir.DataSource = bugunCikisYapanMisafirGetir;
        rptBugunCikisYapanlariGetir.DataBind();
        }
    }
    protected void rptBugunCikisYapanlariGetir_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(',');
        if (e.CommandName == "Cikis")//çıkış butonuna basılan kişinin bilgileri Check-out.aspx sayfasına yönlendirilir.
        {
            Konaklamalar konaklamalar = new Konaklamalar(null)
            {
                tcKimlik = Convert.ToString(commandArgs[0]),
                odaNo = Convert.ToInt32(commandArgs[1])
            };
            string data = "tcKimlik=" + konaklamalar.tcKimlik + "&odaNo="+konaklamalar.odaNo;
            string hex = "";
            foreach (char c in data)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            Response.Redirect("check-out.aspx?D=" + hex);
        }  
    }
}