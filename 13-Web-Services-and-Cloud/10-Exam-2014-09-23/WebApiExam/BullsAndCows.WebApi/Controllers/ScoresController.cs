using BullsAndCows.Data;
using BullsAndCows.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BullsAndCows.WebApi.Controllers
{
    public class ScoresController : BaseApiController
    {
        public const int PageSize = 10;

        public ScoresController(IGameData data, IUserIdProvider userIdProvider, IGameLogic logic)
            : base(data, userIdProvider, logic)
        {
        }

        [HttpGet]
        public IHttpActionResult GetScore()
        {
            var result = this.Data.Users.All()
                .OrderByDescending(u => u.Rank)
                .Take(PageSize)
                .Select(u => new { Username = u.UserName, Rank = u.Rank });

            return Ok(result);
        }
    }
}
