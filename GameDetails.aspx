<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="GameDetails.aspx.cs" Inherits="GameDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form runat="server" id="form1">
        <div class="game">
            <asp:HiddenField runat="server" ID="hdnID"/>
            <asp:HiddenField runat="server" ID="hdnTitle"/>
            <asp:HiddenField runat="server" ID="hdnDescription"/>
            <asp:HiddenField runat="server" ID="hdnPrice"/>
            <asp:HiddenField runat="server" ID="hdnImage"/>

            <img src="/" class="game-image" id="GameImage" runat="server"/>
            <h2 runat="server" id="GameTitle"></h2>
            <p runat="server" id="GameDesc"></p>
            <span runat="server" id="GamePrice"></span>
            <asp:Button Text="Add to Basket" id="btnAddBasket" runat="server" OnClick="btnAddBasket_Click" style="height: 29px" />
        </div>
    </form>
</asp:Content>

