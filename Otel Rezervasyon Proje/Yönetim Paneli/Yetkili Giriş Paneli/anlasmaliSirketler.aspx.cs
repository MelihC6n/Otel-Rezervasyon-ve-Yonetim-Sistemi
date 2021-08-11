using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
public partial class anlasmaliSirketler : System.Web.UI.Page
{
    DbProcess dbProcess = new DbProcess();
    Oteller oteller = new Oteller();
    protected void Page_Load(object sender, EventArgs e)
    {   //şirketler listelenir
        if (Session["yetki"] != "yönetici")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
        if (Page.IsPostBack==false)
        {
            List<AnlasmaliSirketler> anlasmaliSirketlerlist = new List<AnlasmaliSirketler>();
            anlasmaliSirketlerlist = dbProcess.AnlasmaliSirketlerSelect();
            rptAnlasmaliSirketler.DataSource = anlasmaliSirketlerlist;
            rptAnlasmaliSirketler.DataBind();
        }
    }

    protected void rptAnlasmaliSirketler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        if(e.CommandName== "SirketSil")//şirket silinir
        {
            AnlasmaliSirketler anlasmali = new AnlasmaliSirketler(oteller);
            anlasmali.ad = e.CommandArgument.ToString();
            dbProcess.AnlasmaliSirketlerDelete(anlasmali);
            Response.Redirect("anlasmaliSirketler.aspx");
        }
    }
}