<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Resepsiyon Giriş Paneli/ResepsiyonMaster.master" AutoEventWireup="true" CodeFile="check-in.aspx.cs" Inherits="Yönetim_Paneli_Resepsiyon_Giriş_Paneli_check_in" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="page-wrapper">
                    <div class="main-page">
                        <div class="forms">
                            <div class=" form-grids row form-grids-right">
                                <div class="widget-shadow " data-example-id="basic-forms">
                                    <div class="form-title">
                                        <h4>Check-In Onaylama :</h4>
                                    </div>

                                    <div class="form-body">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Kimlik Numarası</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtKimlik" class="form-control" placeholder="Misafir Kimlik Numarası"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtKimlik" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtKimlik" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Adı</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtAd" class="form-control" placeholder="Misafir Adı"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtad" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtad" ErrorMessage="Sadece harf giriniz." ValidationExpression="[a-zA-Z]+" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Soyadı</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtSoyad" class="form-control" placeholder="Misafir Soyadı"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtSoyad" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Sadece harf giriniz." ValidationExpression="[a-zA-Z]+" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Telefon Numarası</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtTelefon" class="form-control" placeholder="Misafir Telefon Numarası"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtTelefon" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTelefon" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Geliş Tarihi</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtGelis" class="form-control" placeholder="Misafir Geliş Tarihi" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Gidiş Tarihi</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtGidis" class="form-control" placeholder="Misafir Gidiş Tarihi" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">İndirim Oranı</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtIndirim" class="form-control" placeholder="İndirim Oranı" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Ücret</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtUcret" class="form-control" placeholder="Ücret" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Oda Numarası</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtOda" class="form-control" placeholder="Oda Numarası" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Kat</asp:Label>
                                            <div class="col-sm-9">
                                                <asp:TextBox runat="server" ID="txtKat" class="form-control" placeholder="Kat" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-offset-2">
                                            <asp:Button class="btn btn-default" Text="Onayla" runat="server" Style="background-color: #F2B33F; color: #fff" ID="btnCheckInOnayla" OnClick="btnCheckInOnayla_Click" />&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>

