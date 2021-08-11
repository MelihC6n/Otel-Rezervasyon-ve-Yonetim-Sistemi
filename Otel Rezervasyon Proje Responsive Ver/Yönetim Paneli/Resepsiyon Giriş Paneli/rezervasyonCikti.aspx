<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Resepsiyon Giriş Paneli/ResepsiyonMaster.master" AutoEventWireup="true" CodeFile="rezervasyonCikti.aspx.cs" Inherits="rezervasyonlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 49px;
        }
        .txt {
            padding-left: 5px;
    text-align: center;
    width: 200px;
    height: 30px;
    font: normal 15px 'Century Gothic';
    border: 1px solid #002B41;
    margin-top: 5px;
        }
           .txt:hover {
        -webkit-box-shadow: 0 0 4px 4px #dddbdb;
        -moz-box-shadow: 0 0 4px 4px #dddbdb;
        box-shadow: 0 0 4px 4px #dddbdb;
        width: 210px;
        height: 32px;
    }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="tables">
                <div class="panel-body widget-shadow">
                    <h4>PDF Çıktısı Al </h4>
                    <div class="form-group">
                        <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Tarih Seçin : </asp:Label>
                        <table>
                            <tbody>
                                <tr style="width: 75%">
                                    <td>
                                        <asp:TextBox runat="server" ID="txtGelisTarih"  CssClass="txt" placeholder="Geliş Tarihi" ReadOnly="True"/><asp:ImageButton runat="server" imageurl="../../Kullanıcı%20Sayfası/images/takvim.png" ID="btnGelis" OnClick="btnGelis_Click" />
                                    </td>    
                                   <td>
                                    <div class="col-sm-offset-2">
                                         <asp:Button class="btn btn-default" Text="Ara" runat="server" Style="background-color: #EB3E28; color: #fff; width: 100px; text-transform: capitalize;" ID="btnRezervasyonAra" OnClick="btnRezervasyonAra_Click" />
                                    </div>
                                </td><td>&nbsp</td>
                                 <td>
                                    <div class="col-sm-offset-2">
                                        <asp:Button class="btn btn-default" Text="Çıktı Al" runat="server" Style="background-color: #EB3E28; color: #fff; width: 100px; text-transform: capitalize;" ID="btnCiktiAl" OnClick="btnCiktiAl_Click"/>
                                    </div>
                                </td>
                                </tr>
                            
                            <tr>
                                <td style="width: 75%">
                                      <asp:Calendar ID="clGelisTarih" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" DayNameFormat="Shortest" Font-Bold="True" Font-Italic="False" Font-Names="Century Gothic" Font-Overline="False" Font-Size="8pt" ForeColor="Black" Height="200px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Width="220px" Visible="False">
            <DayHeaderStyle BackColor="#CCCCCC" BorderStyle="Solid" Font-Bold="True" Height="1px" />
            <DayStyle BackColor="White" BorderStyle="Solid" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="Gray" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar></td>
                               
                                
                            </tr>
                                </tbody>
                        </table>

                    </div>
                </div>
            </div>
            <br />
            <div class="panel-body widget-shadow">
                <h4>Rezervasyonlar </h4>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th class="auto-style1">Geliş Tarihi</th>
                            <th class="auto-style1">Gidiş Tarihi</th>
                            <th class="auto-style1">Rezerve Tarihi</th>
                            <th class="auto-style1">Ad</th>
                            <th class="auto-style1">Soyad</th>
                            <th class="auto-style1">Ülke</th>
                            <th class="auto-style1">Uyruk</th>
                            <th class="auto-style1">Cep Telefonu</th>
                            <th class="auto-style1">İndirim Oranı</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptRezervasyon" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("gelisTarihi").ToString().Substring(0,10) %></td>
                                    <td><%#Eval("gidisTarihi").ToString().Substring(0,10) %></td>
                                    <td><%#Eval("rezervasyonTarihi").ToString().Substring(0,10) %></td>
                                    <td><%#Eval("musteri.ad") %></td>
                                    <td><%#Eval("musteri.soyad") %></td>
                                    <td><%#Eval("musteri.ulke") %></td>
                                    <td><%#Eval("musteri.uyruk") %></td>
                                    <td><%#Eval("musteri.cepTelefon") %></td>
                                    <td><%#Eval("indirimOrani") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>                      
                    </tbody>
                </table>
                <asp:GridView id="gvRezervasyonListele" runat="server" autogeneratecolumns="false" font-names="Century Gothic"
font-size="10pt" alternatingrowstyle-backcolor="White" headerstyle-backcolor="White" ForeColor="Black"
allowpaging="true" Visible="False"> 
<Columns> 
<asp:BoundField ItemStyle-Width = "200px" HeaderText = "Gelis Tarihi" DataField="GelisTarihi"/> 
<asp:BoundField ItemStyle-Width = "200px" HeaderText = "Gidis Tarihi" DataField="GidisTarihi"/> 
<asp:BoundField ItemStyle-Width = "200px" HeaderText = "Rezervasyon Tarihi" DataField="RezervasyonTarihi"/> 
<asp:BoundField ItemStyle-Width = "150px" HeaderText = "Ad" DataField="Ad"/> 
<asp:BoundField ItemStyle-Width = "150px" HeaderText = "Soyad" DataField="Soyad"/> 
<asp:BoundField ItemStyle-Width = "200px" HeaderText = "Ülke" DataField="Ulke"/> 
<asp:BoundField ItemStyle-Width = "200px" HeaderText = "Uyruk" DataField="Uyruk"/> 
<asp:BoundField ItemStyle-Width = "200px" HeaderText = "Cep Telefonu" DataField="CepTelefon"/> 
<asp:BoundField ItemStyle-Width = "50px" HeaderText =  "Indirim Oranı" DataField="IndirimOrani"/> 
</Columns> 
</asp:GridView>
            </div>
        </div>
    </div>
    </div>

</asp:Content>

