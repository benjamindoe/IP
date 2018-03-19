<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="" ID="lblMsg" runat="server" />

            <asp:Label Text="Username" runat="server" AssociatedControlID="txtUsername" />
            <asp:TextBox runat="server" ID="txtUsername" />
            <asp:Label Text="Password" runat="server" AssociatedControlID="txtPassword" />
            <asp:TextBox runat="server" ID="txtPassword" type="password"/>
            <asp:Label Text="Confirm Password" runat="server" AssociatedControlID="txtConfirmPassword" />
            <asp:TextBox runat="server" ID="txtConfirmPassword" type="password"/>
            <asp:Button Text="Register" runat="server" ID="btnRegister" OnClick="btnRegister_Click"/>
        </div>
    </form>
</asp:Content>

