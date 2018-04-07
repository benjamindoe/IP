using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = IP.User.GetCurrentUser();
        string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        if (!Page.IsPostBack)
        {
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Users WHERE Username = @username ", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtFirstname.Text = reader["firstname"].ToString();
                        txtSurname.Text = reader["surname"].ToString();
                        txtPhone.Text = reader["phone"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                    }
                    con.Close();
                }
            }
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string passwordSet = "";
        bool passChange = false;
        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            if (txtPassword.Text != txtPassword2.Text)
            {
                Message.Text = "Passwords do not match.";
                Message.Style.Add("color", "red");
                return;
            }
            passChange = true;
            passwordSet = ",[password] = @password";
        }
        string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionStr))
        {
            con.Open();
            string query =
                "UPDATE" +
                    "[Users]" +
                " SET " +
                    "[firstname] = @firstname," +
                    "[surname] = @surname," +
                    "[email] = @email," +
                    "[phone] = @phone" +
                    passwordSet +
                " WHERE " +
                    "username = @username";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", (string)Session["username"]);
                cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text);
                cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                if (passChange)
                {
                    PasswordHasher hasher = new PasswordHasher();
                    string hash = hasher.HashPassword(txtPassword.Text);
                    cmd.Parameters.AddWithValue("@password", hash);
                }
                if (cmd.ExecuteNonQuery() > 0)
                {
                    txtPassword.Text = txtPassword2.Text = "";
                    Message.Text = "Account updated!";
                    Message.Style.Add("color", "green");
                }
                else
                {
                    Message.Text = "Something went wrong! Resubmit your form and try again.";
                    Message.Style.Add("color", "red");
                }
            }
            con.Close();
        }
    }
}