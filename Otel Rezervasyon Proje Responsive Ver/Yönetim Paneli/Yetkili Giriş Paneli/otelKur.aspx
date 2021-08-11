<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim Paneli/Yetkili Giriş Paneli/YetkiliGirisMaster.master" AutoEventWireup="true" CodeFile="otelKur.aspx.cs" Inherits="otelKur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="main-page">
            <div class="forms">
                <div class=" form-grids row form-grids-right">
                    <div class="widget-shadow " data-example-id="basic-forms">
                        <div class="form-title">
                            <h4>Otel Özellikleri</h4>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-8" style="padding-left: 100px; padding-top: 20px">
                                <span>Fitness : </span>
                                <asp:CheckBox runat="server" ID="chkFitness" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>İnternet Erişim : </span>
                                <asp:CheckBox runat="server" ID="chkInternetErisim" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Oda Servisi : </span>
                                <asp:CheckBox runat="server" ID="chkOdaServisi" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Restoran : </span>
                                <asp:CheckBox runat="server" ID="chkRestoran" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Yüzme Havuzu : </span>
                                <asp:CheckBox runat="server" ID="chkYuzmeHavuzu" class="checkbox-inline1" /><br />
                                <br />
                                <span>Sağlık Merkezi : </span>
                                <asp:CheckBox runat="server" ID="chkSaglikMerkezi" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Çocuk Tesisleri: </span>
                                <asp:CheckBox runat="server" ID="chkCocukTesisleri" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Otopark: </span>
                                <asp:CheckBox runat="server" ID="chkOtopark" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Toplantı Odası: </span>
                                <asp:CheckBox runat="server" ID="chkToplantiOdasi" class="checkbox-inline1" /><br />
                                <br />
                                <span>Evcil Hayvan: </span>
                                <asp:CheckBox runat="server" ID="chkEvcilHayvan" class="checkbox-inline1" />
                                <span>Bar: </span>
                                <asp:CheckBox runat="server" ID="chkBar" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Havaalanı Servisi: </span>
                                <asp:CheckBox runat="server" ID="chkHavaalanıServisi" class="checkbox-inline1" />&nbsp&nbsp&nbsp<span>Açık Büfe Kahvaltı: </span>
                                <asp:CheckBox runat="server" ID="chkAcikBufeKahvalti" class="checkbox-inline1" /><br />
                                <br />

                                <asp:Button class="btn btn-default" Text="Kaydet" runat="server" Style="background-color: #F2B33F; color: #fff" ID="btnOtelKur" OnClick="btnOtelKur_Click" />&nbsp&nbsp<asp:Label runat="server" ID="lblOnay" Visible="False" ForeColor="#32C867"></asp:Label>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

