<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Resepsiyon Giriş Paneli/ResepsiyonMaster.master" AutoEventWireup="true" CodeFile="konaklamalar.aspx.cs" Inherits="konaklamalar" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper" class="cbp-spmenu-push">
        <div class="main-page">
            <div class="tables">
                <table>
                    <tr>
                        <td style="vertical-align:top">
                            <div class="col-md-4 span_8" style="width: 120%; float: left; margin-top: 0%;">
                                <div class="activity_box">
                                    <h2 style="background-color: #1E252F">&nbsp&nbsp&nbsp&nbsp Oda No &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Durum &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp İşlem</h2>
                                    <div class="scrollbar" id="style-1" style="height: 300px">
                                        <table class="table table-hover">
                                            <tbody>
                                                <asp:Repeater ID="rptOdaDurum" runat="server" OnItemCommand="rptOdaDurum_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Eval("odaNo") %></td>
                                                            <td><%#Eval("durum") %></td>
                                                            <td>
                                                                <div class="col-sm-offset-2">
                                                                    <asp:Button class="btn btn-default" Text="Bilgiler" runat="server" Style="background-color: #EB3E28; color: #fff; width: 100px;text-transform:capitalize" ID="Bilgiler" CommandName="BilgiGetir" CommandArgument='<%#Eval("odaNo") %>' />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div style="padding-bottom: 10px; padding-top: 10px">
                                        <asp:TextBox runat="server" ID="txtOdaNo" PlaceHolder="Oda Numarası Girin" AutoPostBack="True" OnTextChanged="odaNo_TextChanged"></asp:TextBox>
                                        <asp:Button runat="server" ID="btnTemizle" Text="Temizle" OnClick="btnTemizle_Click" />
                                    </div>
                                </div>
                            </div>
                        </td>
                        <td style="vertical-align:top">
                            <div class="panel-body widget-shadow" style="width: 100%; margin-left: 15%;">
                                <h4>Misafir Ara </h4>
                                <div class="form-group">
                                    <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Ad</asp:Label>
                                    <div class="col-sm-9">
                                        <table>
                                            <tr><td>
                                        <asp:TextBox runat="server" ID="txtAd" class="form-control" placeholder="Konaklayan isim"></asp:TextBox>
                                       </td><td><div class="col-sm-offset-2">
                                       <asp:Button Text="Ara" runat="server" Style="text-align: center; outline:none; width:70px; font-size:1em; color:#fff; background:#629aa9; border:none; padding:5px 0; margin-left:0.5em; transition:0.5s all;" ID="MusteriAra" OnClick="MusteriAra_Click" />
                                       </div></td>
                                                <td><div class="col-sm-offset-2">
                                       <asp:Button Text="Temizle" runat="server" Style="text-align: center; outline:none; width:70px; font-size:1em; color:#fff; background:#629aa9; border:none; padding:5px 0; margin-left:0.5em; transition:0.5s all;" ID="MusteriTemizle" OnClick="MusteriTemizle_Click" />
                                       </div></td>
                                            </tr></table>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="panel-body widget-shadow" style="margin-left: 15%;font:normal 15px 'Century Gothic';width:100%">
                                <h4>Kişi Bilgileri </h4>
                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th>Oda No</th>
                                            <th>TC No</th>
                                            <th>Ad</th>
                                            <th>Soyad</th>
                                            <th>Telefon No</th>
                                            <th>Geliş</th>
                                            <th>Gidiş</th>
                                            <th>İşlem</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptKisiBilgi" runat="server" OnItemCommand="rptKisiBilgi_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("odaNo") %></td>
                                                    <td><%#Eval("tcKimlik") %></td>
                                                    <td><%#Eval("ad") %></td>
                                                    <td><%#Eval("soyad") %></td>
                                                    <td><%#Eval("telefonNo") %></td>
                                                    <td><%#Eval("gelisTarihi").ToString().Substring(0,10) %></td>
                                                    <td><%#Eval("gidisTarihi").ToString().Substring(0,10) %></td>
                                                    <td style="vertical-align: top; text-align: center">
                                       <asp:Button Text="Çıkış" runat="server" Style="text-align:center; outline:none; width:60px; font-size:1em; color:#fff; background:#629aa9; border:none; padding:2px 0;" ID="Bilgiler" CommandName="Cikis" CommandArgument='<%#Eval("odaNo")+","+Eval("tcKimlik")%>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</asp:Content>

