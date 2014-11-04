using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            var db = new AppDbContext();
            return db.Categories.OrderBy(c => c.CategoryId);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var query = this.TextBoxSearch.Text;
            Response.Redirect(string.Format("~/Search?query={0}", query));
        }
    }
}