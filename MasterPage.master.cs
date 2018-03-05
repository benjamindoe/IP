using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAuth"] != null && (bool)Session["isAuth"])
        {
            ulNavBar.Controls.Remove(liCart);
            ulNavBar.Controls.Remove(liLogin);

            AddHeaderControl("/Profile.aspx", "<i class=\"material-icons\">person</i> Profile");

            ulNavBar.Controls.Add(liCart);

            string logoutPath = "/Logout.aspx?redirect=" + Server.UrlEncode(Request.Url.PathAndQuery);
            AddHeaderControl(logoutPath, "<i class=\"material-icons\">power_settings_new</i> Logout");

            if (Session["isAdmin"] != null && (bool)Session["isAdmin"])
            {
                AddHeaderControl("/Admin", "<i class=\"material-icons\">security</i>Admin");
            }
        }
    }

    protected void AddHeaderControl(string href, string html)
    {

        HtmlGenericControl li = new HtmlGenericControl("li");
        HtmlAnchor a = new HtmlAnchor();
        a.HRef = href;
        a.InnerHtml = html;
        li.Controls.Add(a);
        ulNavBar.Controls.Add(li);
    }
}
