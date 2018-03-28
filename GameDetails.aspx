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
            <div class="left-col">
                <img src="/" class="game-image" id="GameImage" runat="server"/>
            </div>
            <div class="right-col">
                <h2 runat="server" id="GameTitle"></h2>
                <p runat="server" id="GameDesc" class="game-description"></p>
                <div class="price-area">
                    <p class="price-area_price">
                        Price: <span runat="server" id="GamePrice" class=""></span>
                    </p>
                    <asp:Button Text="ADD TO BASKET" id="btnAddBasket" runat="server" OnClick="btnAddBasket_Click" class="btn-add-basket" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>

