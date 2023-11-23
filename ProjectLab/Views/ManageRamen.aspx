<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="ProjectLab.Views.ManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Raamen</h1>

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Ramen Id" SortExpression="id" />
                <asp:BoundField DataField="Name" HeaderText="Ramen Name" SortExpression="Name" />
                <asp:BoundField DataField="Meat.name" HeaderText="Meat" SortExpression="Meat.name" />
                <asp:BoundField DataField="Broth" HeaderText="Broth" SortExpression="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:CommandField ButtonType="Button" HeaderText="Option" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>

    <br /><br />

    <asp:Button ID="Button_InsertNewRamen" runat="server" Text="Insert New Ramen" onclick="Button_InsertNewRamen_Click"/>
</asp:Content>
