using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;

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
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT " +
                        " TOP 1 Games.id, Games.title, Games.price, Games.description, Games.image, AVG(GameRatings.rating) AS avgRating " +
                    " FROM " +
                        " Games " +
                    " LEFT JOIN " +
                        " GameRatings ON Games.id = GameRatings.game_id" +
                    " WHERE " +
                        " Games.id = @id " +
                    " GROUP BY " +
                        "Games.id, Games.title, Games.price, Games.description, Games.image",
                con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        hdnID.Value = id;
                        GameImage.Src = hdnImage.Value = reader["image"].ToString();
                        GameTitle.InnerText = reader["title"].ToString();
                        hdnTitle.Value = reader["title"].ToString();
                        GameDesc.InnerText = reader["description"].ToString();
                        hdnDescription.Value = reader["description"].ToString();
                        hdnPrice.Value = reader["price"].ToString();
                        GamePrice.InnerText = "£" + reader["price"].ToString();
                        var avgGameRating = reader["avgRating"] != DBNull.Value ? (int)reader["avgRating"] : 0;
                        FillStars(avgRating, avgGameRating);
                        con.Close();
                        // Check if user has made a comment yet
                        if (IP.User.IsAuth())
                        {
                            var user = IP.User.GetCurrentUser();
                            con.Open();
                            using (var userCmd = new SqlCommand("SELECT * FROM GameRatings WHERE game_id=@id AND user_id=@userId", con))
                            {
                                userCmd.Parameters.AddWithValue("@id", id);
                                userCmd.Parameters.AddWithValue("@userId", user.Id);
                                var userReader = userCmd.ExecuteReader();
                                if (userReader.HasRows)
                                {
                                    userRating.Visible = false;
                                }
                            }
                            con.Close();
                        }
                        else
                        {
                            userRating.Visible = false;
                        }
                        con.Open();
                        using (var cmtCmd = new SqlCommand("SELECT * FROM GameRatings, Users WHERE Users.id = GameRatings.user_id AND game_id=@id", con))
                        {
                            cmtCmd.Parameters.AddWithValue("@id", id);
                            var cmtReader = cmtCmd.ExecuteReader();
                            if (cmtReader.HasRows)
                            {
                                while (cmtReader.Read())
                                {
                                    var review = new HtmlGenericControl("div");
                                    review.Attributes.Add("class", "user-review");

                                    var username = new HtmlGenericControl("p")
                                    {
                                        InnerHtml = "<img src=\"assets/img/user-icon.png\" /> " + Server.HtmlEncode(cmtReader["username"].ToString())
                                    };
                                    username.Attributes.Add("class", "username");

                                    var stars = new HtmlGenericControl("div");
                                    stars.Attributes.Add("class", "comment-stars");
                                    GenerateStars(ref stars, (int)cmtReader["rating"]);
                                    var comment = new HtmlGenericControl("p")
                                    {
                                        InnerText = cmtReader["comment"].ToString()
                                    };
                                    review.Controls.Add(username);
                                    review.Controls.Add(stars);
                                    review.Controls.Add(comment);
                                    gameComments.Controls.Add(review);
                                }
                            }
                            else
                            {
                                gameComments.InnerText = "None to see...";
                            }
                        }
                        con.Close();
                    }
                    else
                    {
                        Response.Clear();
                        Response.StatusCode = 404;
                        Response.End();
                    }
                }
                con.Close();
            }
        } else
        {
            Response.Clear();
            Response.StatusCode = 404;
            Response.End();
        }
    }

    protected void btnAddBasket_Click(object sender, EventArgs e)
    {
        ShoppingBasket basket = ShoppingBasket.GetBasket();
        BasketItem item = basket[hdnID.Value];
        if (item == null)
        {
            Product product = new Product
            {
                ID = int.Parse(hdnID.Value),
                Title = hdnTitle.Value,
                Description = hdnDescription.Value,
                Price = decimal.Parse(hdnPrice.Value),
                ImagePath = hdnImage.Value
            };
            basket.AddItem(product, 1);
        } else
        {
            item.AddQuantity(1);
        }
        Response.Redirect("Basket.aspx");
    }

    protected void btnWriteReview_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (IP.User.IsAuth())
            {
                var user = IP.User.GetCurrentUser();
                var id = Request.QueryString["id"];
                string conStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO GameRatings ([user_id],[game_id],[rating], [comment]) VALUES (@userId, @gameId, @rating, @comment)", con))
                    {
                        cmd.Parameters.AddWithValue("@userId", user.Id);
                        cmd.Parameters.AddWithValue("@gameId", id);
                        cmd.Parameters.AddWithValue("@rating", hdnStarRating.Value);
                        cmd.Parameters.AddWithValue("@comment", txtReviewComment.Text);
                        cmd.ExecuteScalar();
                        Response.Redirect(Request.RawUrl);
                    }
                }
            } else
            {
                Response.StatusCode = 401;
                Response.Flush();
                Response.End();
            }
        }
    }

    protected void FillStars(HtmlGenericControl control, int rating)
    {
        for (var i = 1; i <= rating; i++)
        {
            var star = (HtmlGenericControl)control.FindControl("star" + i);
            if (star != null)
            {
                star.InnerHtml = "<i class=\"material-icons\">star</i>";
                star.Attributes.Add("class", "star star-filled");
            }
        }
    }

    protected void GenerateStars(ref HtmlGenericControl control, int rating)
    {
        for (var i = 1; i <= 5; i++)
        {
            var star = new HtmlGenericControl("span")
            {
                InnerHtml = "<i class=\"material-icons\">star_border</i>",
                ID = control.ID + "star" + i
            };
            star.Attributes.Add("class", "star");
            if (i <= rating)
            {
                star.Attributes.Add("class", "star star-filled");
                star.InnerHtml = "<i class=\"material-icons\">star</i>";
            }
            control.Controls.Add(star);
        }
    }
}