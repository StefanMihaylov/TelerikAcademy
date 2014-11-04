using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeleteViewState
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["values"] == null)
            {
                ViewState.Add("values", new List<string>());
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var list = (List<string>)ViewState["values"];
            list.Add(TextBox.Text);
            Label.Text = "";
            foreach (var item in list)
            {
                Label.Text += "<br/>" + item;
            }

            TextBox.Text = "";
        }
    }
}