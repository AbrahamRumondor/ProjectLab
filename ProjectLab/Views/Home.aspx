<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjectLab.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
        <div>
            <h1>Home</h1>
        </div>

        <div>
            <h2>Selamat Datang <asp:Label ID="Label_username" runat="server" Text="guest"></asp:Label>,</h2>
            <p>Saat ini role kamu adalah <asp:Label ID="Label_role" runat="server" Text="guest"></asp:Label></p>
        </div>
    <br />
    <asp:GridView ID="GridView_Customer" runat="server" Visible="False" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Customer id" SortExpression="id" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:GridView ID="GridView_Staff" runat="server" AutoGenerateColumns="false" Visible="false">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Staff id" SortExpression="id" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
    </asp:GridView>

</asp:Content>
