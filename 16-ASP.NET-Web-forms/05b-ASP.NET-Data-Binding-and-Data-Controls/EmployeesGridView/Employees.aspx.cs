using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NorthwindData;

namespace EmployeesGridView
{
    public partial class Employees : System.Web.UI.Page
    {
        void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            var db = new NorthwindContext();
            this.EmployeesGridView.DataSource = db.GetEmployees();;

            this.Page.DataBind();
        }
    }
}