<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Games.aspx.cs" Inherits="Admin_Games" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server" enctype="multipart/form-data">
        <asp:Label Text="" runat="server" ID="lblErrors" />
        <asp:ValidationSummary ID="vsEdit" runat="server" />
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
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CommandName="Insert" ValidationGroup="vgInsert" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Title" SortExpression="title">
                    <EditItemTemplate>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title is Required"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:RequiredFieldValidator ID="rfvNewTitle" runat="server" ControlToValidate="txtNewTitle" ErrorMessage="Title is Required" ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNewTitle" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Description" SortExpression="description">
                    <EditItemTemplate>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description is Required"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="multiline" Columns="50" Rows="5" Text='<%# Bind("description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:RequiredFieldValidator ID="rfvNewDescription" runat="server" ControlToValidate="txtNewDescription" ErrorMessage="Description is Required" ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                        <asp:TextBox TextMode="multiline" ID="txtNewDescription" runat="server" Columns="55" Rows="10" ></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Price" SortExpression="price">
                    <EditItemTemplate>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price is Required"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("price") %>' type="number" step="0.01"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        £<asp:Label ID="lblPrice" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:RequiredFieldValidator ID="rfvNewPrice" runat="server" ControlToValidate="txtNewPrice" ErrorMessage="Price is Required" ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNewPrice" runat="server" type="number" step="0.01"></asp:TextBox>
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

                <asp:TemplateField HeaderText="Category" SortExpression="category">
                    <EditItemTemplate>
                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Select a Category"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlCategory" runat="server" SelectedValue='<%# Bind("category") %>'>
                            <asp:ListItem Text="--Select One--" Value="" /> 
                            <asp:ListItem Text="Shooter" Value="Shooter"/>
                            <asp:ListItem Text="Kids" Value="Kids" />
                            <asp:ListItem Text="Sports" Value="Sports"/>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("category") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:RequiredFieldValidator ID="rfvNewCategory" runat="server" ControlToValidate="ddlNewCategory" ErrorMessage="Select a Category" ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlNewCategory" runat="server">
                            <asp:ListItem Text="--Select One--" Value="" /> 
                            <asp:ListItem Text="Shooter" />
                            <asp:ListItem Text="Kids" />
                            <asp:ListItem Text="Sports" />
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Image">
                    <EditItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Width="100" />
                        <asp:HiddenField ID="hdnOldImage" runat="server" Value='<%# Eval("image") %>' />
                        <asp:FileUpload ID="fileImage" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Width="100"/>
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
            InsertCommand="INSERT INTO [Games] ([title], [description], [price], [age_rating], [category], [image]) VALUES (@title, @description, @price, @age_rating, @category, @image)"
            UpdateCommand="UPDATE [Games] SET [title] = @title, [description] = @description, [price] = @price, [age_rating] = @age_rating, [category] = @category, [image] = @image WHERE [id] = @original_id">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="price" Type="Decimal" />
                <asp:Parameter Name="age_rating" Type="String" />
                <asp:Parameter Name="category" Type="String" />
                <asp:Parameter Name="image" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="price" Type="Decimal" />
                <asp:Parameter Name="age_rating" Type="String" />
                <asp:Parameter Name="category" Type="String" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="original_id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</asp:Content>

