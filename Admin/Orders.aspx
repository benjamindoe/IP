<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Admin_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form runat="server" id="form1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="OrdersDataSource" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="user_id" HeaderText="user_id" SortExpression="user_id" />
                <asp:BoundField DataField="subtotal" HeaderText="subtotal" SortExpression="subtotal" />
                <asp:BoundField DataField="date" DataFormatString="{0:&quot;dd/mm/YYYY&quot;}" HeaderText="date" SortExpression="date" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="OrdersDataSource" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" DeleteCommand="DELETE FROM [Orders] WHERE [id] = @original_id AND [user_id] = @original_user_id AND [subtotal] = @original_subtotal AND [date] = @original_date" InsertCommand="INSERT INTO [Orders] ([id], [user_id], [subtotal], [date]) VALUES (@id, @user_id, @subtotal, @date)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Orders]" UpdateCommand="UPDATE [Orders] SET [user_id] = @user_id, [subtotal] = @subtotal, [date] = @date WHERE [id] = @original_id AND [user_id] = @original_user_id AND [subtotal] = @original_subtotal AND [date] = @original_date">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_user_id" Type="Int32" />
                <asp:Parameter Name="original_subtotal" Type="Decimal" />
                <asp:Parameter DbType="Date" Name="original_date" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="user_id" Type="Int32" />
                <asp:Parameter Name="subtotal" Type="Decimal" />
                <asp:Parameter DbType="Date" Name="date" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="user_id" Type="Int32" />
                <asp:Parameter Name="subtotal" Type="Decimal" />
                <asp:Parameter DbType="Date" Name="date" />
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_user_id" Type="Int32" />
                <asp:Parameter Name="original_subtotal" Type="Decimal" />
                <asp:Parameter DbType="Date" Name="original_date" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</asp:Content>

