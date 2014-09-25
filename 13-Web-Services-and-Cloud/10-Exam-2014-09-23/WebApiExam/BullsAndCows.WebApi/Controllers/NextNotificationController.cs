using BullsAndCows.Data;
using BullsAndCows.Model;
using BullsAndCows.WebApi.DataModels;
using BullsAndCows.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BullsAndCows.WebApi.Controllers
{
    public class NextNotificationController : BaseApiController
    {
        public NextNotificationController(IGameData data, IUserIdProvider userIdProvider, IGameLogic logic)
            : base(data, userIdProvider, logic)
        {
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetNext()
        {
            string userId = this.UserIdProvider.GetUserId();

            var nextNotification = this.Data.Notifications.All()
                .Where(n => n.UserId == userId)
                .Where(n => n.State == NotificationState.Unread)
                .OrderBy(n => n.DateCreated)
                .FirstOrDefault();

            if (nextNotification == null)
            {
                return NotFound();
            }

            var result = new NotificationModel()
                {
                    Id = nextNotification.Id,
                    Message = nextNotification.Message,
                    DateCreated = nextNotification.DateCreated,
                    Type = nextNotification.Type.ToString(),
                    State = nextNotification.State.ToString(),
                    GameId = nextNotification.GameId
                };

            nextNotification.State = NotificationState.Read;
            this.Data.SaveChanges();

            return Ok(result);
        }
    }
}
