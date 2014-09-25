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

namespace BullsAndCows.WebApi.Controllers
{
    public class GuessesController : BaseApiController
    {
        public GuessesController(IGameData data, IUserIdProvider userIdProvider, IGameLogic logic)
            : base(data, userIdProvider, logic)
        {
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult MakeGuess(int id, NumberModel model)
        {
            string userId = this.UserIdProvider.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return BadRequest("Enter number");
            }

            if (!this.Logic.IsNumberValid(model.Number))
            {
                return BadRequest(InvalidNumberMessage);
            }

            var game = this.Data.Games.Find(id);
            if (game == null)
            {
                return BadRequest("Invalid Game ID");
            }

            if (game.GameStatus != Status.BlueInTurn && game.GameStatus != Status.RedInTurn)
            {
                return BadRequest("You cannot play that game"); // TODO write more appropriate message
            }

            if (game.RedPlayerId != userId && game.BluePlayerId != userId)
            {
                return BadRequest("This is not your game");
            }

            if (game.RedPlayerId == userId && game.GameStatus == Status.BlueInTurn ||
                game.BluePlayerId == userId && game.GameStatus == Status.RedInTurn)
            {
                return BadRequest("This is not your turn");
            }

            bool redPlayer;
            int opponentNumber;
            if (game.RedPlayerId == userId)
            {
                redPlayer = true;
                opponentNumber = game.BluePlayerNumber.Value;
            }
            else
            {
                redPlayer = false;
                opponentNumber = game.RedPlayerNumber;
            }

            var result = this.Logic.CalculateBullsAndCows(opponentNumber, model.Number);

            var newGuess = new Guess()
            {
                UserId = userId,
                GameId = id,
                Number = model.Number,
                DateMade = DateTime.Now,
                BullsCount = result.Item1,
                CowsCount = result.Item2,
            };

            this.Data.Guesses.Add(newGuess);

            // change game state
            ChangeStateNotification(game);

            // add guesses to DB
            if (redPlayer)
            {
                game.RedPlayerGuesses.Add(newGuess);
            }
            else
            {
                game.BluePlayerGuesses.Add(newGuess);
            }

            // Game over
            if (newGuess.BullsCount == 4)
            {
                User redUser = this.Data.Users.Find(game.RedPlayerId);
                User blueUser = this.Data.Users.Find(game.BluePlayerId);
                Notification newNotification;
                if (redPlayer)
                {
                    game.GameStatus = Status.RedWon;
                    redUser.Wins++;
                    blueUser.Losses++;

                    newNotification = GameOver(Notification.GameWon, game, blueUser, NotificationType.GameWon, redUser);
                    this.Data.Notifications.Add(newNotification);
                    redUser.Notifications.Add(newNotification);

                    newNotification = GameOver(Notification.GameLost, game, redUser, NotificationType.GameLost, blueUser);
                    this.Data.Notifications.Add(newNotification);
                    blueUser.Notifications.Add(newNotification);
                }
                else
                {
                    game.GameStatus = Status.BlueWon;
                    blueUser.Wins++;
                    redUser.Losses++;

                    newNotification = GameOver(Notification.GameLost, game, blueUser, NotificationType.GameLost, redUser);
                    this.Data.Notifications.Add(newNotification);
                    redUser.Notifications.Add(newNotification);

                    newNotification = GameOver(Notification.GameWon, game, redUser, NotificationType.GameWon, blueUser);
                    this.Data.Notifications.Add(newNotification);
                    blueUser.Notifications.Add(newNotification);
                }

                redUser.Rank = this.Logic.CalculateScore(redUser.Wins, redUser.Losses);
                blueUser.Rank = this.Logic.CalculateScore(blueUser.Wins, blueUser.Losses);
            }

            this.Data.SaveChanges();

            var savedGuess = this.Data.Guesses.All()
                .Where(g => g.GuessId == newGuess.GuessId)
                .Select(GuessModel.FromDb).First();

            return Ok(savedGuess);
        }
    }
}
