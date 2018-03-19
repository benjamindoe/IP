<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <asp:Label Text="" runat="server" ID="lblErrors" />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="UsersDataSource" 
            OnRowCommand="GridView1_RowCommand" ShowFooter="True" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="id">
                    <EditItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CommandName="Insert" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Username" SortExpression="username">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("username") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNewUsername" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Is Admin" SortExpression="is_admin">
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkAdmin" runat="server" Checked='<%# Bind("is_admin") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("is_admin")  %>' runat="server" />
                        <asp:CheckBox ID="chkAdmin" runat="server" Checked='<%# Eval("is_admin").ToString() == "True" %>' Enabled="false" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="chkNewAdmin" runat="server"></asp:CheckBox>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource
            ID="UsersDataSource"
            runat="server"
            ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
            DeleteCommand="DELETE FROM [Users] WHERE [id] = @original_id AND [username] = @original_username AND (([is_admin] = @original_is_admin) OR ([is_admin] IS NULL AND @original_is_admin IS NULL))"
            InsertCommand="INSERT INTO [Users] ([username],[password], [is_admin]) VALUES (@username, @password, @is_admin)"
            OldValuesParameterFormatString="original_{0}"
            SelectCommand="SELECT [id], [username], [is_admin] FROM [Users]"
            UpdateCommand="UPDATE [Users] SET [username] = @username, [is_admin] = @is_admin WHERE [id] = @original_id AND [username] = @original_username AND (([is_admin] = @original_is_admin) OR ([is_admin] IS NULL AND @original_is_admin IS NULL))"
        >
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_username" Type="String" />
                <asp:Parameter Name="original_is_admin" Type="Boolean" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="is_admin" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="is_admin" Type="Boolean" />
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_username" Type="String" />
                <asp:Parameter Name="original_is_admin" Type="Boolean" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>

</asp:Content>

