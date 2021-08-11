<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Yönetim Giriş</title>
        <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=PT+Sans:400,700'/>
        <link rel="stylesheet" href="assets/css/reset.css"/>
        <link rel="stylesheet" href="assets/css/supersized.css"/>
        <link rel="stylesheet" href="assets/css/style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img src="images//deu.png" width="200" height="200"/>
            <h1>Yönetim Paneli</h1>
                <asp:TextBox ID="txtad" runat="server" CssClass="username" placeholder="Kullanıcı Adı"></asp:TextBox>
                <asp:TextBox ID="txtsifre" runat="server" CssClass="password" placeholder="Şifre" TextMode="Password"></asp:TextBox>
                <asp:Button ID="btn" runat="server" Text="Giriş" OnClick="btn_Click" />
        </div>
        <script src="assets/js/jquery-1.8.2.min.js"></script>
        <script src="assets/js/supersized.3.2.7.min.js"></script>
        <script src="assets/js/supersized-init.js"></script>
        <script src="assets/js/scripts.js"></script>
    </form>
</body>
</html>
