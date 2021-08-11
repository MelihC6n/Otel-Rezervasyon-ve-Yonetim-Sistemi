<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Admin Giriş Paneli/AdminMaster.master" AutoEventWireup="true" CodeFile="OtelEkle.aspx.cs" Inherits="OtelEkleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <div class=" form-grids row form-grids-right">
                    <div class="widget-shadow " data-example-id="basic-forms">
                        <div class="form-title">
                            <h4>Otel Ekle :</h4>
                        </div>
                        <div class="form-body">
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Ad</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtad" class="form-control" placeholder="Otel Adı"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtad" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtad" ErrorMessage="Sadece harf giriniz." ValidationExpression="[a-zA-Z]+" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Adres</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="TextBox1" class="form-control" placeholder="Otel Adres" MaxLength="99"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Sadece harf giriniz." ValidationExpression="[a-zA-Z]+" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Fax</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="TextBox2" class="form-control" placeholder="Otel Fax Numarası"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TextBox2" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Yıldız Sayısı</asp:Label>
                                <div class="col-sm-9">
                                    <asp:DropDownList runat="server" ID="drpyildiz" class="form-control" placeholder="Otel Yıldız Sayısı">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-offset-2">
                                <asp:Button class="btn btn-default" Text="Kaydet" runat="server" Style="background-color: #F2B33F; color: #fff" ID="btnOtelEkle" OnClick="btnOtelEkle_Click" />&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

