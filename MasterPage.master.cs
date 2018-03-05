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
            ulNavBar.Controls.Remove(liLogin);
            HtmlGenericControl li = new HtmlGenericControl("li");
            HtmlAnchor lnkProfile = new HtmlAnchor();
            lnkProfile.HRef = "/Profile.aspx";
            lnkProfile.InnerHtml = "<i class=\"material-icons\">person</i> Profile";
            li.Controls.Add(lnkProfile);
            ulNavBar.Controls.Add(li);

            li = new HtmlGenericControl("li");
            HtmlAnchor logout = new HtmlAnchor();
            logout.HRef = "/Logout.aspx?redirect=" + Server.UrlEncode(Request.Url.PathAndQuery); ;
            logout.InnerHtml = "Logout";
            li.Controls.Add(logout);
            ulNavBar.Controls.Add(li);
        }
    }
}
