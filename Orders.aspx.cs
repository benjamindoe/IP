using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString))
        {
            con.Open();
            string query = @"SELECT
                                [Orders].[id],
                                [Orders].[subtotal],
                                [Orders].[date],
                                [Games].[title],
                                [Games].[price],
                                [Games].[image],
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
                                [Orders].[user_id] = @id
                            ORDER BY [Orders].[date] DESC, [Orders].[id] DESC";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                var user = IP.User.GetCurrentUser();
                cmd.Parameters.AddWithValue("@id", user.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        BuildOrder(reader);
                    }
                }
            }
        }
    }

    protected void BuildOrder(SqlDataReader reader)
    {
        string orderId = "Order" + reader["id"].ToString();
        HtmlGenericControl order = (HtmlGenericControl)ulOrders.FindControl(orderId);
        HtmlGenericControl orderItems;
        if (order == null) // If control doesn't exist, add it.
        {
            order = new HtmlGenericControl("li")
            {
                ID = orderId,
            };
            order.Attributes.Add("class", "order");
            orderItems = new HtmlGenericControl("ul")
            {
                ID = orderId + "Items"
            };
            orderItems.Attributes.Add("class", "order-items");
            HtmlGenericControl orderHeader = new HtmlGenericControl("div");
            orderHeader.Attributes.Add("class", "order-header");
            order.Controls.Add(orderHeader);
            string[] orderDetails = new string[]{ "id", "subtotal", "date"};
            foreach (var detail in orderDetails)
            {
                var divDetail = new HtmlGenericControl("div");
                switch (detail)
                {
                    case "id":
                        divDetail.InnerText = "ORDER  #" + reader[detail].ToString();
                        break;
                    case "subtotal":
                        var subtotal = (decimal)reader[detail];
                        divDetail.InnerText = "Total: £" + Math.Round(subtotal, 2);
                        break;
                    case "date":
                        var date = Convert.ToDateTime(reader[detail]);
                        divDetail.InnerText = "Order Date: " + date.ToString("dd MMMM yyyy");
                        break;
                }
                orderHeader.Controls.Add(divDetail);
            }
            HtmlAnchor lnkDetail = new HtmlAnchor
            {
                HRef = "Order.aspx?id=" + reader["id"]
            };
            orderHeader.Controls.Add(lnkDetail);
            HtmlGenericControl orderBody = new HtmlGenericControl("div");
            orderBody.Attributes.Add("class", "order-body");
            order.Controls.Add(orderBody);
            var h2 = new HtmlGenericControl("h2")
            {
                InnerText = "Ordered Items"
            };
            orderBody.Controls.Add(h2);
            orderBody.Controls.Add(orderItems);
            ulOrders.Controls.Add(order);
        } else
        {
            orderItems = (HtmlGenericControl)order.FindControl(orderId + "Items");
        }
        BuildOrderItems(ref orderItems, reader);

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