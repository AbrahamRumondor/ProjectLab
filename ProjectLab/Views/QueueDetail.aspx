<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="QueueDetail.aspx.cs" Inherits="ProjectLab.Views.QueueDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Queue Detail</h1>

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
        <br />
                Total Harga Pesanan: <asp:Label ID="Label_totalHarga" runat="server" Text="$ 0"></asp:Label>
    <br />
    </div>
    <h3><asp:Label ID="Label_handle" runat="server" Text="-" Visible="false"></asp:Label></h3>
    <asp:Button ID="Button_Handle" runat="server" Text="Transaction Done" Visible="true" OnClick="Button_Handle_Click" Height="33px" Width="138px"/>
        <br /><asp:HyperLink ID="HyperLink_TH" runat="server">Click here to go back to Transaction History</asp:HyperLink>

    
    

</asp:Content>
