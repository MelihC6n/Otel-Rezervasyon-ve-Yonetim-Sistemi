<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Kullanıcı_Sayfası_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
    
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

    <link href="css/StyleSheet5.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
             <div class="row">
            <div class="col-md-12">
<div class="banner">
 <asp:ImageButton ImageUrl="images/deu.png" runat="server" CssClass="logo" PostBackUrl="~/Kullanıcı Sayfası/Default.aspx"/><p class="p">DOKUZ EYLÜL ÜNİVERSİTESİ</p><asp:ImageButton ImageUrl="images/yonetici.png" runat="server" CssClass="logoAdmin" PostBackUrl="../Login Sayfası/login.aspx"/>
        </div></div></div>
        <center>
          
            <br /><br /><br /><br />
            
              <div class="row">

            <div class="col-md-12">
            <h1>Hala rezervasyon yapmadınız mı ?</h1>
                </div></div>
            <br /><br /><br  /><br />
        <div class="row col-2 col-10 col-sm-5 col-sm-7" style="width:auto;    height:auto;    text-align:center;    color:#002B41;
                          font:normal 15px 'Century Gothic';
                          border:1px solid #ff6a00;
                          padding:40px 40px 40px 40px;
                          border-bottom-right-radius:20px;
                          border-bottom-left-radius:20px">


                     
           <div class="col-12 col-sm-12 col-lg-3">
               <div class="row col-12"> Otele Geliş Tarihi</div>
                <div class="row col-12"><asp:TextBox runat="server" ID="txtGelisTarih" CssClass="txt" placeholder="Geliş Tarihi" ReadOnly="True"/>
                  <asp:ImageButton runat="server" imageurl="images/takvim.png" ID="btnGelis" OnClick="btnGelis_Click" style="height:25px;width:25px;margin-top:5px"/></div>
                  <div class="row col-12">                          <asp:Calendar ID="clGelisTarih" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" DayNameFormat="Shortest" Font-Bold="True" Font-Italic="False" Font-Names="Century Gothic" Font-Overline="False" Font-Size="8pt" ForeColor="Black" Height="200px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Width="220px" Visible="False">
            <DayHeaderStyle BackColor="#CCCCCC" BorderStyle="Solid" Font-Bold="True" Height="1px" />
            <DayStyle BackColor="White" BorderStyle="Solid" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="Gray" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar></div>
               </div>


               <div class="col-12 col-sm-12 col-lg-3">     
                   <div class="row col-12">Otelden Gidiş Tarihi</div>
                   <div class="row col-12"> <asp:TextBox runat="server" ID="txtGidisTarih" CssClass="txt" placeholder="Gidiş Tarihi" ReadOnly="True"/> 
                     <asp:ImageButton runat="server" imageurl="images/takvim.png" ID="btnGidis" OnClick="btnGidis_Click" style="height:25px;width:25px;margin-top:5px"/> </div>
                    <div class="row col-12"> <asp:Calendar ID="clGidisTarih" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" DayNameFormat="Shortest" Font-Bold="True" Font-Italic="False" Font-Names="Century Gothic" Font-Overline="False" Font-Size="8pt" ForeColor="Black" Height="200px" OnDayRender="Calendar2_DayRender" ShowGridLines="True" Width="220px" Visible="False" OnSelectionChanged="clGidisTarih_SelectionChanged">
            <DayHeaderStyle BackColor="#CCCCCC" BorderStyle="Solid" Font-Bold="True" Height="1px" />
            <DayStyle BackColor="White" BorderStyle="Solid" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="Gray" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>
            </div></div>
              <div class="col-12 col-sm-12 col-lg-3">     



                   <div class="row col-12">Kişi Sayısı</div>
                   <div class="row col-12"> <asp:DropDownList runat="server" ID="drpKisiSayisi" CssClass="drpKisiSayisi">
                        </asp:DropDownList></div>
                  </div>



                <div class="col-12 col-sm-12 col-lg-3">  
                    <div class="row col-12">Şirket Kodu (Mevcutsa)</div>
                   <div class="row col-12"><asp:TextBox runat="server" ID="SirketKod" CssClass="txt" placeholder="Şirket Kodu" MaxLength="8"/> </div>
            </div></div>
            <br /><br /><br /><br />
            <div class="row">
                <div class="col-12 col-sm-12 col-lg-4"></div>
                       <div  class="col-12 col-sm-12 col-lg-2" style="height: 20%; overflow: hidden; display: inline-block; margin-bottom:10px">
  <a href="#" data-hover="Rezervasyon Yap" class="rez" runat="server" onserverclick="RezervasyonYapClick">Rezervasyon Yap</a>
</div>
  <div  class="col-12 col-sm-12 col-lg-2" style="height: 20%; overflow: hidden; display: inline-block;  margin-bottom:10px">
  <a href="rezervasyonSorgulama.aspx" data-hover="Rezervasyon Sorgula" class="rez" runat="server">Rezervasyon Sorgula</a>
</div>
                <div class="col-12 col-sm-12 col-lg-4"></div>
            </div>
                
            </center>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</body>
</html>
