using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = IP.User.GetCurrentUser();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString))
        {
            con.Open();
            string query = @"SELECT
                                [Orders].[id],
                                [Orders].[subtotal],
                                [Orders].[date],
                                [Orders].[user_id],
                                [Games].[title],
                                [Games].[image],
                                [Games].[price],
                                [OrderItems].[quantity] 
                            FROM
                                Orders 
                            INNER JOIN
                                [OrderItems] 
                            ON
                                [OrderItems].[order_id] = [Orders].[id] 
                            INNER JOIN
                                [Games] 
                            ON
                                [Games].[id] = [OrderItems].[game_id]
                            WHERE
                                [Orders].[id] = @id";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (Request.QueryString["id"] != null)
                {
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //if (user != null && (int)reader["user_id"] == user.Id || Session["isAdmin"] != null && (bool)Session["isAdmin"])
                        //{
                        while(reader.Read())
                        {
                            orderRef.InnerText = "Order Referece #" + reader["id"];
                            lblDate.InnerText = "Order Date: " + Convert.ToDateTime(reader["date"]).ToString("dd MMMM yyyy");
                            lblPrice.InnerText = "Subtotal: £" + Math.Round((decimal)reader["subtotal"], 2);
                            BuildOrderItems(ref orderItems, reader);
                        }

                        //}
                    }
                }
                else
                {
                    Response.Redirect("/");
                }
            }
        }
    }


    public void BuildOrderItems(ref HtmlGenericControl ulItems, SqlDataReader reader)
    {
        string[] details = new string[] { "image", "title", "price" };
        HtmlGenericControl liItem = new HtmlGenericControl("li");
        liItem.Attributes.Add("class", "item");
        HtmlGenericControl div;
        foreach (var detail in details)
        {
            div = new HtmlGenericControl("div");
            div.Attributes.Add("class", "item-" + detail);
            switch (detail)
            {
                case "title":
                    div.InnerHtml = reader["quantity"].ToString() + " x " + reader["title"].ToString();

                    break;
                case "image":
                    HtmlImage image = new HtmlImage
                    {
                        Src = reader[detail].ToString()
                    };
                    div.Controls.Add(image);
                    break;
                case "price":
                    div.InnerHtml = Server.HtmlEncode("£" + reader[detail].ToString());
                    break;
                default:
                    div.InnerHtml = Server.HtmlEncode(reader[detail].ToString());
                    break;
            }
            liItem.Controls.Add(div);
        }
        ulItems.Controls.Add(liItem);
    }
}