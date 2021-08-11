using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OtelRezervasyon;
using System.Data.SqlClient;
public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    DbProcess db = new DbProcess();
    protected void btn_Click(object sender, EventArgs e)//kullanıcı adı ve şifre eşleşirse o kişiyi yetkisiyle giriş yapmasını sağlar
    {
        List<Kullanicilar> kullaniciGetir = new List<Kullanicilar>();
        Kullanicilar kullanicilar = new Kullanicilar(null) 
        {
            kullaniciAd=txtad.Text,
            sifre=txtsifre.Text
        };
        kullaniciGetir = db.KullanicilarSelect(kullanicilar);

        if(kullaniciGetir.Count>0)
        {
            kullanicilar = kullaniciGetir[0];
        if (kullanicilar.yetki == true)
        {
            Session["yetki"] = "yönetici";
            Session["Kad"] = kullanicilar.ad;
            Response.Redirect("../Yönetim Paneli/Yetkili Giriş Paneli/Default.aspx");         
        }
        else if (kullanicilar.yetki == false)
        {
            Session["yetki"] = "resepsiyon";
            Session["Kad"] = kullanicilar.ad;
            Response.Redirect("../Yönetim Paneli/Resepsiyon Giriş Paneli/Default.aspx");
        }
        }

        List<Admin> adminGetir = new List<Admin>();
        Admin admin = new Admin()
        {
            kullaniciAd = txtad.Text,
            sifre = txtsifre.Text
        };
        adminGetir = db.AdminSelect(admin);

        if (adminGetir.Count > 0)
        {
            admin = adminGetir[0];
            Session["yetki"] = "admin";
            Response.Redirect("../Yönetim Paneli/Admin Giriş Paneli/Default.aspx");
        }


    }
}
