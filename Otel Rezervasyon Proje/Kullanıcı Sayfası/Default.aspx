<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Kullanıcı_Sayfası_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
    <title></title>
    <link href="css/soncss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
<div class="banner">
 <asp:ImageButton ImageUrl="images/deu.png" runat="server" CssClass="logo" PostBackUrl="~/Kullanıcı Sayfası/Default.aspx"/><p class="p">DOKUZ EYLÜL ÜNİVERSİTESİ</p><asp:ImageButton ImageUrl="images/yonetici.png" runat="server" CssClass="logoAdmin" PostBackUrl="../Login Sayfası/login.aspx"/>
        </div>
        <center>
          
            <br /><br /><br /><br />
            <h1>Hala rezervasyon yapmadınız mı ?</h1>
            <br /><br /><br  /><br />
        <table class="table" >
            <thead>
                <tr style="width:300px;">
                <th>Otele Geliş Tarihi</th>
                    <th></th>
                <th>Otelden Gidiş Tarihi</th>
                    <th></th>
                <th>Kişi Sayısı</th>
                <th>Şirket Kodu (Mevcutsa)</th>
                    </tr>
            </thead>
            <tbody >
                <tr style="width:300px;">
                    <td><asp:TextBox runat="server" ID="txtGelisTarih" CssClass="txt" placeholder="Geliş Tarihi" ReadOnly="True"/></td>
                    <td> <asp:ImageButton runat="server" imageurl="images/takvim.png" ID="btnGelis" OnClick="btnGelis_Click"/> </td>
                    <td><asp:TextBox runat="server" ID="txtGidisTarih" CssClass="txt" placeholder="Gidiş Tarihi" ReadOnly="True"/> </td>
                     <td><asp:ImageButton runat="server" imageurl="images/takvim.png" ID="btnGidis" OnClick="btnGidis_Click"/> </td>
                    <td><asp:DropDownList runat="server" ID="drpKisiSayisi" CssClass="drpKisiSayisi">
                        </asp:DropDownList></td>
                    <td><asp:TextBox runat="server" ID="SirketKod" CssClass="txt" placeholder="Şirket Kodu" MaxLength="8"/> </td>
                </tr>
                <tr>
                    <td>
                        <asp:Calendar ID="clGelisTarih" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" DayNameFormat="Shortest" Font-Bold="True" Font-Italic="False" Font-Names="Century Gothic" Font-Overline="False" Font-Size="8pt" ForeColor="Black" Height="200px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Width="220px" Visible="False">
            <DayHeaderStyle BackColor="#CCCCCC" BorderStyle="Solid" Font-Bold="True" Height="1px" />
            <DayStyle BackColor="White" BorderStyle="Solid" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="Gray" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        
                        <asp:Calendar ID="clGidisTarih" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" DayNameFormat="Shortest" Font-Bold="True" Font-Italic="False" Font-Names="Century Gothic" Font-Overline="False" Font-Size="8pt" ForeColor="Black" Height="200px" OnDayRender="Calendar2_DayRender" ShowGridLines="True" Width="220px" Visible="False" OnSelectionChanged="clGidisTarih_SelectionChanged">
            <DayHeaderStyle BackColor="#CCCCCC" BorderStyle="Solid" Font-Bold="True" Height="1px" />
            <DayStyle BackColor="White" BorderStyle="Solid" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="Gray" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>
                        
                    </td>
                    <td>

                    </td>
                </tr>
            </tbody>
        </table>
            <br /><br /><br /><br />
                       <div class="btn">
  <a href="#" data-hover="Rezervasyon Yap" class="rez" runat="server" onserverclick="RezervasyonYapClick">Rezervasyon Yap</a>
</div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <div class="btn">
  <a href="rezervasyonSorgulama.aspx" data-hover="Rezervasyon Sorgula" class="rez" runat="server">Rezervasyon Sorgula</a>
</div>
                
            </center>
        <div>
          
        </div>
    </form>
</body>
</html>
