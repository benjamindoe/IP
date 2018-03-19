using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Admin_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow footerRow = GridView1.FooterRow;
        if (e.CommandName == "Insert" && Page.IsValid)
        {
            TextBox username = (TextBox)footerRow.FindControl("txtNewUsername");
            CheckBox isAdmin = (CheckBox)footerRow.FindControl("chkNewAdmin");

            string password = "ChangeMe";
            PasswordHasher hasher = new PasswordHasher();
            string hash = hasher.HashPassword(password);
            UsersDataSource.InsertParameters["username"].DefaultValue = username.Text;
            UsersDataSource.InsertParameters["password"].DefaultValue = password;
            UsersDataSource.InsertParameters["is_admin"].DefaultValue = isAdmin.Checked.ToString();

            try
            {
                UsersDataSource.Insert();
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }
    }
}