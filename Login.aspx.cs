using System;
using System.Configuration;
using System.Data.SqlClient;
using IP;
using Microsoft.AspNet.Identity;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IP.User.IsAuth())
        {
            Redirect();
        }
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
                        var user = new User()
                        {
                            Id = (int)reader["id"],
                            Username = username,
                            IsAdmin = reader["is_admin"] as bool? ?? false,
                            Email = reader["email"].ToString()
                        };
                        IP.User.SetCurrentUser(user);
                        Session["isAuth"] = true;
                        Session["username"] = username;
                        Session["userId"] = user.Id;
                        Session["isAdmin"] = user.IsAdmin;
                        con.Close();

                        // ?redirect=/PageWhatever.aspx
                        Redirect();
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
    public void Redirect()
    {
        string redirUrl = Request.QueryString["redirect"] ?? "/";
        Response.Redirect(redirUrl);
    }
}