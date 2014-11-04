using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesFormView
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            var db = new NorthwindContext();
            this.EmployeesGridView.DataSource = db.GetEmployees();

            if (Request.Params["Id"] != null)
            {
                int id = int.Parse(Request.Params["Id"]);
                this.EmployeesFormView.DataSource = new List<Employee>() { db.GetEmployeeById(id) };
            }

            this.Page.DataBind();
        }
    }
}