using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class GameDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            string id = Request.QueryString["id"];
            string conStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Games WHERE id = @id ", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        GameImage.Src = reader["image"].ToString();
                        GameTitle.InnerText = reader["title"].ToString();
                        GameDesc.InnerText = reader["description"].ToString();
                        string price = reader["price"].ToString();
                        string ageRating = reader["age_rating"].ToString();
                        DateTime releaseDate = Convert.ToDateTime(reader["release_date"]);
                    }
                }
                con.Close();
            }
        } else
        {
            Response.Redirect("/");
        }
    }
}