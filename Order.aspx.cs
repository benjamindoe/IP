using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order : System.Web.UI.Page
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
                                [Games].[Title],
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
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if ((int)reader["user_id"] == (int)Session["userId"] || Session["isAdmin"] != null && (bool)Session["isAdmin"])
                    {

                    }
                }
            }
        }
    }
}