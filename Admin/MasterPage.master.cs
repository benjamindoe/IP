using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["isAuth"] != null && (bool)Session["isAuth"])
        {
            if (Session["isAdmin"] != null && (bool)Session["isAdmin"])
            {
                // THEY HAVE ACCESS HERE...
            }
            else
            {
                Response.StatusCode = 403;
                Response.Flush();
                Response.End();
            }
        }
        else
        {
            Response.Redirect("/Login.aspx?redirect=" + Server.UrlEncode(Request.Url.PathAndQuery));
        }
    }
}
