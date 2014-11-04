using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<Book> RepeaterSearch_GetData()
        {
            var db = new AppDbContext();
            var query = Request.QueryString["query"];
            this.LiteralQuery.Text = query;

            var result = db.Books.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query))
            {
                result = result.Where(b => b.Author.Contains(query) || b.Title.Contains(query));
            }
                      
            result = result.OrderBy(b => b.Title);
            return result;
        }
    }
}