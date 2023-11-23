<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectLab.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Log In</h1>
        </div>

        <br />

        <div>
            <p>Username: <asp:TextBox ID="TextBox_username" runat="server"></asp:TextBox></p>
            <p>Password: <asp:TextBox ID="TextBox_password" runat="server"></asp:TextBox></p>
            <br />
            <asp:Button ID="Button_login" runat="server" Text="Log In" onclick="Button_login_Click"/>
            <br />
            <p><asp:CheckBox ID="RememberMe" runat="server" />Remember me</p>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Register.aspx">Click here if dont have an account</asp:HyperLink>
        </div>
    </form>
</body>
</html>
