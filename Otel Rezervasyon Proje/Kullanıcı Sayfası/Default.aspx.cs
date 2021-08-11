using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;

public partial class Kullanıcı_Sayfası_Default : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false) //kisi sayısını ekler
        {
            OdaTip odaTip = new OdaTip(null);
            odaTip = db.OdaTipKapasite();
            for (int i = 1; i <= odaTip.odaKapasite; i++)
            {
                drpKisiSayisi.Items.Add(i.ToString());
            }
        }
    }
    protected void Unnamed2_Click(object sender, EventArgs e) //tarih image buttonuna basılınca gelistarih takvimi acar
    {
        clGelisTarih.Visible = true;
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e) //gelistarihinde bulunan günden öncesini
    {                                                                       //ve bir yıl sonrasından fazlasının seçilmesini önler
        if (e.Day.Date.CompareTo(DateTime.Today) < 0 || e.Day.Date.CompareTo(DateTime.Today.Date.AddYears(1)) > 0)
        {
            e.Day.IsSelectable = false;
        }

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e) //gidis tarihinde, gelis tarihnden 1 gün sonrası seçtirir
    {
        clGidisTarih.SelectedDate = clGelisTarih.SelectedDate.Date.AddDays(1);
        clGidisTarih.VisibleDate = clGidisTarih.SelectedDate;
        txtGelisTarih.Text = clGelisTarih.SelectedDate.ToString().Substring(0, 10);
        txtGelisTarih.Text = TarihDuzelt(txtGelisTarih.Text);
        clGelisTarih.Visible = false;
        clGidisTarih.Visible = true;
        txtGidisTarih.Text = clGidisTarih.SelectedDate.ToString().Substring(0, 10);
        txtGidisTarih.Text = TarihDuzelt(txtGidisTarih.Text);
    }

    protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)//gelistarihinden 1gün sonrasından öncesini ve 1 ay sonrası dışındaki seçimleri engeller
    {
        if (e.Day.Date.CompareTo(clGelisTarih.SelectedDate.Date.AddDays(1)) < 0 || e.Day.Date.CompareTo(clGelisTarih.SelectedDate.Date.AddMonths(1)) > 0)
        {
            e.Day.IsSelectable = false;
        }

    }
    protected void btnGelis_Click(object sender, ImageClickEventArgs e)
    {
        clGelisTarih.Visible = true;
    }
    protected void btnGidis_Click(object sender, ImageClickEventArgs e)
    {
        clGidisTarih.Visible = true;
    }
    protected void clGidisTarih_SelectionChanged(object sender, EventArgs e)
    {
        txtGidisTarih.Text = clGidisTarih.SelectedDate.ToString().Substring(0, 10);
        txtGidisTarih.Text = TarihDuzelt(txtGidisTarih.Text);
        clGidisTarih.Visible = false;
    }
    protected void RezervasyonYapClick(object sender, EventArgs e)//girilen parametreleri gönderir
    {
        if ((txtGelisTarih.Text != "" && txtGelisTarih.Text != "Lütfen tarih seçiniz ->") && (txtGidisTarih.Text != "" && txtGidisTarih.Text != "Lütfen tarih seçiniz ->"))
        {
            if (SirketKod.Text == "")
            {
                SirketKod.Text = "0";
            }

            string data = "GelisTarihi=" + txtGelisTarih.Text + "&GidisTarihi=" + txtGidisTarih.Text + "&KisiSayisi=" + drpKisiSayisi.Text + "&IndirimKodu=" + SirketKod.Text;
            string hex = "";
            foreach (char c in data)    //verileri hex'e çevirir
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            Response.Redirect("odalar.aspx?D=" + hex);//verileri 'D' olarak gönderir
        }
        else
        {
            txtGelisTarih.Text = "Lütfen tarih seçiniz ->";
            txtGidisTarih.Text = "Lütfen tarih seçiniz ->";
        }
    }
    protected string TarihDuzelt(string tarih)//bazı cihazlardaki tarihin sonunda 0 gözükmesini engeller
    {
        string result = "";
        string[] parcala = tarih.Split('.');
        result = parcala[0] + "." + parcala[1] + "." + parcala[2].Substring(0, 4);
        return result;
    }
}