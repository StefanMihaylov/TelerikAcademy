namespace ForumSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Areas.Administration.ViewModels;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;

    public class PostController : AdminController
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public PostController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        // GET: Administration/Post
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var posts = this.posts.All()
                .Project().To<AdminPostViewModel>();
            var result = posts.ToDataSourceResult(request);
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CreatePostViewModel newPost)
        {
            if (newPost != null && ModelState.IsValid)
            {
                var post = new Post()
                {
                    Title = newPost.Title,
                    Content = newPost.Content,
                    AuthorId = this.User.Identity.GetUserId(),
                };

                this.posts.Add(post);
                this.posts.SaveChanges();
            }

            return this.Json(new[] { newPost }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, AdminPostViewModel newPost)
        {
            var errors = ModelState["CreatedOn"].Errors;
            if (errors.Count > 0)
            {
                ModelState["CreatedOn"].Errors.Clear();
            }

            if (newPost != null && ModelState.IsValid)
            {
                var post = this.posts.GetById(newPost.Id);

                if (post != null)
                {
                    post.Title = newPost.Title;
                    post.Content = newPost.Content;

                    this.posts.SaveChanges();
                }
            }

            return this.Json(new[] { newPost }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, AdminPostViewModel newPost)
        {
            var errors = ModelState["CreatedOn"].Errors;
            if (errors.Count > 0)
            {
                ModelState["CreatedOn"].Errors.Clear();
            }

            if (newPost != null)
            {
                var post = this.posts.GetById(newPost.Id);

                if (post != null)
                {
                    this.posts.Delete(post);
                    this.posts.SaveChanges();
                }
            }

            return this.Json(new[] { newPost }.ToDataSourceResult(request, this.ModelState));
        }
    }
}