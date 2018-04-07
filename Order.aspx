<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <div class="order">
            <div class="order-header">
                <h2 id="orderRef" runat="server"></h2>
                <div ID="lblPrice" runat="server"></div>
                <div ID="lblDate" runat="server"></div>
            </div>
            <div class="order-body">
                <ul id="orderItems" class="order-items" runat="server"></ul>
            </div>
        </div>
    </form>
</asp:Content>

