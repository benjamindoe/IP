<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="Basket.aspx.cs" Inherits="Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form runat="server" id="form1">
        <div class="basket">
        <h1>Shopping Basket</h1>
            <div class="basket-header">
                <span class="header-item header-item-details">Product</span>
                <span class="header-item header-item-price">Price</span>
                <span class="header-item header-item-quantity">Quantity</span>
            </div>
            <div class="basket-inner" id="BasketContent" runat="server"></div>
            <asp:Button ID="btnCheckout" Text="Checkout" runat="server" CssClass="btn btn-checkout" OnClick="btnCheckout_Click"/>
            <a href="/">Continue shopping</a>
            <asp:Label ID="lblSubtotal" runat="server" CssClass="basket-subtotal"></asp:Label>
        </div>
    </form>
</asp:Content>

