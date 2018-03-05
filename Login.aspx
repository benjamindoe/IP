<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <asp:Label Text="" ID="lblMsg" runat="server" />

        <asp:Label Text="Username" runat="server" AssociatedControlID="txtUsername" />
        <asp:TextBox runat="server" ID="txtUsername"/>
        <asp:Label Text="Password" runat="server" AssociatedControlID="txtPassword" />
        <asp:TextBox runat="server" ID="txtPassword" type="password"/>
        <asp:Button Text="Login" ID="btnLogin" runat="server" OnClick="btnLogin_Click" />
        <a href="/Register.aspx">Click here to Register</a> 
    </form>
</asp:Content>

