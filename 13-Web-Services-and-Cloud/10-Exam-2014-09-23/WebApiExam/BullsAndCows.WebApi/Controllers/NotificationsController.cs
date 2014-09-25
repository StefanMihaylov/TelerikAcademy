namespace BullsAndCows.WebApi.Controllers
{
    using BullsAndCows.Data;
    using BullsAndCows.Model;
    using BullsAndCows.WebApi.DataModels;
    using BullsAndCows.WebApi.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class NotificationsController : BaseApiController
    {
        public const int PageSize = 10;

        public NotificationsController(IGameData data, IUserIdProvider userIdProvider, IGameLogic logic)
            : base(data, userIdProvider, logic)
        {
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetAll(int page = 0)
        {
            string userId = this.UserIdProvider.GetUserId();

            var notifications = this.Data.Notifications.All()
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.DateCreated)
                .Skip(page * PageSize)
                .Take(PageSize);

            var result = notifications.Select(NotificationModel.FromDb).ToList();

            foreach (var item in notifications)
            {
                item.State = NotificationState.Read;
            }

            this.Data.SaveChanges();

            return Ok(result);
        }
    }
}
