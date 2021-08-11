<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Yetkili Giriş Paneli/YetkiliGirisMaster.master" AutoEventWireup="true" CodeFile="odaTipEkle.aspx.cs" Inherits="odaTipEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <div class=" form-grids row form-grids-right">
                    <div class="widget-shadow " data-example-id="basic-forms">
                        <div class="form-title">
                            <h4>Oda Tip Ekle :</h4>
                        </div>

                        <div class="form-body">
                           <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Ad</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtTipAd" class="form-control" placeholder="Tip Adı"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtTipAd" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTipAd" ErrorMessage="Sadece harf giriniz." ValidationExpression="[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                           <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Açıklama</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtTipAciklama" class="form-control" placeholder="Tip Açıklaması"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtTipAciklama" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTipAciklama" ErrorMessage="Sadece harf giriniz." ValidationExpression="[a-zA-ZçÇğĞıİöÖşŞüÜ\s0-9.,!?]+" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Kapasite</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtKapasite" class="form-control" placeholder="Tip Kapasitesi"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtKapasite" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtKapasite" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Tip Özellikleri</asp:Label>
                                <div class="col-sm-8">
                                    <br />
                                    <span>Klima : </span>
                                    <asp:CheckBox runat="server" ID="chkKlima" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Sauna : </span>
                                    <asp:CheckBox runat="server" ID="chkSauna" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Televizyon : </span>
                                    <asp:CheckBox runat="server" ID="chkTelevizyon" class="checkbox-inline1" />&nbsp&nbsp&nbsp
                                    <span>Saç Kurutma Makinesi : </span>
                                    <asp:CheckBox runat="server" ID="chkSacKurutmaMakinesi" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Jakuzi : </span>
                                    <asp:CheckBox runat="server" ID="chkJakuzi" class="checkbox-inline1" /><br />
                                    <br />
                                    <span>Ses Yalıtımı : </span>
                                    <asp:CheckBox runat="server" ID="chkSesYalitimi" class="checkbox-inline1" />
                                    <span>Mutfak : </span>
                                    <asp:CheckBox runat="server" ID="chkMutfak" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Balkon : </span>
                                    <asp:CheckBox runat="server" ID="chkBalkon" class="checkbox-inline1" />&nbsp&nbsp&nbsp
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Manzara Özellikleri</asp:Label>
                                <div class="col-sm-8">
                                    <br />
                                    <span>Deniz Manzarası : </span>
                                    <asp:RadioButton runat="server" ID="radioDeniz" class="checkbox-inline1" GroupName="Manzara" />&nbsp&nbsp&nbsp
                                    <span>Orman Manzarası : </span>
                                    <asp:RadioButton runat="server" ID="radioOrman" class="checkbox-inline1" GroupName="Manzara" />
                                    <span>Dağ Manzarası : </span>
                                    <asp:RadioButton runat="server" ID="radioDag" class="checkbox-inline1" GroupName="Manzara" />&nbsp&nbsp&nbsp
                                    <span>Şehir Manzarasi : </span>
                                    <asp:RadioButton runat="server" ID="radioSehir" class="checkbox-inline1" GroupName="Manzara" />&nbsp&nbsp&nbsp
                                    <span>Manzara Yok : </span>
                                    <asp:RadioButton runat="server" ID="radioYok" class="checkbox-inline1" GroupName="Manzara" />&nbsp&nbsp&nbsp
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Fiyat</asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtFiyat" class="form-control" placeholder="Tip Fiyatı"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtFiyat" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtFiyat" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Fotoğraf</asp:Label>
                                <div class="col-sm-9">
                                    <asp:FileUpload runat="server" ID="fuFotograf" BorderStyle="Solid" BorderWidth="1" BorderColor="#cccccc"/>
                                    <br />
                                    <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Yükle" OnClick="Button1_Click" Style="background-color: #F2B33F; color: #fff"/>
                                    <asp:Image ID="Image1" runat="server" Height="100" Width="100" />
                                    <asp:Label ID="lblResim" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="col-sm-offset-2">
                                <asp:Button class="btn btn-default" Text="Kaydet" runat="server" Style="background-color: #F2B33F; color: #fff" ID="btnTipEKle" OnClick="btnTipEKle_Click1" />&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

