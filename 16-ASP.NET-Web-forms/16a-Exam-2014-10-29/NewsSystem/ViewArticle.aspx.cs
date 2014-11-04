using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace NewsSystem
{
    public partial class ViewArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userLogged = HttpContext.Current.User.Identity.IsAuthenticated;
            var likeButtons = this.FormViewArticle.FindControl("LikeButtons");
            if (userLogged)
            {
                likeButtons.Visible = true;
                 UpdatePanel(new AppDbContext());
            }
            else
            {
                likeButtons.Visible = false;
            }
        }

        public Article FormViewArticle_GetItem([QueryString("id")]int? id)
        {
            var db = new AppDbContext();
            var item = db.Articles.Find(id);
            if (item == null)
            {
                Response.Redirect("/");
                return null;
            }
            else
            {
                return item;
            }
        }

        protected void ButtonLike_Click(object sender, EventArgs e)
        {
            SetLike(1);
        }

        protected void ButtonDislike_Click(object sender, EventArgs e)
        {
            SetLike(-1);
        }

        public int GetLikes()
        {
            var article = GetArticle();
            if (article == null)
            {
                return 0;
            }

            var result = article.Likes.Sum(z => z.Value);
            return result;
        }

        private Article GetArticle()
        {
            var idAsString = Request.QueryString["id"];
            if (string.IsNullOrWhiteSpace(idAsString))
            {
                return null;
            }

            var id = int.Parse(idAsString);

            var db = new AppDbContext();
            var article = db.Articles.Find(id);

            return article;
        }

        private void SetLike(int direction)
        {
            var article = GetArticle();
            if (article == null)
            {
                return;
            }

            var db = new AppDbContext();
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();

            var like = db.Articles.Find(article.ArticleId).Likes.FirstOrDefault(z => z.UserId == currentUserId);
            if (like == null)
            {
                like = new Like();
                like.ArticleId = article.ArticleId;
                like.UserId = currentUserId;
                db.Likes.Add(like);
            }

            like.Value = direction;
            db.SaveChanges();

            UpdatePanel(db);
        }

        private void UpdatePanel(AppDbContext db)
        {
            var panel = (UpdatePanel)this.FormViewArticle.FindControl("updatePanelInsertBook");
            var span = (Label)panel.FindControl("LikesCount");
            span.Text = GetLikes().ToString();

            var likeButtons = this.FormViewArticle.FindControl("LikeButtons");
            var plusButton = likeButtons.FindControl("ButtonLike");
            var munisButton = likeButtons.FindControl("ButtonDislike");

            var article = GetArticle();
            if (article != null)
            {
                var currentUserId = HttpContext.Current.User.Identity.GetUserId();
                var like = db.Articles.Find(article.ArticleId).Likes.FirstOrDefault(z => z.UserId == currentUserId);
                if (like == null)
                {
                    plusButton.Visible = true;
                    munisButton.Visible = true;
                }
                else
                {
                    if (like.Value == 1)
                    {
                        plusButton.Visible = false;
                        munisButton.Visible = true;
                    }
                    else
                    {
                        plusButton.Visible = true;
                        munisButton.Visible = false;

                    }
                }
            }
        }
    }
}