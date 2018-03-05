using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                bool isTaken = false;

                // Check if username is taken
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Users] WHERE [username] = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    isTaken = (int)cmd.ExecuteScalar() > 0;
                }

                if (isTaken)
                {
                    txtUsername.Style.Add("border", "1px solid red");
                    lblMsg.Text = "Username already exists.";
                    return;
                }

                if (password != confirmPassword)
                {
                    txtPassword.Style.Add("border", "1px solid red");
                    txtConfirmPassword.Style.Add("border", "1px solid red");
                    lblMsg.Text = "Passwords do not match.";
                    return;
                }

                // Hash the password
                PasswordHasher hasher = new PasswordHasher();
                string hash = hasher.HashPassword(password);


                // Save the data
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [Users]([username], [password]) Values (@username, @pass)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", username.Trim());
                    cmd.Parameters.AddWithValue("@pass", hash);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                Response.Redirect("Login.aspx");
            }
        }
    }
}