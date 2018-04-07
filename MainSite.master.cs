using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class MainSite : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAuth"] != null && (bool)Session["isAuth"])
        {
            ulNavBar.Controls.Remove(liCart);
            ulNavBar.Controls.Remove(liLogin);

            AddHeaderControl("/Profile.aspx", "<i class=\"material-icons\">person</i> Profile");

            ulNavBar.Controls.Add(liCart);

            string logoutPath = "/Logout.aspx?redirect=" + Server.UrlEncode(Request.Url.PathAndQuery);
            AddHeaderControl(logoutPath, "<i class=\"material-icons\">power_settings_new</i> Logout");

            if (Session["isAdmin"] != null && (bool)Session["isAdmin"])
            {
                AddHeaderControl("/Admin", "<i class=\"material-icons\">security</i>Admin");
            }

            var user = IP.User.GetCurrentUser();
            string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            if (!Page.IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    con.Open();
                    string query = @"SELECT * FROM Games WHERE
                        id NOT IN (
                            SELECT OrderItems.game_id FROM OrderItems, Orders
                            WHERE OrderItems.order_id = Orders.id AND Orders.user_id = @id
                            GROUP BY OrderItems.game_id
                        )
                    AND
                        category IN(
                            SELECT Games.category FROM OrderItems, Orders, Games
                            WHERE OrderItems.order_id = Orders.id
                            AND OrderItems.game_id = Games.id
                            AND Orders.user_id = @id
                            GROUP BY Games.category
                        )";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", user.Id);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var divGame = new HtmlGenericControl("div");
                                divGame.Attributes.Add("class", "game");
                                var imgWrap = new HtmlGenericControl("div");
                                imgWrap.Attributes.Add("class", "img-wrap");
                                var imgGame = new HtmlImage
                                {
                                    Src = reader["image"].ToString()
                                };
                                imgWrap.Controls.Add(imgGame);
                                var imgLnk = new HtmlAnchor
                                {
                                    HRef = "GameDetails.aspx?id=" + reader["id"]
                                };
                                imgLnk.Controls.Add(imgWrap);
                                divGame.Controls.Add(imgLnk);
                                var gameLnk = new HtmlAnchor
                                {
                                    HRef = "GameDetails.aspx?id=" + reader["id"],
                                    InnerText = reader["title"].ToString()
                                };
                                var gameTitle = new HtmlGenericControl("h3");
                                gameTitle.Controls.Add(gameLnk);
                                divGame.Controls.Add(gameTitle);
                                var gamePrice = new HtmlGenericControl("span")
                                {
                                    InnerText = "£" + reader["price"]
                                };
                                divGame.Controls.Add(gamePrice);
                                divSuggestedGames.Controls.Add(divGame);
                            }
                        } else
                        {
                            Page.Controls.Remove(divSuggestedGames);
                        }
                    con.Close();
                    }
                }
            }
        }
    }
    protected void AddHeaderControl(string href, string html)
    {

        HtmlGenericControl li = new HtmlGenericControl("li");
        HtmlAnchor a = new HtmlAnchor
        {
            HRef = href,
            InnerHtml = html
        };
        li.Controls.Add(a);
        ulNavBar.Controls.Add(li);
    }
}
