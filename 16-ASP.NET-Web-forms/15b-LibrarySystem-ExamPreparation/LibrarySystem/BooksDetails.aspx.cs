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
    public partial class BooksDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Book FormViewBooksDetails_GetItem([QueryString("id")]int? id)
        {
            var db = new AppDbContext();
            var result = db.Books.Find(id);

            if (result == null)
            {
                Response.Redirect("/");
                return null;
            }
            else
            {
                return result;
            }
        }
    }
}