using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginCookie
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["Login"];
            if (cookie == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                //var timeLeft = cookie.Expires - DateTime.Now;
                // this.LogoutTime.Text = string.Format("Automatic Logout after {0}", timeLeft);
            }
        }
    }
}