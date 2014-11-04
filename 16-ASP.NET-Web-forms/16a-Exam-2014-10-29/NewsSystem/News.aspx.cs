using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Article> ListViewTopArticles_GetData()
        {
            var db = new AppDbContext();
            var result = db.Articles
                .OrderByDescending(a => (a.Likes.Sum(z => z.Value) == null ? 0: a.Likes.Sum(z => z.Value)))
                .Take(3);
            return result;
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

        public long GetLikes(ICollection<Like> likes)
        {
            var result = likes.Sum(z => z.Value);
            return result;
        }

        public IQueryable<Category> ListViewTopCalegories_GetData()
        {
            var db = new AppDbContext();
            return db.Categories.OrderBy(c => c.Name);
        }

        public ICollection<Article> GetLatestArticles(ICollection<Article> articles)
        {
            return articles.OrderByDescending(a => a.DateCreated).Take(3).ToList();
        }
    }
}