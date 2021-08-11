<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Admin Giriş Paneli/AdminMaster.master" AutoEventWireup="true" CodeFile="kullaniciEkle.aspx.cs" Inherits="kullaniciEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <div class=" form-grids row form-grids-right">
                    <div class="widget-shadow " data-example-id="basic-forms">
                        <div class="form-title">
                            <h4>Kullanıcı Ekle :</h4>
                        </div>
                        <div class="form-body">
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Oteller</asp:Label>
                                <div class="col-sm-9">
                                    <asp:DropDownList class="form-control" runat="server" ID="drpOtel"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Ad</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtAd" class="form-control" placeholder="Adı"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtad" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAd" ErrorMessage="Sadece harf giriniz." ValidationExpression="[a-zA-Z]+" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Soyad</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtSoyad" class="form-control" placeholder="Soyadı"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtSoyad" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Sadece harf giriniz." ValidationExpression="[a-zA-Z]+" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Kullanıcı Ad</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtKullaniciAd" class="form-control" placeholder="Kullanıcı Adı"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtKullaniciAd" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Şifre</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtSifre" class="form-control" placeholder="Kullanıcı Şifresi"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtSifre" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Yetki</asp:Label>
                                <div class="col-sm-9">
                                    <asp:DropDownList class="form-control" runat="server" ID="drpkullaniciYetki">
                                        <asp:ListItem Value="1">Personel</asp:ListItem>
                                        <asp:ListItem Value="2">Yönetici</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-offset-2">
                                <asp:Button class="btn btn-default" Text="Kaydet" runat="server" Style="background-color: #F2B33F; color: #fff" ID="btnKullaniciEkle" OnClick="btnKullaniciEkle_Click" />&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

