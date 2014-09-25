namespace BullsAndCows.WebApi.DataModels
{
    using BullsAndCows.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class GameWaitingModel
    {
        public static Expression<Func<Game, GameWaitingModel>> FromDb
        {
            get
            {
                return g => new GameWaitingModel()
                {
                    Id = g.GameId,
                    Name = g.Name,
                    Red = g.RedPlayer.UserName,
                    Blue = g.BluePlayer.UserName != null ? g.BluePlayer.UserName : "No blue player yet",
                    GameState = g.GameStatus.ToString(),
                    DateCreated = g.DateCreated,
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}