using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        HtmlGenericControl htmlItem = new HtmlGenericControl("div");
        HtmlImage img = new HtmlImage
        {
            Src = this.Product.ImagePath,
        };
        img.Attributes.Add("class", "item-img");
        item.Controls.Add(img);

        HtmlAnchor title = new HtmlAnchor
        {
            HRef = "/Games.aspx?id=" + this.Product.ID,
            InnerText = this.Product.Title
        };
        title.Attributes.Add("class", "item-title");
        item.Controls.Add(title);

        HtmlGenericControl price = new HtmlGenericControl("div")
        {
            InnerHtml = "&pound;" + this.Product.Price
        };
        price.Attributes.Add("class", "item-price");
        item.Controls.Add(price);

        HtmlGenericControl quantity = new HtmlGenericControl("div")
        {
            InnerHtml = "&pound;" + this.Product.Price,
            ID = "itemQuantity" + this.Product.ID
        };
        quantity.Attributes.Add("class", "item-quantity");
        item.Controls.Add(quantity);

        return item;
    }
}