<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Yetkili Giriş Paneli/YetkiliGirisMaster.master" AutoEventWireup="true" CodeFile="odaEkle.aspx.cs" Inherits="odaEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="page-wrapper">
			<div class="main-page">
				<div class="forms">
    	<div class=" form-grids row form-grids-right">
						<div class="widget-shadow " data-example-id="basic-forms"> 
							<div class="form-title">
								<h4>Oda Ekleme :</h4>
							</div>
							<div class="form-body">
                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Kat Sayısı</asp:Label>
                                     
                             <div class="col-sm-9" style="float:left;width:500px">
                                 <asp:TextBox runat="server"  ID="txtKatSayisi" class="form-control" placeholder="Otel'de bulunan kat sayısı"  AutoPostBack="True"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtKatSayisi" ForeColor="Red"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtKatSayisi" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>

                             </div>
                                        <div class="col-sm-offset-2"> 
                                 <asp:Button  class="btn btn-default" CausesValidation="False" Text="Kat Ekle" runat="server"  style="background-color:#F2B33F;color:#fff" ID="btnKatOnayla" Height="35px" OnClick="btnKatOnayla_Click"/>
							 </div> 
                                     </div>
                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">İşlem Yapılan Kat</asp:Label>
                             <div class="col-sm-9">
                                   <asp:DropDownList class="form-control" runat="server" ID="drpKatSayisi" AutoPostBack="false" OnSelectedIndexChanged="drpKatSayisi_SelectedIndexChanged"  ></asp:DropDownList>
                             </div>
							 </div> 
                                  <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Oda Sayısı</asp:Label>
                             <div class="col-sm-9" style="float:left;width:500px">
                                 <asp:TextBox runat="server" ID="txtOdaSayisi" class="form-control" placeholder="Oda Sayısı"  AutoPostBack="True"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen bu alanı boş bırakmayınız." ControlToValidate="txtOdaSayisi" ForeColor="Red"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtOdaSayisi" runat="server" ErrorMessage="Sadece rakam giriniz." ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>

                             </div>
                                        <div class="col-sm-offset-2"> 
                                 <asp:Button  class="btn btn-default" Text="Oda Ekle" runat="server" CausesValidation="False" style="background-color:#F2B33F;color:#fff" ID="btnOdaOnayla" Height="35px" OnClick="btnOdaOnayla_Click"/>
							 </div> 
                                     </div>
                                 <div class="form-group" >
                                       <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Odalar</asp:Label>
                                     <div class="col-sm-9"  style="float:left">
                                 
                                         <div style="border:1px solid #fff;padding:5px 0 0 5px;" class="widget-shadow ">
				              <asp:CheckBoxList runat="server" ID="chkOdalar">
				              </asp:CheckBoxList>
                                             </div>
                             </div>
                                 </div> 
                                                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Odanın Tipi</asp:Label>
                             <div class="col-sm-9">
                                   <asp:DropDownList class="form-control" runat="server" ID="drpOdaTip" AutoPostBack="True" OnSelectedIndexChanged="drpOdaTip_SelectedIndexChanged" ></asp:DropDownList>
                             </div>
							 </div> 
                                                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Tip Açıklama</asp:Label>
                             <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtTipAciklama" class="form-control" placeholder="Oda tipi açıklama" Height="194px" TextMode="MultiLine" Width="416px" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                             </div>
							 </div> 
                             <div class="col-sm-offset-2"> 
                             <asp:Button  class="btn btn-default" Text="Oda Ekle" runat="server"  style="background-color:#F2B33F;color:#fff" ID="btnOdaEkle" OnClick="btnOdaEkle_Click"/>&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                             </div>
                              
							</div>
						</div>
					</div>
                    </div>
                </div>
            </div>
</asp:Content>

