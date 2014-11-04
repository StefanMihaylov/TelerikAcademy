using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesAndOrders
{
    public partial class Index : System.Web.UI.Page
    {
        private int employeeId;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Employee> EmployeeGridView_GetData()
        {
            var db = new NorthwindEntities();
            var result = db.Employees.OrderBy(e => e.EmployeeID);
            return result;
        }


        protected void EmployeeGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(3000);

            this.employeeId = int.Parse(this.EmployeeGridView.SelectedDataKey.Value.ToString());
            OrderGridDataSource();           
        }

        protected void OrderGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.OrderGridView.PageIndex = e.NewPageIndex;           
        }

        private void OrderGridDataSource()
        {
            var db = new NorthwindEntities();
            var result = db.Orders.Where(emp => emp.EmployeeID == this.employeeId).OrderBy(emp => emp.OrderID).ToList();

            this.OrderGridView.DataSource = result;
            this.OrderGridView.DataBind();
        }
    }
}