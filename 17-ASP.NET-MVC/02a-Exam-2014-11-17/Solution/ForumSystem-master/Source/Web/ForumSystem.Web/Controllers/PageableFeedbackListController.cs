namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.Feedback;

    [Authorize]
    public class PageableFeedbackListController : Controller
    {
        public const int ItemPerPage = 4;
        private readonly IDeletableEntityRepository<Feedback> feedbacks;

        public PageableFeedbackListController(IDeletableEntityRepository<Feedback> feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        // GET: PageableFeedbackList
        public ActionResult Index()
        {
            ViewBag.Page = 1;
            ViewBag.MaxPage = this.GetMaxPages();

            var feedbackPage = this.GetData().Take(ItemPerPage).ToList();

            return this.View(feedbackPage);
        }

        [OutputCache(Duration = 5 * 60, VaryByParam = "page")]
        public ActionResult ChangePage(int page)
        {
            if (Request.IsAjaxRequest())
            {
                var currentPage = page;
                var maxPages = this.GetMaxPages();

                if (currentPage <= 0)
                {
                    currentPage = 1;
                }

                if (currentPage > maxPages)
                {
                    currentPage = maxPages;
                }

                var feedbackPage = this.GetData().Skip((currentPage - 1) * ItemPerPage).Take(ItemPerPage).ToList();
                ViewBag.Page = currentPage;
                ViewBag.MaxPage = maxPages;

                return this.PartialView("_FeedbackPagePartial", feedbackPage);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        private IQueryable<FeedbackViewModel> GetData()
        {
            return this.feedbacks.All().OrderBy(p => p.CreatedOn)
                                       .Project().To<FeedbackViewModel>();
        }

        private int GetMaxPages()
        {
            var totalItems = this.GetData().Count();

            int maxPages = totalItems / ItemPerPage;
            if (totalItems % ItemPerPage > 0)
            {
                maxPages++;
            }

            return maxPages;
        }
    }
}