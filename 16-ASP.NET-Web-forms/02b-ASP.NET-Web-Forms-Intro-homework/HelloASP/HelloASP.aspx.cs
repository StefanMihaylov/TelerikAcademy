using System;
using System.Reflection;

namespace HelloASP
{
    public partial class HelloASP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string path = Assembly.GetExecutingAssembly().Location;
            string path = Assembly.GetExecutingAssembly().CodeBase;
            Response.Write("Hello, \"ASP.NET\" from C#");
            Response.Write("<br/>");
            Response.Write("Assembly Location: " + path);
        }
    }
}