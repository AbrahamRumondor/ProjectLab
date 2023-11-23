<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateRamen.aspx.cs" Inherits="ProjectLab.Views.UpdateRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <h1>Update Ramen</h1>
        </div>

        <div>
            <p>Name:  <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox></p>
            <p>Meat: 
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></p>
            <p>Broth:  <asp:TextBox ID="TextBox_broth" runat="server"></asp:TextBox></p>
            <p>Price:  <asp:TextBox ID="TextBox_price" runat="server"></asp:TextBox></p>
            <br />
            <asp:Button ID="Button_UpdateRamen" runat="server" Text="Update Ramen" OnClick="Button_UpdateRamen_Click"/>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server">Click here to go back</asp:HyperLink>

            <br />
            <br />
            <br />
        </div>
</asp:Content>
