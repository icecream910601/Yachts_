<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Yachts_.Login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet/less" type="text/css" href="all.less" />
    <script src="less.js" type="text/javascript"></script>

</head>

<body>

    <div class="wrapper">
        <div class="container">
            <h1>Welcome</h1>

            <form class="form" runat="server">
                <asp:TextBox ID="Email" runat="server" placeholder="Email"></asp:TextBox>
                <%-- <input type="text" placeholder="Username">--%>
                <asp:TextBox ID="Password" runat="server" placeholder="Password" MaxLength="10" TextMode="Password"></asp:TextBox>
                <%--<input type="password" placeholder="Password">--%>
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                <%--<button type="submit" id="login-button">Login</button>--%>
            </form>
        </div>

        <ul class="bg-bubbles">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
    </div>





    <!-- JavaScript Bundle with Popper -->

    <script src="https://cdnjs.cloudflare.com/ajax/libs/less.js/3.8.1/less.min.js"></script>
    <script src="all.js"></script>
    <script>$("#login-button").click(function (event) {
            event.preventDefault();

            $('form').fadeOut(500);
            $('.wrapper').addClass('form-success');
        });</script>

</body>

</html>
