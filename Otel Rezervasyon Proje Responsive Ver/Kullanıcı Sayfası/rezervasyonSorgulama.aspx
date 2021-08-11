<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rezervasyonSorgulama.aspx.cs" Inherits="rezervasyonSorgulama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"" lang="en">
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
      <div class="banner" style="height:65px">
 <asp:ImageButton ImageUrl="images/deu.png" runat="server" CssClass="logo" PostBackUrl="~/Kullanıcı Sayfası/Default.aspx"/><p class="p">DOKUZ EYLÜL ÜNİVERSİTESİ</p>
         </div> </div> </div>
        <center>
            <div class="row">
             <div class="col-auto col-sm-3"></div> <div class="col-12 col-sm-6">
            <div class="rezSorgulamaGovde">
                <p style="color:#fff;font:bold 16px 'Century Gothic'">REZERVASYON SORGULAMA</p>
                <div class="rezSorgula">
                    <div class="col col-sm col-md-1"></div>
                    <div class="col col-sm col-md-10 rezervasyonSorgulaTable">

                    <div class="row">
                            <div class="col-12 col-sm-12 col-md-6">

                    <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Rezervasyon Kodu :</p>
                    <asp:textbox runat="server" ID="txtRezervasyonSorgula" CssClass="txt"  /> 
                                 </div>
                            <div class="col-12 col-sm-12 col-md-6">
                    <div style="height: 40px; overflow: hidden; display: inline-block;"><a href="#" data-hover="Sorgula" class="rez" runat="server" onserverclick="rezervasyonSorgula" >Sorgula</a>
                    </div> </div> </div>
                               <br /><br />
    

                    <asp:repeater runat="server" ID="rptRezervasyonGetir">
    <itemtemplate>

                <div class="row">
                <div class="col-12 col-sm-12 col-md-4 tableBaslik">Otele Geliş Tarihi<br /><br /><asp:label text='<%#Eval("gelisTarihi").ToString().Substring(0,9) %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/> </div>
               
                <div class="col-12 col-sm-12 col-md-4 tableBaslik">Otelden Gidiş Tarihi<br /><br /><asp:label text='<%#Eval("gidisTarihi").ToString().Substring(0,9) %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/></div>

                <div class="col-12 col-sm-12 col-md-4 tableBaslik">Rezervasyon Tarihi<br /><br /><asp:label text='<%#Eval("rezervasyonTarihi").ToString().Substring(0,9) %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/></div>
                
                </div>
                    

                 <br /><br />

                                             
                 <div class="row">

                     <div class="col-12 col-sm-12 col-md-6 tableBaslik">Oda Tip<br /><br /><asp:label text='<%#Eval("odalar.odaTip.ad") %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/></div>

                     <div class="col-12 col-sm-12 col-md-6 tableBaslik">İndirim Oranı<br /><br /><asp:label text='<%#Eval("indirimOrani") %>' runat="server" Font-Bold="true" ForeColor="#ff6a00"/></div>

                </div>
            </itemtemplate>
</asp:repeater><br /><br /><br />
                    <div class="row">
                            <div class="col-12 col-sm-12 col-md-6">
                                <asp:Label runat="server" ID="lbl" Visible="false" CssClass="tableBaslik">Rezervasyon Kodunuz :</asp:Label> <asp:Label runat="server" ID="lblRezKod" Visible="false" Font-Bold="true" ForeColor="#ff6a00" Font-Names="Century Gothic"></asp:Label>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6">
         <div style="height: 40px; overflow: hidden; display: inline-block;"><a href="#" data-hover="İptal Et" class="rez" runat="server"  id="btnRezervasyonIptal" onserverclick="btnRezervasyonIptalOlay">İptal Et</a>&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label><br /><br /><br />         
</div> 
                            </div>
           
                </div>
                        </div> <div class="col col-sm col-md-1"></div> </div> </div> </div> <div class="col-auto col-sm-3"></div>  </div>
           
        </center>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</body>
</html>
