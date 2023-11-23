<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="ProjectLab.Views.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <h1>Profile Update</h1>
        </div>

        <div>
            <p>Username:  <asp:TextBox ID="TextBox_username" runat="server"></asp:TextBox></p>
            <p>Email:  <asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox></p>
            <p>Gender: &nbsp;&nbsp;<asp:RadioButton ID="Male" runat="server" GroupName="GenderGroup" />Male &nbsp; <asp:RadioButton ID="Female" runat="server" GroupName="GenderGroup" />Female</p>
            <p>Password Confirmation:  <asp:TextBox ID="TextBox_password" runat="server"></asp:TextBox></p>
            <br />
            <asp:Button ID="Button_update" runat="server" Text="Done" OnClick="Button_update_Click" />
            <br />
        </div>
</asp:Content>
