<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Games.aspx.cs" Inherits="Admin_Games" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="GamesSqlDataSource" ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" ShowFooterWhenEmpty="true">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" />
                <asp:BoundField DataField="release_date" HeaderText="Release Date" SortExpression="release_date" />
                <asp:BoundField DataField="age_rating" HeaderText="Age Rating" SortExpression="age_rating" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" CellPadding="4" DataKeyNames="id" DataSourceID="GamesSqlDataSource" DefaultMode="Insert" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
            <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" />
                <asp:BoundField DataField="release_date" HeaderText="Release Date" SortExpression="release_date" />
                <asp:BoundField DataField="age_rating" HeaderText="Age Rating" SortExpression="age_rating" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="GamesSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
            SelectCommand="SELECT * FROM [Games]" ConflictDetection="CompareAllValues"
            DeleteCommand="DELETE FROM [Games] WHERE [id] = @original_id AND [title] = @original_title AND (([description] = @original_description) OR ([description] IS NULL AND @original_description IS NULL)) AND (([overall_rating] = @original_overall_rating) OR ([overall_rating] IS NULL AND @original_overall_rating IS NULL)) AND [price] = @original_price AND (([release_date] = @original_release_date) OR ([release_date] IS NULL AND @original_release_date IS NULL)) AND (([age_rating] = @original_age_rating) OR ([age_rating] IS NULL AND @original_age_rating IS NULL))"
            InsertCommand="INSERT INTO [Games] ([title], [description], [overall_rating], [price], [release_date], [age_rating]) VALUES (@title, @description, @overall_rating, @price, @release_date, @age_rating)" OldValuesParameterFormatString="original_{0}"
            UpdateCommand="UPDATE [Games] SET [title] = @title, [description] = @description, [overall_rating] = @overall_rating, [price] = @price, [release_date] = @release_date, [age_rating] = @age_rating WHERE [id] = @original_id AND [title] = @original_title AND (([description] = @original_description) OR ([description] IS NULL AND @original_description IS NULL)) AND (([overall_rating] = @original_overall_rating) OR ([overall_rating] IS NULL AND @original_overall_rating IS NULL)) AND [price] = @original_price AND (([release_date] = @original_release_date) OR ([release_date] IS NULL AND @original_release_date IS NULL)) AND (([age_rating] = @original_age_rating) OR ([age_rating] IS NULL AND @original_age_rating IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_title" Type="String" />
                <asp:Parameter Name="original_description" Type="String" />
                <asp:Parameter Name="original_overall_rating" Type="Byte" />
                <asp:Parameter Name="original_price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="original_release_date" />
                <asp:Parameter Name="original_age_rating" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="overall_rating" Type="Byte" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="release_date" />
                <asp:Parameter Name="age_rating" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="overall_rating" Type="Byte" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="release_date" />
                <asp:Parameter Name="age_rating" Type="String" />
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_title" Type="String" />
                <asp:Parameter Name="original_description" Type="String" />
                <asp:Parameter Name="original_overall_rating" Type="Byte" />
                <asp:Parameter Name="original_price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="original_release_date" />
                <asp:Parameter Name="original_age_rating" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </form>
</asp:Content>

