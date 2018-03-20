using System.Web.UI.HtmlControls;

public class BasketItem
{
    public BasketItem(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
    }

    public Product Product { get; set; }
    public int Quantity { get; set; }

    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
    }

    public override string ToString()
    {
        string displayString =
            Product.Title + " (" + Quantity.ToString()
            + " at " + Product.Price.ToString("c") + " each)";

        return displayString;
    }

    public HtmlGenericControl ToHtml()
    {
        HtmlGenericControl item = new HtmlGenericControl("div");
        item.Attributes.Add("class", "basket-item");

        HtmlGenericControl details = new HtmlGenericControl("div");
        details.Attributes.Add("class", "item-details");
        HtmlImage img = new HtmlImage
        {
            Src = this.Product.ImagePath,
        };
        img.Attributes.Add("class", "item-img");
        details.Controls.Add(img);

        HtmlAnchor title = new HtmlAnchor
        {
            HRef = "/GameDetails.aspx?id=" + this.Product.ID,
            InnerText = this.Product.Title
        };
        title.Attributes.Add("class", "item-title");
        details.Controls.Add(title);
        item.Controls.Add(details);
        HtmlGenericControl price = new HtmlGenericControl("div")
        {
            InnerHtml = "&pound;" + this.Product.Price
        };
        price.Attributes.Add("class", "item-price");
        item.Controls.Add(price);

        HtmlGenericControl quantity = new HtmlGenericControl("div")
        {
            InnerText = this.Quantity.ToString(),
            ID = "itemQuantity" + this.Product.ID
        };
        quantity.Attributes.Add("class", "item-quantity");
        item.Controls.Add(quantity);

        return item;
    }
}