using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextExcaping
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            var text = this.Input.Text;
            var encodedtext = Server.HtmlEncode(text);
            
            this.LabelResult.Text = encodedtext;
            this.InputResult.Text = text;
        }
    }
}