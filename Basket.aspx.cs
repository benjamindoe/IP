using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Basket : System.Web.UI.Page
{
    protected ShoppingBasket basket;
    protected void Page_Load(object sender, EventArgs e)
    {
        basket = ShoppingBasket.GetBasket();

        if (basket.Count > 0)
        {
            for (int i = 0; i < basket.Count; ++i)
            {
                BasketItem item = basket[i];
                HtmlGenericControl html = item.ToHtml();
                BasketContent.Controls.Add(html);
            }
        } else
        {
            btnCheckout.Visible = false;
            HtmlGenericControl h2 = new HtmlGenericControl("h2")
            {
                InnerText = "Your Basket is Empty"
            };
            BasketContent.Controls.Add(h2);
        }
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        if (Session["isAuth"] != null && (bool)Session["isAuth"])
        {
            ShoppingBasket basket = ShoppingBasket.GetBasket();
            string username = (string)Session["username"];
            int userId = int.Parse(Session["userId"].ToString());
            int? newID = null;
            string conStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [Orders]([user_id], [subtotal], [date]) OUTPUT INSERTED.ID VALUES (@userId, @subtotal, GETDATE())", con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@subtotal", basket.SubTotal);
                    try
                    {
                        newID = (int?)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (newID != null)
                {
                    for (int i = 0; newID != null && i < basket.Count; i++)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO OrderItems ([order_id],[game_id],[quantity]) VALUES (@orderId, @gameId, @quantity)", con))
                        {
                            cmd.Parameters.AddWithValue("@orderId", newID);
                            cmd.Parameters.AddWithValue("@gameId", basket[i].Product.ID);
                            cmd.Parameters.AddWithValue("@quantity", basket[i].Quantity);
                            cmd.ExecuteScalar();
                        }
                    }
                    if (basket.Count > 0)
                    {
                        basket.Clear();
                    }
                }
                con.Close();
                Response.Redirect("/Orders.aspx");
            }

        } else
        {
            string loginUrl = "/login.aspx?redirect=" + Server.UrlEncode(Request.Url.PathAndQuery);
            Response.Redirect(loginUrl);
        }
    }
}