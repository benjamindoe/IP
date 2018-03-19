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
                        hdnID.Value = id;
                        GameImage.Src        = hdnImage.Value       = reader["image"].ToString();
                        GameTitle.InnerText  = hdnTitle.Value       = reader["title"].ToString();
                        GameDesc.InnerText   = hdnDescription.Value = reader["description"].ToString();
                        hdnPrice.Value = reader["price"].ToString();
                        GamePrice.InnerHtml  = "&pound;" + reader["price"].ToString();
                        string ageRating     = reader["age_rating"].ToString();
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
}