using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var query = Request.QueryString["query"];
        var hasQuery = false;
        var whereQuery = "";
        if (query != null)
        {
            whereQuery = " WHERE title LIKE '%' + @query + '%' OR SOUNDEX(title) = SOUNDEX(@query) ";
            hasQuery = true;
        }
        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            var sqlQuery = "SELECT * FROM Games" + whereQuery;
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                if (hasQuery)
                {
                    cmd.Parameters.AddWithValue("@query", query);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        divGames.Controls.Add(BuildGameHTML(reader));
                    }
                }
                else
                {
                    var h2 = new HtmlGenericControl("h2")
                    {
                        InnerText = "No Games Found."
                    };
                    var p = new HtmlGenericControl("p")
                    {
                        InnerText = "No games found with the title you have submitted."
                    };
                    form1.Controls.Add(h2);
                    form1.Controls.Add(p);
                }
            }
            con.Close();
        }
    }

    protected HtmlGenericControl BuildGameHTML(SqlDataReader reader)
    {
        var divGame = new HtmlGenericControl("div");
        divGame.Attributes.Add("class", "game");
        var img = new HtmlImage()
        {
            Src = reader["image"].ToString()
        };
        var imgWrap = new HtmlGenericControl("div");
        imgWrap.Attributes.Add("class", "img-wrap");
        imgWrap.Controls.Add(img);
        var imgLink = new HtmlAnchor()
        {
            HRef = "GameDetails.aspx?id=" + reader["id"].ToString()
        };
        imgLink.Controls.Add(imgWrap);
        var gameTitle = new HtmlGenericControl("h2");
        var gameLink = new HtmlAnchor()
        {
            HRef = "GameDetails.aspx?id=" + reader["id"].ToString(),
            InnerText = reader["title"].ToString()
        };
        gameTitle.Controls.Add(gameLink);
        var spanPrice = new HtmlGenericControl("span")
        {
            InnerText = "£" + reader["price"].ToString()
        };
        spanPrice.Attributes.Add("class", "game-price");
        divGame.Controls.Add(imgLink);
        divGame.Controls.Add(gameTitle);
        divGame.Controls.Add(spanPrice);
        return divGame;
    }
}