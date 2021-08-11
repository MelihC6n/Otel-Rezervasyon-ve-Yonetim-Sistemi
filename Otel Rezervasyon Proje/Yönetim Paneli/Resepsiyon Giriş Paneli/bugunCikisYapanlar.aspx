<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Resepsiyon Giriş Paneli/ResepsiyonMaster.master" AutoEventWireup="true" CodeFile="bugunCikisYapanlar.aspx.cs" Inherits="Yönetim_Paneli_Resepsiyon_Giriş_Paneli_bugunCikisYapanlar"%>

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
            <div class="forms">
    	<div class=" form-grids row form-grids-right">
						<div class="widget-shadow " data-example-id="basic-forms"> 
                            <div class="form-title">
								    <h4>Bugün Çıkış Yapacak Olan Misafirler </h4>
							</div>
                            	<div class="form-body">
                                     <table class="table table-hover">
                    <thead>
                        <tr>
                            <th class="auto-style1">Kimlik Numarası</th>
                            <th class="auto-style1">Ad</th>
                            <th class="auto-style1">Soyad</th>
                            <th class="auto-style1">Telefon Numarası</th>
                            <th class="auto-style1">Oda Numarası</th>
                            <th class="auto-style1">Geliş Tarihi</th>
                            <th class="auto-style1">Gidiş Tarihi</th>
                            <th class="auto-style1">ISLEM</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptBugunCikisYapanlariGetir" OnItemCommand="rptBugunCikisYapanlariGetir_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("tcKimlik") %></td>
                                    <td><%#Eval("ad") %></td>
                                    <td><%#Eval("soyad") %></td>
                                    <td><%#Eval("telefonNo") %></td>
                                    <td><%#Eval("odaNo") %></td>
                                    <td><%#Eval("gelisTarihi").ToString().Substring(0,10) %></td>
                                    <td><%#Eval("gidisTarihi").ToString().Substring(0,10) %></td>
                                <td>
                                       <asp:Button Text="Çıkış" runat="server" Style="text-align:center; outline:none; width:60px; font-size:1em; color:#fff; background:#629aa9; border:none; padding:2px 0;" ID="Bilgiler" CommandName="Cikis" CommandArgument='<%#Eval("tcKimlik")+","+Eval("odaNo")%>' />
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
    </div>
    </div>
</asp:Content>

