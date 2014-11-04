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
    public partial class EditCategories : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> EditCategoryListView_GetData()
        {
            var db = new AppDbContext();

            var result = db.Categories.OrderBy(c => c.CategoryId);
            return result;
        }

        protected void ButtonInsertCategory_Click(object sender, EventArgs e)
        {
            this.EditCategoryListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void EditCategoryListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.EditCategoryListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.EditCategoryListView.InsertItemPosition = InsertItemPosition.None;
        }

        public void EditCategoryListView_InsertItem()
        {
            var item = new LibrarySystem.Models.Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var db = new AppDbContext();
                db.Categories.Add(item);
                db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("New Category Inserted!");
            }
            else
            {
                var errors = GetModelStateErrors(ModelState);
                ErrorSuccessNotifier.AddErrorMessage(string.Join("<br/>", errors));
            }
        }

        public void EditCategoryListView_DeleteItem(int categoryId)
        {
            var db = new AppDbContext();
            var item = db.Categories.Find(categoryId);
            db.Categories.Remove(item);
            db.SaveChanges();
            ErrorSuccessNotifier.AddInfoMessage("Category deleted!");
        }

        public void EditCategoryListView_UpdateItem(int categoryId)
        {
            var db = new AppDbContext();
            Category item = db.Categories.Find(categoryId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", categoryId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("Category modified!");
            }
            else
            {
                var errors = GetModelStateErrors(ModelState);
                ErrorSuccessNotifier.AddErrorMessage(string.Join("<br/>", errors));
            }
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
    }
}