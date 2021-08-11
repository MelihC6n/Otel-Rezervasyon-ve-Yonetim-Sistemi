<%@ Page Language="C#" AutoEventWireup="true" CodeFile="odalar.aspx.cs" Inherits="Kullanıcı_Sayfası_yonlendir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/soncss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     
  <div class="banner">
 <asp:ImageButton ImageUrl="images/deu.png" runat="server" CssClass="logo" PostBackUrl="~/Kullanıcı Sayfası/Default.aspx"/><p class="p">DOKUZ EYLÜL ÜNİVERSİTESİ</p>
        </div>
           <center>
              <table>
                  <tr>
                      <td style="vertical-align:top">
<div class="solmenu">
    <div class="solMenuOzellikBaslik">filtreleme / özellik</div>
    <div class="solMenuOzellik">
        <asp:Label runat="server" ID="lblOdaFiyat" CssClass="fiyat" Font-Bold="true" Font-Names="Arial">ODA ÖZELLİKLERİ</asp:Label><br />
        <asp:checkbox text="Balkon" runat="server" CssClass="chkOzellik" ID="chkBalkon"/><br />
        <asp:checkbox text="Mutfak" runat="server" CssClass="chkOzellik" ID="chkMutfak"/><br />
        <asp:checkbox text="Jakuzi" runat="server" CssClass="chkOzellik" ID="chkJakuzi"/><br />
        <asp:checkbox text="Sauna" runat="server" CssClass="chkOzellik" ID="chkSauna"/><br />
        <asp:checkbox text="Klima" runat="server" CssClass="chkOzellik" ID="chkKlima"/><br />
        <asp:checkbox text="Televizyon" runat="server" CssClass="chkOzellik" ID="chkTelevizyon"/><br />
        <asp:checkbox text="Saç Kurutma Makinesi" runat="server" CssClass="chkOzellik" ID="chkSacKurut"/><br />
        <asp:checkbox text="Ses Yalıtımı" runat="server" CssClass="chkOzellik" ID="chkSesYalit"/><br /><br /><br /><br />
        <asp:Label runat="server" ID="Label1" CssClass="fiyat" Font-Bold="true" Font-Names="Arial">MANZARA ÖZELLİKLERİ</asp:Label><br />
        <asp:RadioButton GroupName="manzara" text="Hepsi" runat="server" CssClass="chkOzellik" ID="radHepsi"/><br />
        <asp:RadioButton GroupName="manzara" text="Deniz Manzarası" runat="server" CssClass="chkOzellik" ID="radDeniz"/><br />
        <asp:RadioButton GroupName="manzara" text="Orman Manzarası" runat="server" CssClass="chkOzellik" ID="radOrman"/><br />
        <asp:RadioButton GroupName="manzara" text="Dağ Manzarası" runat="server" CssClass="chkOzellik" ID="radDag"/><br />
        <asp:RadioButton GroupName="manzara" text="Şehir Manzarası" runat="server" CssClass="chkOzellik" ID="radSehir"/><br />
        <asp:RadioButton GroupName="manzara" text="Manzara Yok" runat="server" CssClass="chkOzellik" ID="radMYok"/><br />
        <br />                      
        <div class="btn"><a href="#" data-hover="Filtrele" class="islem" runat="server" onserverclick="FiltreClick">Filtrele</a></div>
                  </div>
    </div>
                </div>
                      </td>
                       <td  style="vertical-align:top">
                               <asp:repeater runat="server" ID="OdalarGetir" OnItemCommand="OdalarGetir_ItemCommand">
    <itemtemplate>
                           <div class="odalar">

<table style="color:#002B41;font:normal 15px 'Century Gothic';">
    <thead>
        <tr>
            <th style="padding-top:10px;" colspan="2"><%#Eval("ad") %> (<%#Eval("odaKapasite") %>Kişilik)</th>
            <th style="padding-top:10px;">Oda Fiyatı / Açıklama</th>   
        </tr>
    </thead>
    <tbody>
        <tr>
            <td   style="padding:20px 20px 20px 20px;">
            <div class="odaResim">
                <asp:image imageurl='<%#Eval("resimAd") %>' runat="server" ID="odaResim" BorderStyle="None" Height="180px" Width="180px"/>
             </div>
            </td>
            <td   style="padding:20px 20px 20px 0;">
                <div class="odaOzellik">
                    <asp:TextBox style="text-align:center" runat="server" ID="txtOdaOzellik" Height="175px" ReadOnly="True" TextMode="MultiLine" Width="195px" BorderStyle="None" CssClass="kisitla1" Text='<%#Eval("ozellikler") %>' Font-Bold="true" Font-Names="Arial"></asp:TextBox>
                </div>
            </td>
               <td   style="padding:20px 20px 20px 0;">

               <div class="odaFiyat">
                    <asp:Label runat="server" ID="lblOdaFiyat" CssClass="fiyat" Font-Bold="true" Font-Names="Arial"><%# Eval("fiyat") %> ₺</asp:Label><br />
                   <asp:Label runat="server" ID="Label3" CssClass="fiyat" Font-Bold="true" Font-Names="Arial"><%# Eval("indirimliFiyat") %></asp:Label>
               </div>
               <div class="odaAciklama">
                    <asp:textbox runat="server" ID="txtAciklama" BorderStyle="None" Height="95px" ReadOnly="True" TextMode="MultiLine" Width="195px" CssClass="kisitla2" Text='<%#Eval("aciklama") %>' Font-Bold="true" Font-Names="Arial"/>
               </div>
               </td>
               <td   style="padding:20px 20px 20px 0;">
                  <div style="-webkit-box-shadow: 0 0 4px 4px #dddbdb;-moz-box-shadow: 0 0 4px 4px #dddbdb;box-shadow: 0 0 4px 4px #dddbdb;width:100px;height:40px;">
                      <div class="btn"><asp:LinkButton ID="RezButon" data-hover="Rezervasyon" class="islem" runat="server" CommandName="Rezervasyon" CommandArgument='<%#Eval("ad")+","+Eval("fiyat")%>'>Rezervasyon</asp:LinkButton></div>
                  </div>
               </td>
        </tr>

    </tbody>
</table>

                </div>
          </itemtemplate>
</asp:repeater>
                           <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:Label runat="server" ID="Label2" CssClass="fiyat" Font-Bold="true" Font-Names="Arial" Visible="false" Font-Size="XX-Large">Aradığınız filtrelemelere göre oda bulunamadı.</asp:Label><br />
                      </td>

                  </tr>
              </table>

            </center>

    </form>
</body>
</html>
