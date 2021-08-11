<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rezervasyonBilgileri.aspx.cs" Inherits="rezervasyonBilgileri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/soncss.css" rel="stylesheet" />
 <script type="text/javascript">
     history.pushState(null, null, location.href);
     window.onpopstate = function () {
         history.go(1);
     };
    </script>

</head>
<body>
    <form id="form1" runat="server">
  <div class="banner">
 <asp:Image ImageUrl="images/deu.png" runat="server" CssClass="logo" /><p class="p">DOKUZ EYLÜL ÜNİVERSİTESİ</p>
        </div>
        <center>
            <div class="rezSorgulamaGovde">
                <p style="color:#fff;font:bold 16px 'Century Gothic';">REZERVASYON BİLGİLERİ (<asp:Label runat="server" ID="lblKisiBilgisiSayac"></asp:Label>.Kişi)</p>
                <div class="rezSorgula">
                    <table>
                        <tr>
                            <td>
                                 <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Ad :</p>
                            </td>
                            <td>
                                        <asp:textbox runat="server" ID="txtAd" CssClass="txt" MaxLength="25"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtAd" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAd" ErrorMessage="*" ValidationExpression="[a-zA-Z\sçÇğĞıİöÖşŞüÜ]+" ForeColor="Red"></asp:RegularExpressionValidator>
                            </td>
                             <td>
                                  <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Soyad :</p>
                            </td>
                            <td>
                                       <asp:textbox runat="server" ID="txtSoyad" CssClass="txt" MaxLength="25"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtSoyad" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSoyad" ErrorMessage="*" ValidationExpression="[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+" ForeColor="Red"></asp:RegularExpressionValidator>

                            </td>
                           
                        </tr>
                        <tr>
                            <td>
                                  <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">E Posta :</p>
                            </td>
                            <td>
                                         <asp:textbox runat="server" ID="txtEposta" CssClass="txt" MaxLength="30"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEposta" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEposta" ErrorMessage="*" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ForeColor="Red"></asp:RegularExpressionValidator>
                            </td>
                                <td>
                                  <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Cep Telefonu :</p>
                                    
                            </td>
                            <td>
                                         <asp:textbox runat="server" ID="txtCepTel" CssClass="txt" MaxLength="15" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtCepTel" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtCepTel" runat="server" ErrorMessage="*" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                            </td>

                        </tr>
                          <tr>
                            <td>
                                       <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Cinsiyet :</p>
                            </td>
                            <td>
                                         <asp:RadioButton runat="server" ID="radErkek" CssClass="chkOzellik" Text="Erkek" GroupName="cinsiyet" />&nbsp;&nbsp;
                                         <asp:RadioButton runat="server" ID="radKadin" CssClass="chkOzellik" Text="Kadın" GroupName="cinsiyet"  />
                            </td>
                        </tr>
                          <tr>
                           <td><br /></td>
                        </tr>
                          <tr>
                            <td>
                                        <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Ülke :</p>
                            </td>
                            <td>
                                         <asp:DropDownList runat="server" ID="drpUlke" CssClass="drp" DataSourceID="localhost" DataTextField="value" DataValueField="value"  />
                                         <asp:SqlDataSource ID="localhost" runat="server" ConnectionString="<%$ ConnectionStrings:OtelRezervasyonConnectionString %>" SelectCommand="SELECT [value] FROM [Ulkeler] ORDER BY value Asc"></asp:SqlDataSource>
                            </td>
                               <td>
                                       <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Uyruk :</p>
                            </td>
                            <td>
                                         <asp:DropDownList runat="server" ID="drpUyruk" CssClass="drp"  DataSourceID="SqlDataSource1" DataTextField="value" DataValueField="value"   />
                                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OtelRezervasyonConnectionString %>" SelectCommand="SELECT [value] FROM [Ulkeler] ORDER BY value Asc"></asp:SqlDataSource>

                            </td>
                        </tr>
                          <tr>
                           <td><br /></td>
                        </tr>
                          <tr>
                            <td>
                                      <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Geliş Tarihi :</p>
                            </td>
                            <td>
                                         <asp:textbox runat="server" ID="txtGelis" CssClass="txt" ReadOnly="True"  />
                            </td>
                                                        <td>
                                        <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Gidiş Tarihi :</p>
                            </td>
                            <td>
                                         <asp:textbox runat="server" ID="txtGidis" CssClass="txt" ReadOnly="True"  />
                            </td>
                        </tr>
                          <tr>
                            <td>
                                        <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">İndirim Oranı :</p>
                            </td>
                            <td>
                                         <asp:textbox runat="server" ID="txtIndirim" CssClass="txt" ReadOnly="True"  />
                            </td>
                              <td>
                                        <p style="color:#002B41;font:bold 16px 'Century Gothic';float:left;margin-right:10px;">Fiyat :</p>

                            </td>
                            <td>
                                         <asp:textbox runat="server" ID="txtFiyat" CssClass="txt" ReadOnly="True"  />
                            </td>
                        </tr>
                        <tr><td> </td><td> </td><td> </td><td> <p style="color:#002B41;font:bold 12px 'Century Gothic';float:left;margin-right:10px;">*Varsa indirim dahildir.</p></td></tr>
                        <tr>
                            <td style="text-align:left;"><br /><div class="btn"><asp:LinkButton CausesValidation="False"  Style="vertical-align:central" width="100px" data-hover="İptal Et" class="rez" runat="server" ID="btnIptal" OnClick="IptalClick">İptal Et</asp:LinkButton></div></td><td></td><td></td>
                            <td><br />
                                                    <div class="btn"><asp:LinkButton data-hover="Onayla" class="rez" runat="server" ID="OnaylaButon" OnClick="OnaylaClick">Onayla</asp:LinkButton></div>
                            </td>
                        </tr>
                    </table>
</div>
          
                </div>
           
        </center>
    </form>
</body>
</html>
