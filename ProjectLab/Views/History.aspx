﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="ProjectLab.Views.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction History</h1>

    <div>
        <asp:GridView ID="GridViewMENU" runat="server" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" OnRowEditing="GridViewMENU_RowEditing">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Header Id" SortExpression="id" />
                <asp:BoundField DataField="User.Username" HeaderText="Customer" SortExpression="Customer.Username" />
                <asp:BoundField DataField="Staffid" HeaderText=" Assigned Staff Id " SortExpression="Staffid" />
                <asp:BoundField DataField="Date" HeaderText="Order's Date" SortExpression="Date" DataFormatString = "{0:dd/MM/yyyy}" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="" ShowHeader="True" Text="  View  "/>
            </Columns>
        </asp:GridView>
            <h3 style="color: orangered"><asp:Label ID="TransactionStatus" runat="server" Text="Sorry, We Couldn't Find Any Transaction Regarding Your Account" Visible="true"></asp:Label></h3>
    </div>


</asp:Content>
