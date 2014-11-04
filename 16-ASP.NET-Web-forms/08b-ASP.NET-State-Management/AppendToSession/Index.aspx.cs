using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppendToSession
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InputValues"] == null)
            {
                Session["InputValues"] = new List<string>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var text = this.Input.Text;
            this.Input.Text = "";

            var list = Session["InputValues"] as List<string>;
            list.Add(text);

            this.Result.Text = "";
            foreach (var item in list)
            {
                this.Result.Text += item + "<br/>";
            }
        }
    }
}