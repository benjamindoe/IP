<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <div class="user-profile">
            <asp:Label ID="Message" runat="server"></asp:Label>
            <h2>Account Details</h2>
            <asp:TextBox ID="txtFirstname" runat="server" CssClass="fm-input" placeholder="First Name"></asp:TextBox>
            <asp:TextBox ID="txtSurname" runat="server" CssClass="fm-input" placeholder="Surname"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="fm-input" placeholder="Phone Number" pattern="^\s*\(?(020[7,8]{1}\)?[ ]?[1-9]{1}[0-9{2}[ ]?[0-9]{4})|(0[1-8]{1}[0-9]{3}\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{3})\s*$"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="fm-input" placeholder="Email" type="email"></asp:TextBox>
            <h3>Security</h3>
            <p>Fill these fields if you wish to change your password</p>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="fm-input" placeholder="New Password" type="password"></asp:TextBox>
            <asp:TextBox ID="txtPassword2" runat="server" CssClass="fm-input" placeholder="Confirm Password" type="password"></asp:TextBox>
            <div class="fm-footer">
                <asp:Button ID="Submit" CssClass="btn btn-submit" Text="Submit" runat="server" OnClick="Submit_Click"/>
            </div>
        </div>
        <div class="links">
            <a href="Orders.aspx">Your Orders</a>
        </div>
    </form>
</asp:Content>