<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RezervasyonOnayi.aspx.cs" Inherits="Kullanıcı_Sayfası_RezervasyonOnayi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/soncss.css" rel="stylesheet" />

 <script type="text/javascript">
     history.pushState(null, null, location.href);
     window.onpopstate = function () {
         history.go(1);
     };
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="banner">
 <asp:ImageButton ImageUrl="images/deu.png" runat="server" CssClass="logo" PostBackUrl="~/Kullanıcı Sayfası/Default.aspx"/><p class="p">DOKUZ EYLÜL ÜNİVERSİTESİ</p>
        </div>
        <center>
            <div class="rezSorgulamaGovde">
                <p style="color:#fff;font:bold 16px 'Century Gothic'">REZERVASYON TAMAMLANDI</p>
                <div class="rezSorgula">
                    <asp:repeater runat="server" ID="rptRezervasyonGetir">
    <itemtemplate>


                <table class="rezervasyonSorgulaTable" >
                <tr>
                <td class="tableBaslik">Otele Geliş Tarihi</td>
                    <td></td>
                <td class="tableBaslik">Otelden Gidiş Tarihi</td>
                    <td></td>
                <td class="tableBaslik">Rezervasyon Tarihi</td>
                    </tr>
                <tr>
                     <td><br /><asp:label text='<%#Eval("gelisTarihi").ToString().Substring(0,9) %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/> </td>
                     <td></td>
                     <td><br /><asp:label text='<%#Eval("gidisTarihi").ToString().Substring(0,9) %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/></td>
                     <td></td>
                     <td><br /><asp:label text='<%#Eval("rezervasyonTarihi").ToString().Substring(0,9) %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/></td></tr>
                                              <tr>
                                                 <td> <br /><br /><br /><br /></td>
                                              </tr>
                                             
                 <tr>
                    <td></td>
                     <td class="tableBaslik">Oda Tip</td>
                     <td></td>
                     <td class="tableBaslik">İndirim Oranı</td>
                     <td></td>
                </tr>
                 <tr>
                     <td></td>
                     <td><br /><asp:label text='<%#Eval("odalar.odaTip.ad") %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/></td>
                     <td></td>
                     <td><br /><asp:label text='<%#Eval("indirimOrani") %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/></td>
                     <td></td>
                </tr>
        </table>
            </itemtemplate>
</asp:repeater><br /><br /><br />
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lbl" CssClass="tableBaslik">Rezervasyon Kodunuz :</asp:Label> <asp:Label runat="server" ID="lblRezKod" Font-Bold="True" ForeColor="#FF6A00" Font-Names="Century Gothic"></asp:Label>
                            </td>
                            <td></td><td></td>
                            <td>
         <div class="btn"><a href="#" data-hover="Ana Sayfaya Dön" class="rez" runat="server"  id="btnAnaSayfa" onserverclick="AnaSayfa_Click">Ana Sayfaya Dön</a>&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label><br /><br /><br />         
</div> 
                            </td>
                        </tr>
                    </table>
           
                </div>
           
        </center>
    </form>
</body>
</html>
