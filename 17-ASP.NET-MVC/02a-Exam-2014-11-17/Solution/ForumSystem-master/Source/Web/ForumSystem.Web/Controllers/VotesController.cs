namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.Home;
    using Microsoft.AspNet.Identity;

    public class VotesController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly IDeletableEntityRepository<User> users;
        private readonly IDeletableEntityRepository<Vote> votes;

        public VotesController(IDeletableEntityRepository<Post> posts, IDeletableEntityRepository<User> users, IDeletableEntityRepository<Vote> votes)
        {
            this.posts = posts;
            this.users = users;
            this.votes = votes;
        }

        public ActionResult ChangeVote(int dir, int postId)
        {
            if (Request.IsAjaxRequest())
            {
                var currentUserId = this.User.Identity.GetUserId();
                var userPost = this.users.All()
                                    .First(u => u.Id == currentUserId)
                                    .Votes.Where(v => v.PostId == postId && !v.IsDeleted)
                                    .Select(v => new
                                    {
                                        PostId = v.PostId,
                                        UserId = v.UserId,
                                        Value = v.Value,
                                        VoteId = v.VoteId
                                    });

                var lastVote = userPost.FirstOrDefault();

                if (userPost.Count() == 0)
                {
                    var newVote = new Vote()
                    {
                        Value = dir,
                        PostId = postId,
                        UserId = currentUserId,
                    };

                    this.votes.Add(newVote);
                    this.votes.SaveChanges();
                }
                else
                {
                    if (lastVote.Value != dir)
                    {
                        this.votes.Delete(lastVote.VoteId);
                        this.votes.SaveChanges();
                    }
                }

                int sumOfVotes = this.posts.GetById(postId).Votes.Where(v => !v.IsDeleted).Sum(v => v.Value);

                var newModel = new VotesViewModel()
                {
                    PostId = postId,
                    UserId = currentUserId,
                    Votes = sumOfVotes
                };

                return this.PartialView("_VotesPartial", newModel);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}