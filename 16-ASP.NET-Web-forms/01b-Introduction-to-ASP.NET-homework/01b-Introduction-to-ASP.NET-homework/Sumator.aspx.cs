using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumatorWebForms
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.TextBoxFirstNumber.Text == "")
            {
                this.TextBoxFirstNumber.Text = "0";
            }

            if (this.TextBoxSecondNumber.Text == "")
            {
                this.TextBoxSecondNumber.Text = "0";
            }
        }

        protected void ButtonSum_Click(object sender, EventArgs e)
        {
            decimal firstNumber;
            decimal secondNumber;

            bool isFirstNumberParsed = decimal.TryParse(this.TextBoxFirstNumber.Text, out firstNumber);
            bool isSecondNumberParsed = decimal.TryParse(this.TextBoxSecondNumber.Text, out secondNumber);

            if (isFirstNumberParsed && isSecondNumberParsed)
            {
                this.TextBoxResult.Text = (firstNumber + secondNumber).ToString();
            }
            else
            {
                this.TextBoxResult.Text = "Invalid input number!";
            }
        }
    }
}