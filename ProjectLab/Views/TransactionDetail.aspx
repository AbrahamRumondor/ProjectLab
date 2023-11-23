<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="ProjectLab.Views.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Detail</h1>

    <h3>
        <b></b>Header Id : <asp:Label ID="Label_HeaderId" runat="server" Text="-"></asp:Label><br />
        Customer : <asp:Label ID="Label_Customer" runat="server" Text="-"></asp:Label><br />
        Assigned Staff Id = <asp:Label ID="Label_Staff" runat="server" Text="-"></asp:Label><br />
        Order's Date : <asp:Label ID="Label_Date" runat="server" Text="-"></asp:Label>
    </h3>
    <br />
    <div>
        <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="Ramenid" HeaderText="Ramen Id" SortExpression="Ramenid" />
                <asp:BoundField DataField="Raman.Name" HeaderText="Name" SortExpression="Ramen.Name" />
                <asp:BoundField DataField="Raman.Broth" HeaderText=" Broth " SortExpression="Ramen.Broth" />
                <asp:BoundField DataField="Raman.Price" HeaderText="Price" SortExpression="Ramen.Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
        Total Harga Pesanan: <asp:Label ID="Label_totalHarga" runat="server" Text="$ 0"></asp:Label>
    <br /><br>
    <asp:HyperLink ID="HyperLink_TH" runat="server">Click here to go back to Transaction History</asp:HyperLink>

</asp:Content>
