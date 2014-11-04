using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupValidation
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidatorAccept_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = AcceptCheckBox.Checked;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Page.Validate("AddressGroup");
            if (this.Page.IsValid)
            {
               // this.LoginIsValid.Text = "Personal info is valid.";
            }
        }

        protected void PersonalInfoButton_Click(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
        }
    }
}