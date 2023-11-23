<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectLab.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register</h1>
        </div>

        <div>
            <p>Username:  <asp:TextBox ID="TextBox_username" runat="server"></asp:TextBox></p>
            <p>Email:  <asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox></p>
            <p>Gender: &nbsp;&nbsp;<asp:RadioButton ID="Male" runat="server" GroupName="GenderGroup" />Male &nbsp; <asp:RadioButton ID="Female" runat="server" GroupName="GenderGroup" />Female</p>
            <p>Password:  <asp:TextBox ID="TextBox_password" runat="server"></asp:TextBox></p>
            <p>Confirmation Password:  <asp:TextBox ID="TextBox_passwordConfirmation" runat="server"></asp:TextBox></p>
            <br />
            <asp:Button ID="Button_register" runat="server" Text="Register" OnClick="Button_register_Click" />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Login.aspx">Click here if already have an account!</asp:HyperLink>
        </div>
    </form>
</body>
</html>
