using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicTacToe.Data;
using TicTacToe.GameLogic;
using TicTacToe.Web.DataModels;

namespace TicTacToe.Web.Controllers
{
    public class ScoresController : BaseApiController
    {
        private IGameResultValidator resultValidator;

        public ScoresController(ITicTacToeData data, IGameResultValidator resultValidator)
            : base(data)
        {
            this.resultValidator = resultValidator;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var results = this.data.Users.All()
                .OrderByDescending(u => u.Rank)
                .Take(10)
                .Select(u => new ScoreDataModel()
                {
                    Id = 0,
                    Username = u.UserName,
                    Wins = u.Wins,
                    Draws = u.Draws,
                    Losses = u.Losses,
                    Rank = u.Rank
                }).ToList();

            for (int i = 0; i < results.Count; i++)
            {
                results[i].Id = i + 1;
            }

            return Ok(results);
        }
    }
}
