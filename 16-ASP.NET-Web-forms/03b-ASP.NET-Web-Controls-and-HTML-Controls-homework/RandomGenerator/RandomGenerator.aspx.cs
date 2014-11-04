using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGenerator
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.From.Text == "")
            {
                this.From.Text = "0";
            }

            if (this.To.Text == "")
            {
                this.To.Text = "0";
            }
        }

        protected void SubmitButtom_Click(object sender, EventArgs e)
        {
            try
            {
                var random = new Random();
                var from = int.Parse(this.From.Text);
                var to = int.Parse(this.To.Text);

                var min = Math.Min(from, to);
                var max = Math.Max(from, to);

                var result = random.Next(min, max + 1);

                this.Result.Text = result.ToString();
            }
            catch (Exception)
            {
                this.Result.Text = "Error!";
            }
        }
    }
}