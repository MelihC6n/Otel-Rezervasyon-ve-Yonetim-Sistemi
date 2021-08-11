using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtelRezervasyon;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.HtmlControls; 


public partial class rezervasyonlar : System.Web.UI.Page
{
    DbProcess db = new DbProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yetki"] != "resepsiyon")
        {
            Response.Redirect("../../Login Sayfası/login.aspx");
        }
     
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
        txtGelisTarih.Text = clGelisTarih.SelectedDate.ToString().Substring(0, 10);
        txtGelisTarih.Text = TarihDuzelt(txtGelisTarih.Text);
        clGelisTarih.Visible = false;
    }
    protected void btnGelis_Click(object sender, ImageClickEventArgs e)
    {
        clGelisTarih.Visible = true;
    }
    protected string TarihDuzelt(string tarih)//bazı cihazlardaki tarihin sonunda 0 gözükmesini engeller
    {
        string result = "";
        string[] parcala = tarih.Split('.');
        result = parcala[0] + "." + parcala[1] + "." + parcala[2].Substring(0, 4);
        return result;
    }
    protected void btnRezervasyonAra_Click(object sender, EventArgs e)
    {
        if (txtGelisTarih.Text == "")
        {
            txtGelisTarih.Text = "Lütfen tarih seçiniz ->";
        }
        else
        {
            Musteri musteri = new Musteri(null)
            {
                ad = ""
            };
            List<Rezervasyon> rezervasyonListele = new List<Rezervasyon>();
            Rezervasyon rezTarihi = new Rezervasyon(null, null)
            {
                gelisTarihi = Convert.ToDateTime(txtGelisTarih.Text)
            };
            rezervasyonListele = db.RezervasyonViewSelect(rezTarihi, musteri);
            rptRezervasyon.DataSource = rezervasyonListele;
            rptRezervasyon.DataBind();

            gvRezervasyonListele.DataSource = db.RezervasyonViewSelectPDF(rezTarihi,musteri);
            gvRezervasyonListele.DataBind();
        }

    }
    protected void btnCiktiAl_Click(object sender, EventArgs e)
    {
        if (rptRezervasyon.Items.Count > 0)
        {
            gvRezervasyonListele.Visible = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + txtGelisTarih.Text + "" + "Tarihindeki Rezervasyonlar" + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvRezervasyonListele.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A3, 20f, 20f, 20f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

            gvRezervasyonListele.DataBind();
            gvRezervasyonListele.Visible = false;
        }
        else { txtGelisTarih.Text = "Lütfen tarih seçiniz ->"; }
        

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

}