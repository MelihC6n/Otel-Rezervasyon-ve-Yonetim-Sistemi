using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yönetim_Paneli_Yetkili_Giriş_Paneli_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "admin")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
    }
}