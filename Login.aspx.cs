using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        string username = txtUsername.Text;
        string password = txtPassword.Text;

        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Users WHERE Username = @username ", con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string hash = reader["password"].ToString();
                    PasswordHasher hasher = new PasswordHasher();
                    PasswordVerificationResult verificationResult = hasher.VerifyHashedPassword(hash, password);
                    if (verificationResult != PasswordVerificationResult.Failed)
                    {
                        Session["isAuth"] = true;
                        Session["username"] = username;
                        Session["userId"] = reader["id"].ToString();
                        Session["isAdmin"] = reader["is_admin"] as bool? ?? false;
                        con.Close();

                        // ?redirect=/PageWhatever.aspx
                        string redirUrl = Request.QueryString["redirect"] != null ? Request.QueryString["redirect"] : "/";
                        Response.Redirect(redirUrl);
                    }
                    else
                    {
                        txtPassword.Style.Add("border", "1px solid red");
                        lblMsg.Text = "Invalid password.";
                    }
                }
                else
                {
                    txtUsername.Style.Add("border", "1px solid red");
                    lblMsg.Text = "Invalid Username.";
                }
            }
            con.Close();
        }
    }
}