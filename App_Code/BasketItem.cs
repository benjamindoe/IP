using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}