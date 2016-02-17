namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.InputModels.Feedback;

    using Microsoft.AspNet.Identity;

    public class FeedbackController : Controller
    {
        private readonly IDeletableEntityRepository<Feedback> feedbacks;

        public FeedbackController(IDeletableEntityRepository<Feedback> feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InputFeedbackViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var feedback = new Feedback()
                {
                    Title = model.Title,
                    Content = model.Content,
                    AuthorId = this.User.Identity.GetUserId()
                };

                this.feedbacks.Add(feedback);

                this.feedbacks.SaveChanges();
            }

            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}