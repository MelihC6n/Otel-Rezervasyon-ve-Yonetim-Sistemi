<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Yetkili Giriş Paneli/YetkiliGirisMaster.master" AutoEventWireup="true" CodeFile="anlasmaliSirketler.aspx.cs" Inherits="anlasmaliSirketler" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="tables">
                <div class="panel-body widget-shadow">
                    <h4>Anlasmalı Şirketler </h4>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>AD</th>
                                <th>ADRES</th>
                                <th>TELEFON</th>
                                <th>INDIRIM YUZDESI</th>
                                <th>KOD</th>
                                <th>ISLEM</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptAnlasmaliSirketler" runat="server" OnItemCommand="rptAnlasmaliSirketler_ItemCommand">
                                <ItemTemplate>
                                    <tr style="background-color: gainsboro">
                                        <td><%#Eval("ad") %></td>
                                        <td><%#Eval("adres") %></td>
                                        <td><%#Eval("telefon") %></td>
                                        <td><%#Eval("indirimYuzdesi") %></td>
                                        <td><%#Eval("sirketKodu")%></td>
                                        <td>
                                            <div class="col-sm-offset-2">
                                                <asp:Button class="btn btn-default" Text="Sil" runat="server" Style="background-color: #F2B33F; color: #fff; width: 50px; text-transform: lowercase" CommandName="SirketSil" CommandArgument='<%#Eval("ad") %>' ID="btnSirketSil" />
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

