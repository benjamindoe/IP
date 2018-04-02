using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthMaster : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["isAuth"] == null || !(bool)Session["isAuth"])
        {
            Response.Redirect("/Login.aspx?redirect=" + Server.UrlEncode(Request.Url.PathAndQuery));
        }
    }
}
