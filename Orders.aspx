<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <h1>Your Orders</h1>
        <ul id="ulOrders" class="orders" runat="server">

        </ul>
    </form>
</asp:Content>

