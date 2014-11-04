using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Web.ModelBinding;
using System.Windows.Forms;

namespace NewsSystem.Admin
{
    public partial class EditArticles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Article> ListViewEditArticles_GetData()
        {
            var db = new AppDbContext();
            return db.Articles.OrderBy(a => a.ArticleId);

        }

        public void ListViewEditArticles_InsertItem()
        {
            var item = new Article();
            TryUpdateModel(item);

            item.DateCreated = DateTime.Now;
            var userLogged = HttpContext.Current.User.Identity.GetUserId();
            item.AuthorId = userLogged;

            if (ModelState.IsValid)
            {
                var db = new AppDbContext();
                db.Articles.Add(item);
                db.SaveChanges();
            }
            else
            {
                //var errors = GetModelStateErrors(ModelState);
                //var control = this.ListViewEditArticles.InsertItem.FindControl("LabelInsertErrors");
                //var errorControl = (Label)control;
                //errorControl.Text = string.Join("<br/>", errors);
            }
        }

        public void ListViewEditArticles_DeleteItem(int articleId)
        {
            var db = new AppDbContext();
            var item = db.Articles.Find(articleId);
            if (item != null)
            {
                db.Articles.Remove(item);
                db.SaveChanges();
            }
        }

        public void ListViewEditArticles_UpdateItem(int articleId)
        {
            var db = new AppDbContext();
            var item = db.Articles.Find(articleId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Article id {0} was not found", articleId));
                return;
            }
            TryUpdateModel(item);

            item.DateCreated = DateTime.Now;
            var userLogged = HttpContext.Current.User.Identity.GetUserId();
            item.AuthorId = userLogged;

            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }
        }

        protected void ListViewEditArticles_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ListViewEditArticles.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonInsertArticle_Click(object sender, EventArgs e)
        {
            this.ListViewEditArticles.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.ListViewEditArticles.InsertItemPosition = InsertItemPosition.None;
        }

        public ICollection<Category> SelectCategories()
        {
            var db = new AppDbContext();
            return db.Categories.OrderBy(c => c.Name).ToList();
        }

        public string GetContent(string original)
        {
            const int ContentLenght = 300;

            if (original.Length < ContentLenght)
            {
                return original;
            }
            else
            {
                string result = original.Substring(0, ContentLenght);
                return result + "...";
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