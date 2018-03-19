<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="fmLogin" class="fm-form fm-form-login" runat="server">
        <div class="fm-wrapper">
            <asp:Label Text="" ID="lblMsg" runat="server" />
            <div class="fm-control">
                <asp:Label Text="Username" runat="server" AssociatedControlID="txtUsername" CssClass="fm-lbl"/>
                <asp:TextBox runat="server" ID="txtUsername" CssClass="fm-input" placeholder="Username"/>
            </div>
            <div class="fm-control">
                <asp:Label Text="Password" runat="server" AssociatedControlID="txtPassword" CssClass="fm-lbl" />
                <asp:TextBox runat="server" ID="txtPassword" type="password" CssClass="fm-input" placeholder="Password"/>
            </div>
            <div class="fm-control">
                <asp:Button Text="Login" ID="btnLogin" runat="server" OnClick="btnLogin_Click" />
                <a href="/Register.aspx">Register</a> 
            </div>
        </div>
    </form>
</asp:Content>

