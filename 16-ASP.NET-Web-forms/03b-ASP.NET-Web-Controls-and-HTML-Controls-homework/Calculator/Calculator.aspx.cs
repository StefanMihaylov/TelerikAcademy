using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonCommand(object sender, CommandEventArgs e)
        {
            var command = e.CommandName;
            switch (command)
            {
                case "clear":
                    this.result.Text = "";
                    break;
                case "digit":
                    this.result.Text += e.CommandArgument;
                    break;
                case "operand":
                    this.result.Text += e.CommandArgument;
                    break;
                case "root":
                    var numbers = GetOperands();
                    if (numbers.Count == 1)
                    {
                        this.result.Text = Math.Sqrt(numbers[0]).ToString();
                    }
                    else
                    {
                        this.result.Text = "Error: only one operand is required!";
                    }
                    break;
                case "result":
                    numbers = GetOperands();
                    var operandCount = numbers.Count;
                    if (operandCount == 1)
                    {

                    }
                    else if (operandCount == 2)
                    {
                        var expression = this.result.Text;
                        double calculatedResult = 0;

                        int index = expression.IndexOf('+');
                        if (index >= 0)
                        {
                            calculatedResult = numbers[0] + numbers[1];
                        }

                        index = expression.IndexOf('-');
                        if (index >= 0)
                        {
                            calculatedResult = numbers[0] - numbers[1];
                        }

                        index = expression.IndexOf('*');
                        if (index >= 0)
                        {
                            calculatedResult = numbers[0] * numbers[1];
                        }

                        index = expression.IndexOf('/');
                        if (index >= 0)
                        {
                            calculatedResult = numbers[0] / numbers[1];
                        }

                        this.result.Text = calculatedResult.ToString();
                    }
                    else
                    {
                        this.result.Text = "Error: only two operand is required!";
                    }
                    break;
                default:
                    this.result.Text = "Error!";
                    break;
            }
        }

        private IList<double> GetOperands()
        {
            var result = new List<double>();
            var resultAsString = this.result.Text.Split(new char[] { '+', '-', '/', '*' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in resultAsString)
            {
                result.Add(double.Parse(number));
            }

            return result;
        }
    }
}