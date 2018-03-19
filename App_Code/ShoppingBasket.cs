using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ShoppingBasket
{
    private List<BasketItem> items;

    public ShoppingBasket()
    {
        items = new List<BasketItem>();
    }

    public int Count
    {
        get { return items.Count; }
    }

    public decimal SubTotal
    {
        get
        {
            decimal subTotal = 0;
            for (int i = 0; i < this.Count; i++)
            {
                subTotal += this[i].Product.Price;
            }
            return subTotal;
        }
    }

    public BasketItem this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    public BasketItem this[string id]
    {
        get
        {
            foreach (BasketItem item in items)
            {
                if (item.Product.ID == int.Parse(id))
                {
                    return item;
                }
            }
            return null;
        }
    }

    public static ShoppingBasket GetBasket()
    {
        ShoppingBasket basket = (ShoppingBasket)HttpContext.Current.Session["Basket"];
        if (basket == null) // if no basket make one and store it in current session
        {
            HttpContext.Current.Session["Basket"] = new ShoppingBasket();
        }
        return (ShoppingBasket)HttpContext.Current.Session["Basket"];
    }

    public void AddItem(Product product, int quantity)
    {
        BasketItem c = new BasketItem(product, quantity);
        items.Add(c);
    }

    public void RemoveAt(int index)
    {
        items.RemoveAt(index);
    }

    public void Clear()
    {
        items.Clear();
    }

    public List<BasketItem> Items()
    {
        return items;
    }
}