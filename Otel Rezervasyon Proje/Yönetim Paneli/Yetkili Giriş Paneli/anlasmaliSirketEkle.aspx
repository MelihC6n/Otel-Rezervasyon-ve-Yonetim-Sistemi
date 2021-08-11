<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Yetkili Giriş Paneli/YetkiliGirisMaster.master" AutoEventWireup="true" CodeFile="anlasmaliSirketEkle.aspx.cs" Inherits="anlasmaliSirketler" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
			<div class="main-page">
				<div class="forms">
    	<div class=" form-grids row form-grids-right">
						<div class="widget-shadow " data-example-id="basic-forms"> 
							<div class="form-title">
								<h4>Anlaşmalı Şirket Ekle :</h4>
							</div>
							<div class="form-body">
							 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Ad</asp:Label>
                             <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtSirketAd" class="form-control" placeholder="Şirket Adı"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtSirketAd" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSirketAd" ErrorMessage="Sadece harf giriniz."   ValidationExpression="[a-zA-Z]+" ForeColor="Red"></asp:RegularExpressionValidator>
                             </div>
							 </div> 
                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Adres</asp:Label>
                             <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtSirketAdres" class="form-control" placeholder="Şirket Adres"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtSirketAdres" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSirketAdres" ErrorMessage="Sadece harf giriniz."   ValidationExpression="[a-zA-Z]+" ForeColor="Red"></asp:RegularExpressionValidator>
                             </div>
							 </div> 
                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Telefon</asp:Label>
                             <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtSirketTelefon" class="form-control" placeholder="Şirket Telefon"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtSirketTelefon" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSirketTelefon" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                             </div>
							 </div> 
                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">İndirim Yüzdesi</asp:Label>
                             <div class="col-sm-9">
                                 <asp:DropDownList class="form-control" runat="server" ID="drpIndirimYuzdesi" AutoPostBack="false"></asp:DropDownList>
                             </div>
							 </div> 
                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Şirket İndirim Kodu</asp:Label>
                             <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtSirketKodu" class="form-control" placeholder="Şirket İndirim Kodu"></asp:TextBox>
                             </div>
							 </div> 
                                 <div class="col-sm-offset-2"> 
                             <asp:Button  class="btn btn-default" Text="Kaydet" runat="server"  style="background-color:#F2B33F;color:#fff" ID="btnSirketEkle" OnClick="btnSirketEkle_Click"/>&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                             </div>
                                </div>
                            </div>
            </div>
                    </div>
                </div>
        </div>
</asp:Content>

