using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> ListViewEditCategory_GetData()
        {
            var db = new AppDbContext();
            return db.Categories.OrderBy(c => c.Name);
        }

        public void ListViewEditCategory_InsertItem()
        {
            var db = new AppDbContext();
            var item = new Category();
            TryUpdateModel(item);

            var itemInDb = db.Categories.FirstOrDefault(i => i.Name == item.Name);
            if (itemInDb == null)
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(item);
                    db.SaveChanges();
                }
            }
        }

        public void ListViewEditCategory_DeleteItem(int categoryId)
        {
            var db = new AppDbContext();
            var item = db.Categories.Find(categoryId);
            if (item != null)
            {
                db.Categories.Remove(item);
                db.SaveChanges();
            }
        }

        public void ListViewEditCategory_UpdateItem(int categoryId)
        {
            var db = new AppDbContext();
            var item = db.Categories.Find(categoryId);
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
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.ListViewEditCategory.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonInsertCategory_Click(object sender, EventArgs e)
        {
            this.ListViewEditCategory.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewEditCategory_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ListViewEditCategory.InsertItemPosition = InsertItemPosition.None;
        }
    }
}