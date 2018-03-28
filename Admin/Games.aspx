<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Games.aspx.cs" Inherits="Admin_Games" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server" enctype="multipart/form-data">
        <asp:Label Text="" runat="server" ID="lblErrors" />
        <asp:GridView
            ID="GridView1"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="id"
            DataSourceID="GamesSqlDataSource"
            ShowFooter="True"
            CellPadding="4"
            ForeColor="#333333"
            GridLines="None"
            ShowHeaderWhenEmpty="True"
            OnRowUpdating="GridView1_OnRowUpdating"
            OnRowCommand="GridView1_RowCommand"
        >
            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />

                <asp:TemplateField HeaderText="ID" SortExpression="id">
                    <EditItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CommandName="Insert" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Title" SortExpression="title">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNewTitle" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Description" SortExpression="description">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="multiline" Columns="50" Rows="5" Text='<%# Bind("description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox TextMode="multiline" ID="txtNewDescription" runat="server" Columns="55" Rows="10" ></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Price" SortExpression="price">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("price") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        £<asp:Label ID="lblPrice" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNewPrice" runat="server" type="number"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Release Date" SortExpression="release_date">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtReleaseDate" runat="server" Text='<%# Bind("release_date") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblReleaseDate" runat="server" Text='<%# Bind("release_date") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNewReleaseDate" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Age Rating" SortExpression="age_rating">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAge" runat="server" Text='<%# Bind("age_rating") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAge" runat="server" Text='<%# Bind("age_rating") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNewAge" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Image">
                    <EditItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Width="100" />
                        <asp:HiddenField ID="hdnOldImage" runat="server" Value='<%# Eval("image") %>' />
                        <asp:FileUpload ID="fileImage" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Width="150"/>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fileNewImage" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="GamesSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
            OldValuesParameterFormatString="original_{0}"
            ConflictDetection="OverwriteChanges"
            SelectCommand="SELECT * FROM [Games]"
            DeleteCommand="DELETE FROM [Games] WHERE [id] = @original_id"
            InsertCommand="INSERT INTO [Games] ([title], [description], [price], [release_date], [age_rating], [image]) VALUES (@title, @description, @price, CONVERT(DATE, @release_date, 103), @age_rating, @image)"
            UpdateCommand="UPDATE [Games] SET [title] = @title, [description] = @description, [price] = @price, [release_date] = CONVERT(DATE, @release_date, 103), [age_rating] = @age_rating, [image] = @image WHERE [id] = @original_id">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="release_date" />
                <asp:Parameter Name="age_rating" Type="String" />
                <asp:Parameter Name="image" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="release_date" />
                <asp:Parameter Name="age_rating" Type="String" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="original_id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </form>
</asp:Content>

