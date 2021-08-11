<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rezervasyonBilgileri.aspx.cs" Inherits="rezervasyonBilgileri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"  lang="en">
<head runat="server">
    <title></title>
        <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">


    <link href="css/StyleSheet5.css" rel="stylesheet" />

 <script type="text/javascript">
     history.pushState(null, null, location.href);
     window.onpopstate = function () {
         history.go(1);
     };
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <center>
        <div class="row">
            <div class="col-md-12">
  <div class="banner" style="height:65px">

 <asp:Image ImageUrl="images/deu.png" runat="server" CssClass="logo" /><p style="margin-top: 0px; color: #002B41; font: bold 20px 'Century Gothic';">DOKUZ EYLÜL ÜNİVERSİTESİ</p>      </div> 
        </div></div>
            <div class="row">
             <div class="col-auto col-sm-3"></div> <div class="col-12 col-sm-6">
            <div class="rezSorgulamaGovde">
                <p style="color:#fff;font:bold 16px 'Century Gothic';">REZERVASYON BİLGİLERİ (<asp:Label runat="server" ID="lblKisiBilgisiSayac"></asp:Label>.Kişi)</p>
                <div class="rezSorgula">
                    <div class="col col-sm col-md-1"></div>
                    <div class="col col-sm col-md-10">
                        <div class="row">
                            <div class="col-6 col-sm-6 col-md-3">
                                 <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Ad :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                        <asp:textbox runat="server" ID="txtAd" CssClass="txt" MaxLength="25"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtAd" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAd" ErrorMessage="*" ValidationExpression="[a-zA-Z\sçÇğĞıİöÖşŞüÜ]+" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                  <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Soyad :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                       <asp:textbox runat="server" ID="txtSoyad" CssClass="txt" MaxLength="25"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtSoyad" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSoyad" ErrorMessage="*" ValidationExpression="[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+" ForeColor="Red"></asp:RegularExpressionValidator>

                            </div>
                           
                        </div>
                        <div class="row">
                            <div class="col-6 col-sm-6 col-md-3">
                                  <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">E Posta :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:textbox runat="server" ID="txtEposta" CssClass="txt" MaxLength="30"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEposta" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEposta" ErrorMessage="*" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                  <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Cep Telefonu :</p>
                                    
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:textbox runat="server" ID="txtCepTel" CssClass="txt" MaxLength="15" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtCepTel" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtCepTel" runat="server" ErrorMessage="*" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                          <div class="row">
                            <div class="col-6 col-sm-6 col-md-3">
                                       <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Cinsiyet :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:RadioButton runat="server" ID="radErkek" CssClass="chkOzellik" Text="Erkek" GroupName="cinsiyet" />&nbsp;&nbsp;
                                         <asp:RadioButton runat="server" ID="radKadin" CssClass="chkOzellik" Text="Kadın" GroupName="cinsiyet"  />
                            </div>
                        </div>
                          <div class="row">
                           <div class="col-6 col-sm-6 col-md-3"><br /></div>
                        </div>
                          <div class="row">
                            <div class="col-6 col-sm-6 col-md-3">
                                        <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Ülke :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:DropDownList runat="server" ID="drpUlke" CssClass="drp" DataSourceID="localhost" DataTextField="value" DataValueField="value"  />
                                         <asp:SqlDataSource ID="localhost" runat="server" ConnectionString="<%$ ConnectionStrings:OtelRezervasyonConnectionString %>" SelectCommand="SELECT [value] FROM [Ulkeler] ORDER BY value Asc"></asp:SqlDataSource>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                       <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Uyruk :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:DropDownList runat="server" ID="drpUyruk" CssClass="drp"  DataSourceID="SqlDataSource1" DataTextField="value" DataValueField="value"   />
                                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OtelRezervasyonConnectionString %>" SelectCommand="SELECT [value] FROM [Ulkeler] ORDER BY value Asc"></asp:SqlDataSource>

                            </div>
                        </div>
                          <div class="row">
                           <div class="col-6 col-sm-6 col-md-3"><br /></div>
                        </div>
                          <div class="row">
                            <div class="col-6 col-sm-6 col-md-3">
                                      <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Geliş Tarihi :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:textbox runat="server" ID="txtGelis" CssClass="txt" ReadOnly="True"  />
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                        <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Gidiş Tarihi :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:textbox runat="server" ID="txtGidis" CssClass="txt" ReadOnly="True"  />
                            </div>
                        </div>
                          <div class="row">
                            <div class="col-6 col-sm-6 col-md-3">
                                        <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">İndirim Oranı :</p>
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:textbox runat="server" ID="txtIndirim" CssClass="txt" ReadOnly="True"  />
                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                        <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;">Fiyat :</p>

                            </div>
                            <div class="col-6 col-sm-6 col-md-3">
                                         <asp:textbox runat="server" ID="txtFiyat" CssClass="txt" ReadOnly="True"  />
                            </div>
                        </div>
                        <div class="row">   <div class="col-6 col-sm-6 col-md-3"> </div><div class="col-6 col-sm-6 col-md-3"> </div> <div class="col-6 col-sm-6 col-md-3"> </div><div class="col-6 col-sm-6 col-md-3"> <p style="color:#002B41;font:bold 12px 'Century Gothic';float:left;margin-right:10px;">*Varsa indirim dahildir.</p></div></div>
                        <div class="row">
                            <div class="col-12 col-sm-12 col-md-3"><br /> <div style="height: 40px; overflow: hidden; display: inline-block;"><asp:LinkButton data-hover="Onayla" class="rez" runat="server" ID="OnaylaButon" OnClick="OnaylaClick">Onayla</asp:LinkButton></div></div><div class="col col-sm col-md-3"></div><div class="col col-sm col-md-3"></div>
                            <div class="col-12 col-sm-12 col-md-3"><br />
                                                   <div style="height: 40px; overflow: hidden; display: inline-block;"><asp:LinkButton CausesValidation="False"  Style="vertical-align:central" width="100px" data-hover="İptal Et" class="rez" runat="server" ID="btnIptal" OnClick="IptalClick">İptal Et</asp:LinkButton></div>
                            </div>
                        </div>
</div>                    <div class="col col-sm col-md-1"></div>
          
                </div></div>
           </div><div class="col-auto col-sm-3"></div> </div>

            </center>
    </form>
     <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</body>
</html>
