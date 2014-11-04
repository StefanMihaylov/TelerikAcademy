using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginCookie
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["Login"];
            if (cookie != null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Login");
            cookie.Expires =  DateTime.Now.AddMinutes(1);
            cookie.Value = "Logged in";

            Response.Cookies.Add(cookie);
            Response.Redirect("~/Home.aspx");
        }
    }
}