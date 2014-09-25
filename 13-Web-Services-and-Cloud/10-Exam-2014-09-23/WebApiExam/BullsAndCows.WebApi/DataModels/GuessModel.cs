using BullsAndCows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.WebApi.DataModels
{
    public class GuessModel
    {
        public static Expression<Func<Guess, GuessModel>> FromDb
        {
            get
            {
                return g => new GuessModel()
                {
                    Id = g.GuessId,
                    UserId = g.UserId,
                    Username = g.User.UserName,
                    GameId = g.GameId,
                    Number = g.Number,
                    DateMade = g.DateMade,
                    CowsCount = g.CowsCount,
                    BullsCount = g.BullsCount
                };
            }
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public int GameId { get; set; }

        public int Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}