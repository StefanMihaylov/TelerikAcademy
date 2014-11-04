using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            var firstName = this.firstName.Text;
            var lastName = this.lastName.Text;
            var facultyNumber = this.facultyNumber.Text;

            var university = this.university.SelectedItem.Value;
            var specialty = this.specialty.SelectedItem.Value;
            var coursesIds = this.courses.GetSelectedIndices();

            var courseList = "<ol>";

            for (int i = 0; i < coursesIds.Length; i++)
            {
                courseList += "<li><strong>" + Server.HtmlEncode(this.courses.Items[i].Text) + "</strong></li>";
            }

            courseList += "</ol>";

            this.result.Text = "";
            this.result.Text += "<p> Student name: <strong>" + Server.HtmlEncode(firstName) + " " + Server.HtmlEncode(lastName) + "</strong></p>";
            this.result.Text += "<p> Faculty number: <strong>" + Server.HtmlEncode(facultyNumber) + "</strong></p>";
            this.result.Text += "<p> University: <strong>" + Server.HtmlEncode(university) + "</strong></p>";
            this.result.Text += "<p> The student is enrolled for: " + courseList + "</p>";
        }
    }
}