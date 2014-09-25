namespace BullsAndCows.WebApi.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using BullsAndCows.Data;
    using BullsAndCows.WebApi.Infrastructure;
    using BullsAndCows.Model;
    using System;

    public class BaseApiController : ApiController
    {
        public const string InvalidNumberMessage = "Error! Provides a four non-repeating digits";

        public BaseApiController(IGameData data, IUserIdProvider userIdProvider, IGameLogic logic)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
            this.Logic = logic;
        }

        public IGameData Data { get; private set; }

        public IUserIdProvider UserIdProvider { get; private set; }

        public IGameLogic Logic { get; private set; }

        protected Notification GameOver(string message, Game game, User user, NotificationType type, User currentUser)
        {
            return new Notification()
            {
                Message = string.Format(message, game.Name, user.UserName),
                DateCreated = DateTime.Now,
                Type = type,
                State = NotificationState.Unread,
                GameId = game.GameId,
                UserId = currentUser.Id
            };
        }

        protected Notification ChangeState(Game game, User user)
        {
            return new Notification()
            {
                Message = string.Format(Notification.YourTurnMessage, game.Name),
                DateCreated = DateTime.Now,
                Type = NotificationType.YourTurn,
                State = NotificationState.Unread,
                GameId = game.GameId,
                UserId = user.Id
            };
        }

        protected void ChangeStateNotification(Game game)
        {
            User redUser = this.Data.Users.Find(game.RedPlayerId);
            User blueUser = this.Data.Users.Find(game.BluePlayerId);

            Notification changeNotification;
            if (game.GameStatus == Status.RedInTurn)
            {
                game.GameStatus = Status.BlueInTurn;
                changeNotification = this.ChangeState(game, blueUser);
                blueUser.Notifications.Add(changeNotification);
            }
            else
            {
                game.GameStatus = Status.RedInTurn;
                changeNotification = this.ChangeState(game, redUser);
                redUser.Notifications.Add(changeNotification);
            }

            this.Data.Notifications.Add(changeNotification);
        }
    }
}
