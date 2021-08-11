<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Resepsiyon Giriş Paneli/ResepsiyonMaster.master" AutoEventWireup="true" CodeFile="rezervasyonlar.aspx.cs" Inherits="rezervasyonlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 49px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="tables">
                <div class="panel-body widget-shadow">
                    <h4>Rezervasyon Ara </h4>
                    <div class="form-group">
                        <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Ad</asp:Label>

                        <table>
                            <tr>
                                <td style="width: 75%">
                                    <asp:TextBox runat="server" ID="txtad" class="form-control" placeholder="Rezervasyon yapan kişinin adı"></asp:TextBox></td>
                                <td>
                                    <div class="col-sm-offset-2">
                                        <asp:Button class="btn btn-default" Text="Ara" runat="server" Style="background-color: #EB3E28; color: #fff; width: 100px; text-transform: capitalize;" ID="btnAra" OnClick="btnAra_Click" />
                                    </div>
                                </td><td>&nbsp</td>
                                 <td>
                                    <div class="col-sm-offset-2">
                                        <asp:Button class="btn btn-default" Text="Temizle" runat="server" Style="background-color: #EB3E28; color: #fff; width: 100px; text-transform: capitalize;" ID="btnTemizle" OnClick="btnTemizle_Click"/>
                                    </div>
                                </td>
                            </tr>
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
                            <th class="auto-style1">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp ISLEM</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptRezervasyon" runat="server" OnItemCommand="rptRezervasyon_ItemCommand">
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
                                    <td style="vertical-align: top; text-align: center">
                                        <div class="col-sm-offset-2">
                                            <asp:Button class="btn btn-default" Text="Onayla" runat="server" Style="background-color: #EB3E28; color: #fff; width: 100px; text-transform: lowercase" ID="btnSirketSil" CommandName="CheckIn" CommandArgument='<%#Eval("gelisTarihi").ToString().Substring(0,10)+","+Eval("gidisTarihi").ToString().Substring(0,10)+","+Eval("musteri.ad")+","+Eval("musteri.soyad")+","+Eval("musteri.cepTelefon")+","+Eval("indirimOrani")+","+Eval("odaID")+","+Eval("ID")+","+Eval("ucret")%>'/>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    </div>

</asp:Content>

