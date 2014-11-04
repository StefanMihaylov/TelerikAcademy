using System;
using System.Web;

namespace ClientIP
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var browser = Request.Browser.Type;
            // var clientIP = HttpContext.Current.Request.UserHostAddress;
            var clientIP = GetUserIpAddress();

            Response.Write("Browser: " + browser + "<br/> Client IP: " + clientIP);
        }

        public static string GetUserIpAddress()
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                if (ip == "::1")
                {
                    ip = "127.0.0.1"; // localhost
                }
            }

            return ip;
        }
    }
}