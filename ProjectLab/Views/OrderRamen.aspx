<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="ProjectLab.Views.OrderRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <h1>Raamen Menu</h1>

    <div>
        <asp:GridView ID="GridViewMENU" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewMENU_RowEditing" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Ramen Id" SortExpression="id" />
                <asp:BoundField DataField="Name" HeaderText="Ramen Name" SortExpression="Name" />
                <asp:BoundField DataField="Meat.name" HeaderText="Meat" SortExpression="Meat.name" />
                <asp:BoundField DataField="Broth" HeaderText="Broth" SortExpression="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="" ShowHeader="True" Text="  +  "/>
            </Columns>
        </asp:GridView>
    </div>

    <br />
    <h1>Ramen in Cart</h1>
        <div>
        <asp:GridView ID="GridViewCART" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewCART_RowEditing" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="ramenID" HeaderText="Ramen Id" SortExpression="getRamenId()" />
                <asp:BoundField DataField="ramenName" HeaderText="Name" SortExpression="getRamenName()" />
                <asp:BoundField DataField="ramenMeat" HeaderText="Meat" SortExpression="getramenMeat()" />
                <asp:BoundField DataField="ramenBroth" HeaderText="Broth" SortExpression="getRamenBroth()" />
                <asp:BoundField DataField="ramenPrice" HeaderText="Price" SortExpression="getramenPrice()" />
                <asp:BoundField DataField="ramenQuantity" HeaderText="Quantity" SortExpression="getRamenQty()" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="" ShowHeader="True" Text="  -  " />
            </Columns>
        </asp:GridView>
    </div>
    <h3 style="color: orangered"><asp:Label ID="cartStatus" runat="server" Text="Cart is currently Empty" Visible="true"></asp:Label></h3>
    <br /><br />
    Total Harga Pesanan: <asp:Label ID="Label_totalHarga" runat="server" Text="$ 0"></asp:Label>
    <br />
    <p><asp:Button ID="Button_BuyAll" runat="server" Text="Buy All Ramen in Cart" onclick="Button_BuyAll_Click"/>
     &nbsp &nbsp &nbsp <asp:Button ID="Button_ClearAll" runat="server" Text="Clear All Ramen in Cart" OnClick="Button_ClearAll_Click"/></p>

</asp:Content>
