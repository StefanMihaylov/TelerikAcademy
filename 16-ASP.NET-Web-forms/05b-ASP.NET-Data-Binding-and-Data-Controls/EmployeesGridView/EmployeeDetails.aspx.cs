using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesGridView
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            int id = int.Parse(Request.Params["Id"]);

            var db = new NorthwindContext();

            var employee = db.GetEmployeeById(id);
            this.EmployeeDetailsView.DataSource = new List<Employee>() { employee };

            this.Page.DataBind();
        }
    }
}