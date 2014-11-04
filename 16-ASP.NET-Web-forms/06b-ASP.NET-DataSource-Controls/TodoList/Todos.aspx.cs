using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoList.Data;
using TodoList.Model;

namespace TodoList
{
    public partial class Todos : System.Web.UI.Page
    {
        private TodoDbContext db;

        public Todos()
        {
            this.db = new TodoDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<TodoItem> TodoListView_GetData()
        {
            var result = this.db.TodoItems.OrderBy(t => t.TodoItemId);
            return result;
        }

        public IQueryable<Category> CategoriesGridView_GetData()
        {
            return this.db.Categories.OrderBy(t => t.CategoryId);
        }

        public void TodoListView_UpdateItem(int? todoItemId)
        {
            TodoItem item = this.db.TodoItems.Find(todoItemId);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("TODO Item with id {0} was not found", todoItemId));
                return;
            }

            item.LastChanged = DateTime.Now;
            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                this.db.SaveChanges();
            }
        }

        public void TodoListView_InsertItem()
        {
            var item = new TodoList.Model.TodoItem();
            item.LastChanged = DateTime.Now;
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.db.TodoItems.Add(item);
                this.db.SaveChanges();
            }
        }

        public void TodoListView_DeleteItem(int? todoItemId)
        {
            var item = this.db.TodoItems.Find(todoItemId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("TODO Item with id {0} was not found", todoItemId));
                return;
            }

            this.db.TodoItems.Remove(item);
            this.db.SaveChanges();

            DataPager pgr = this.TodoListView.FindControl("DataPager") as DataPager;
            if (pgr != null && TodoListView.Items.Count != pgr.TotalRowCount)
            {
                pgr.SetPageProperties(0, pgr.MaximumRows, false);
            }
        }

        protected void ButtonInsertTodo_Click(object sender, EventArgs e)
        {
            this.TodoListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void TodoListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.TodoListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonCancelInsertTodo_Click(object sender, EventArgs e)
        {
            this.TodoListView.InsertItemPosition = InsertItemPosition.None;
        }

        public void CategoriesGridView_UpdateItem(int? categoryId)
        {
            var item = this.db.Categories.Find(categoryId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Category with id {0} was not found", categoryId));
                return;
            }

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesGridView_DeleteItem(int categoryId)
        {
            var item = this.db.Categories.Find(categoryId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Category with id {0} was not found", categoryId));
                return;
            }

            this.db.Categories.Remove(item);
            this.db.SaveChanges();
        }

        protected void AddNewCategory_Click(object sender, EventArgs e)
        {
            this.InsertCategoryForm.Style.Add("display", "");
            this.TextBoxInsertCategory.Text = "";
        }

        protected void InsertCategory_Click(object sender, EventArgs e)
        {
            var item = new Category() { Name = this.TextBoxInsertCategory.Text };
            this.db.Categories.Add(item);
            this.db.SaveChanges();
            this.InsertCategoryForm.Style.Add("display", "none");
            Response.Redirect("~/");
        }

        protected void CancelCategory_Click(object sender, EventArgs e)
        {
            this.InsertCategoryForm.Style.Add("display", "none");
        }
    }
}