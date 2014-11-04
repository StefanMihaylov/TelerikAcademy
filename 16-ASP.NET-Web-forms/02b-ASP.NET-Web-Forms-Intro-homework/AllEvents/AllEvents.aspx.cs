using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AllEvents
{
    public partial class AllEvents : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page_PreInit invoked");
            Response.Write("<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page_Init invoked");
            Response.Write("<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page_Load invoked");
            Response.Write("<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page_PreRender invoked");
            Response.Write("<br/>");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at page unload
            // Response.Write("Page_Unload invoked" + "<br/>");
        }
    }
}