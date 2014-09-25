namespace BullsAndCows.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Model;
    using BullsAndCows.WebApi.DataModels;
    using BullsAndCows.WebApi.Infrastructure;
    using System.Collections.Generic;

    public class GamesController : BaseApiController
    {
        public const int PageSize = 10;

        private Random random;

        public GamesController(IGameData data, IUserIdProvider userIdProvider, IGameLogic logic)
            : base(data, userIdProvider, logic)
        {
            this.random = new Random();
        }

        [HttpGet]
        public IHttpActionResult GetAll(int page = 0)
        {
            string userId = this.UserIdProvider.GetUserId();

            IQueryable<Game> selectedGames = this.Data.Games.All();
            if (userId == null)
            {
                selectedGames = selectedGames.Where(g => g.GameStatus == Status.WaitingForOpponent);
            }
            else
            {
                selectedGames = selectedGames.Where(g => (g.RedPlayerId == userId || g.BluePlayerId == userId));
            }

            var games = selectedGames
                .OrderBy(g => g.GameStatus)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Skip(page * PageSize)
                .Take(PageSize)
                .Select(GameWaitingModel.FromDb);

            return Ok(games);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            string userId = this.UserIdProvider.GetUserId();

            var game = this.Data.Games.Find(id);
            if (game == null)
            {
                return BadRequest("Invalid game Id");
            }

            if (game.RedPlayerId != userId && game.BluePlayerId != userId)
            {
                return BadRequest("This is not your game");
            }

            ICollection<GuessModel> yourGuesses;
            ICollection<GuessModel> opponentGuesses;
            string yourColor;
            if (game.RedPlayerId == userId)
            {
                yourGuesses = game.RedPlayerGuesses.AsQueryable().Select(GuessModel.FromDb).ToList();
                opponentGuesses = game.BluePlayerGuesses.AsQueryable().Select(GuessModel.FromDb).ToList();
                yourColor = "red";
            }
            else
            {
                yourGuesses = game.BluePlayerGuesses.AsQueryable().Select(GuessModel.FromDb).ToList();
                opponentGuesses = game.RedPlayerGuesses.AsQueryable().Select(GuessModel.FromDb).ToList();
                yourColor = "blue";
            }

            var result = new GameDetailModel()
                {
                    Id = game.GameId,
                    Name = game.Name,
                    DateCreated = game.DateCreated,
                    Red = game.RedPlayer.UserName,
                    Blue = game.BluePlayer.UserName != null ? game.BluePlayer.UserName : "No blue player yet",
                    YourGuesses = yourGuesses,
                    OpponentGuesses = opponentGuesses,
                    YourColor = yourColor,
                    GameState = game.GameStatus.ToString()
                };

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(GameCreateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (!this.Logic.IsNumberValid(model.Number))
            {
                return BadRequest(InvalidNumberMessage);
            }

            var newGame = new Game()
            {
                Name = model.Name,
                RedPlayerId = this.UserIdProvider.GetUserId(),
                RedPlayerNumber = model.Number,
                GameStatus = Status.WaitingForOpponent,
                DateCreated = DateTime.Now,
            };

            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();

            var savedGame = this.Data.Games.All().Where(g => g.GameId == newGame.GameId).Select(GameWaitingModel.FromDb).First();
            string location = Request.RequestUri + "/" + savedGame.Id;

            return Created(location, savedGame);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult JoinGame(int id, NumberModel number)
        {
            string userId = this.UserIdProvider.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return BadRequest("Enter number");
            }

            var game = this.Data.Games.Find(id);
            if (game == null)
            {
                return BadRequest("Invalid Game ID");
            }

            if (game.GameStatus != Status.WaitingForOpponent)
            {
                return BadRequest("Game is not waiting for opponent");
            }

            if (game.RedPlayerId == userId)
            {
                return BadRequest("You already are part of that game");
            }

            if (!this.Logic.IsNumberValid(number.Number))
            {
                return BadRequest(InvalidNumberMessage);
            }

            game.BluePlayerId = userId;
            game.BluePlayerNumber = number.Number;

            game.GameStatus = Status.RedInTurn;
            int randomNumber = this.random.Next(0, 101);
            if (randomNumber <= 50)
            {
                game.GameStatus = Status.BlueInTurn;
            }

            ChangeStateNotification(game);

            this.Data.SaveChanges();

            var newNotification = new Notification()
            {
                Message = string.Format(Notification.GameJoined, game.Name, game.RedPlayer.UserName),
                DateCreated = DateTime.Now,
                Type = NotificationType.GameJoined,
                State = NotificationState.Unread,
                GameId = game.GameId,
                UserId = userId
            };

            this.Data.Notifications.Add(newNotification);

            var redUser = this.Data.Users.Find(game.RedPlayerId);
            redUser.Notifications.Add(newNotification);

            this.Data.SaveChanges();

            string resultMessage = string.Format("You joined game \"{0}\"", game.Name);
            return Ok(new { result = resultMessage });
        }
    }
}
