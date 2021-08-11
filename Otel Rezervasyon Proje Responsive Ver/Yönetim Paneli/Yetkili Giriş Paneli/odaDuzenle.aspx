<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Yetkili Giriş Paneli/YetkiliGirisMaster.master" AutoEventWireup="true" CodeFile="odaDuzenle.aspx.cs" Inherits="odaDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div id="page-wrapper">
			<div class="main-page">
				<div class="forms">
    	<div class=" form-grids row form-grids-right">
						<div class="widget-shadow " data-example-id="basic-forms"> 
                            							<div class="form-title">
								<h4>Oda Düzenleme :</h4>
							</div>
							<div class="form-body">
                                     <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">İşlem Yapılan Kat</asp:Label>
                             <div class="col-sm-9">
                                   <asp:DropDownList class="form-control" runat="server" ID="drpİslemYapilanKat" OnSelectedIndexChanged="drpİslemYapilanKat_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                             </div>
							 </div> 
                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">İşlem Yapılan Oda</asp:Label>
                             <div class="col-sm-9">
                                   <asp:DropDownList class="form-control" runat="server" ID="drpİslemYapilanOda" AutoPostBack="True" OnSelectedIndexChanged="drpİslemYapilanOda_SelectedIndexChanged" ></asp:DropDownList>
                             </div>
							 </div> 
                                 <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Oda Tip</asp:Label>
                             <div class="col-sm-9">
                                   <asp:DropDownList class="form-control" runat="server" ID="drpOdaTip" AutoPostBack="True" OnSelectedIndexChanged="drpOdaTip_SelectedIndexChanged" ></asp:DropDownList>
                             </div>
							 </div> 
                             <div class="form-group">
                             <asp:Label runat="server" for="inputEmail3" class="col-sm-2 control-label">Tip Açıklama</asp:Label>
                             <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtTipAciklama" class="form-control" placeholder="Oda tipi açıklama" Height="194px" TextMode="MultiLine" Width="416px" AutoPostBack="True"></asp:TextBox>
                             </div>
							 </div> 
                                                             <div class="col-sm-offset-2"> 
                             <asp:Button  class="btn btn-default" Text="Kaydet" runat="server"  style="background-color:#F2B33F;color:#fff" ID="btnOdaDuzenle" OnClick="btnOdaDuzenle_Click"/>&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                             </div>
                            </div>
            </div>
                    </div>
                </div>
             </div>
    </div>
</asp:Content>

