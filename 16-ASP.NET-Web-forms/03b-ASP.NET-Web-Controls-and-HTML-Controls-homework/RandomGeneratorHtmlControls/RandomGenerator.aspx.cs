using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorHtmlControls
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.From.Value == "")
            {
                this.From.Value = "0";
            }

            if (this.To.Value == "")
            {
                this.To.Value = "0";
            }            
        }

        protected void GenerateRandomNumber(object sender, EventArgs e)
        {
            var random = new Random();

            var from = int.Parse(this.From.Value);
            var to = int.Parse(this.To.Value);

            var min = Math.Min(from, to);
            var max = Math.Max(from, to);

            var result = random.Next(min, max + 1);

            this.Result.Value = result.ToString();
        }
    }
}