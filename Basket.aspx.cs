using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

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
                BasketControl.Controls.Add(html);
            }
        } else
        {
            HtmlGenericControl h2 = new HtmlGenericControl("h2")
            {
                InnerText = "Your Basket is Empty"
            };
            HtmlAnchor a = new HtmlAnchor
            {
                HRef = "/",
                InnerText = "Continue Shopping"
            };

            BasketControl.Controls.Add(h2);
            BasketControl.Controls.Add(a);
        }
    }
}