using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegisterForm
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

        }

        protected void CustomValidatorAccept_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = AcceptCheckBox.Checked;
        }
    }
}