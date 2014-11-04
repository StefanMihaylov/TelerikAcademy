using ErrorHandlerControl;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Book> ListViewBooks_GetData()
        {
            var db = new AppDbContext();
            return db.Books.OrderBy(b => b.BookId);
        }

        public IQueryable<Category> SelectCategories()
        {
            var db = new AppDbContext();
            return db.Categories.OrderBy(b => b.CategoryId);
        }

        public void ListViewBooks_UpdateItem(int bookId)
        {
            var db = new AppDbContext();
            var item = db.Books.Find(bookId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Book with id {0} was not found", bookId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("Book modified!");
            }
            else
            {
                var errors = GetModelStateErrors(ModelState);
                ErrorSuccessNotifier.AddErrorMessage(string.Join("<br/>", errors));
            }
        }

        public void ListViewBooks_DeleteItem(int bookId)
        {
            var db = new AppDbContext();
            var item = db.Books.Find(bookId);
            db.Books.Remove(item);
            db.SaveChanges();
            ErrorSuccessNotifier.AddInfoMessage("Book deleted!");
        }

        public void ListViewBooks_InsertItem()
        {
            var item = new LibrarySystem.Models.Book();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var db = new AppDbContext();
                db.Books.Add(item);
                db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("New Book Inserted!");
            }
            else
            {
                var errors = GetModelStateErrors(ModelState);
                ErrorSuccessNotifier.AddErrorMessage(string.Join("<br/>", errors));
            }
        }

        protected void ListViewBooks_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ListViewBooks.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonInsertBook_Click(object sender, EventArgs e)
        {
            this.ListViewBooks.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.ListViewBooks.InsertItemPosition = InsertItemPosition.None;
        }



        protected IList<string> GetModelStateErrors(ModelStateDictionary modelStateDict)
        {
            var errors = new List<string>();
            foreach (ModelState modelState in modelStateDict.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            return errors;
        }


        protected void LinkButtonInsertBook_Click(object sender, EventArgs e)
        {
            this.FormViewInsertBook.Visible = true;
        }

        public void FormViewInsertBook_InsertItem()
        {
            var item = new LibrarySystem.Models.Book();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var db = new AppDbContext();
                db.Books.Add(item);
                db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("New Book Inserted!");
                this.FormViewInsertBook.Visible = false;
            }
            else
            {
                var errors = GetModelStateErrors(ModelState);
                ErrorSuccessNotifier.AddErrorMessage(string.Join(";", errors));
            }          
        }

        protected void CancelButtonInsert_Click(object sender, EventArgs e)
        {
            this.FormViewInsertBook.Visible = false;
        }

        protected void HiddenButton_Click(object sender, EventArgs e)
        {

        }
    }
}