<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server" class="fm-form-register">
        <div class="fm-wrapper">
            <asp:Label Text="" ID="lblMsg" runat="server" />
            <div class="fm-control">
                <asp:Label Text="Username" runat="server" AssociatedControlID="txtUsername" CssClass="fm-lbl"/>
                <asp:TextBox runat="server" ID="txtUsername" CssClass="fm-input"/>
            </div>
            <div class="fm-control">
                <asp:Label Text="Password" runat="server" AssociatedControlID="txtPassword" CssClass="fm-lbl"/>
                <asp:TextBox runat="server" ID="txtPassword" type="password" CssClass="fm-input"/>
            </div>
            <div class="fm-control">
                <asp:Label Text="Confirm Password" runat="server" AssociatedControlID="txtConfirmPassword" CssClass="fm-lbl"/>
                <asp:TextBox runat="server" ID="txtConfirmPassword" type="password" CssClass="fm-input"/>
            </div>
            <div class="fm-control">
                <asp:Button Text="Register" runat="server" ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn"/>
            </div>
        </div>
    </form>
</asp:Content>

