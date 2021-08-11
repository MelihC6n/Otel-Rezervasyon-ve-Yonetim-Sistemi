<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Resepsiyon Giriş Paneli/ResepsiyonMaster.master" AutoEventWireup="true" CodeFile="check-out.aspx.cs" Inherits="Yönetim_Paneli_Resepsiyon_Giriş_Paneli_check_out" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="main-page">
            <table>
                <tr>
                    <td style="width: 60%;">
                        <div class="forms">

                            <div class="form-grids row form-grids-right">
                                <div class="widget-shadow " data-example-id="basic-forms " style="text-align: center">
                                    <div class="form-title">
                                        <h4>Check-Out Onaylama</h4>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Oda No</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtCheckOutMisafirOdaNo" class="form-control" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Kimlik No</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtKimlikNo" class="form-control" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Ad</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtCheckOutMisafirAd" class="form-control" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Soyad</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtCheckOutMisafirSoyad" class="form-control" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Telefon</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtCheckOutMisafirTelefon" class="form-control" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Geliş Tarihi</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtCheckOutMisafirGelisTarihi" class="form-control" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Gidiş Tarihi</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtCheckOutMisafirGidisTarihi" class="form-control" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Toplam Ücret</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtCheckOutMisafirToplamUCret" class="form-control" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label">Alınan Ücret</asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:TextBox runat="server" ID="txtCheckOutMisafirAlınanUCret" class="form-control" AutoPostBack="True"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCheckOutMisafirAlınanUCret" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="[\d,]+" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                            <asp:Label runat="server" ID="lblUcretKontrol" Visible="False" ForeColor="Red"></asp:Label>
                                            <asp:Label runat="server" ID="lblHata" Visible="False" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-3 control-label"></asp:Label>
                                            <div class="col-sm-9" style="float: left; width: 61%">
                                                <asp:Button class="btn btn-default" Text="Ücret Al" runat="server" Style="background-color: #F2B33F; color: #fff;" ID="btnUcretAl" BorderStyle="None" OnClick="btnUcretAl_Click" />
                                                <asp:Button class="btn btn-default" Text="Çıkış Ver" runat="server" Style="background-color: #F2B33F; color: #fff" ID="btnCheckOut" OnClick="btnCheckOut_Click" />&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td style="width: 30%; padding-left: 20px; vertical-align: top">
                        <div class="forms">
                            <div class="form-grids row form-grids-right">
                                <div class="widget-shadow " data-example-id="basic-forms " style="text-align: center">
                                    <div class="form-title">
                                        <h4>Odada Bulunan Diğer Kişiler</h4>
                                    </div>
                                    <div class="form-body">
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
                                                <asp:Repeater ID="rptDigerKisiler" runat="server" OnItemCommand="rptDigerKisiler_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Eval("odaNo") %></td>
                                                            <td><%#Eval("tcKimlik") %></td>
                                                            <td><%#Eval("ad") %></td>
                                                            <td><%#Eval("soyad") %></td>
                                                            <td><%#Eval("telefonNo") %></td>
                                                            <td><%#Eval("gelisTarihi").ToString().Substring(0,9) %></td>
                                                            <td><%#Eval("gidisTarihi").ToString().Substring(0,10) %></td>
                                                            <td style="vertical-align: top; text-align: center">
                                                                <asp:Button Text="Çıkış" runat="server" Style="text-align: center; outline: none; width: 60px; font-size: 1em; color: #fff; background: #629aa9; border: none; padding: 2px 0;" ID="Bilgiler" CommandName="Cikis" CommandArgument='<%#Eval("tcKimlik")%>' />
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
                    </td>
                </tr>
            </table>


        </div>
    </div>
</asp:Content>

