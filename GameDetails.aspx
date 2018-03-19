<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="GameDetails.aspx.cs" Inherits="GameDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form runat="server" id="form1">
        <div class="game">
            <img src="/" class="game-image" id="GameImage" runat="server"/>
            <h2 runat="server" id="GameTitle"></h2>
            <p runat="server" id="GameDesc"></p>
            <asp:Button Text="Add to Basket" id="btnAddBasket" runat="server" />
        </div>
    </form>
</asp:Content>

