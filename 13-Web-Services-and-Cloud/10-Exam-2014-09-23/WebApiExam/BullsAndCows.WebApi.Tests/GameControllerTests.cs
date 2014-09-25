using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using BullsAndCows.Data;
using BullsAndCows.Model;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using BullsAndCows.WebApi.Controllers;
using BullsAndCows.WebApi.Infrastructure;
using System.Threading;
using BullsAndCows.WebApi.DataModels;

namespace BullsAndCows.WebApi.Tests
{
    [TestClass]
    public class GameControllerTests
    {
        [TestMethod]
        public void GetAll_When5GamesInDB_ShouldReturn5Games()
        {
            var games = this.GenerateValidGames(5);

            var userProvider = Mock.Create<IUserIdProvider>();
            var logic = Mock.Create<IGameLogic>();

            var data = Mock.Create<IGameData>();
            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data, userProvider, logic);
            this.SetupController(controller);

            var actionResult = controller.GetAll();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var content = response.Content.ReadAsAsync<IEnumerable<GameWaitingModel>>().Result;

            var result = content.ToList();
            var expected = games.AsQueryable()
                .Where(g => g.GameStatus == Status.WaitingForOpponent)
                .OrderBy(g => g.GameStatus)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                //.Skip(page * GamesController.PageSize)
                .Take(GamesController.PageSize)
                .Select(GameWaitingModel.FromDb).ToList();

            Assert.AreEqual(expected.Count, result.Count, "Count problem");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Red, result[i].Red);
                Assert.AreEqual(expected[i].Blue, result[i].Blue);
            }
        }

        [TestMethod]
        public void GetAll_When10GamesInDB_ShouldReturn10Games()
        {
            var games = this.GenerateValidGames(10);

            var userProvider = Mock.Create<IUserIdProvider>();
            var logic = Mock.Create<IGameLogic>();

            var data = Mock.Create<IGameData>();
            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data, userProvider, logic);
            this.SetupController(controller);

            var actionResult = controller.GetAll();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var content = response.Content.ReadAsAsync<IEnumerable<GameWaitingModel>>().Result;

            var result = content.ToList();
            var expected = games.AsQueryable()
                .Where(g => g.GameStatus == Status.WaitingForOpponent)
                .OrderBy(g => g.GameStatus)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                //.Skip(page * GamesController.PageSize)
                .Take(GamesController.PageSize)
                .Select(GameWaitingModel.FromDb).ToList();

            Assert.AreEqual(expected.Count, result.Count, "Count problem");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Red, result[i].Red);
                Assert.AreEqual(expected[i].Blue, result[i].Blue);
            }
        }

        [TestMethod]
        public void GetAll_When15GamesInDB_ShouldReturn10Games()
        {
            var games = this.GenerateValidGames(15);

            var userProvider = Mock.Create<IUserIdProvider>();
            var logic = Mock.Create<IGameLogic>();

            var data = Mock.Create<IGameData>();
            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data, userProvider, logic);
            this.SetupController(controller);

            var actionResult = controller.GetAll();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var content = response.Content.ReadAsAsync<IEnumerable<GameWaitingModel>>().Result;

            var result = content.ToList();
            var expected = games.AsQueryable()
                .Where(g => g.GameStatus == Status.WaitingForOpponent)
                .OrderBy(g => g.GameStatus)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                //.Skip(page * GamesController.PageSize)
                .Take(GamesController.PageSize)
                .Select(GameWaitingModel.FromDb).ToList();

            Assert.AreEqual(expected.Count, result.Count, "Count problem");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Red, result[i].Red);
                Assert.AreEqual(expected[i].Blue, result[i].Blue);
            }
        }

        [TestMethod]
        public void GetAllPage1_When30GamesInDB_ShouldReturn10Games()
        {
            int page = 1;
            var games = this.GenerateValidGames(30);

            var userProvider = Mock.Create<IUserIdProvider>();
            var logic = Mock.Create<IGameLogic>();

            var data = Mock.Create<IGameData>();
            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data, userProvider, logic);
            this.SetupController(controller);

            var actionResult = controller.GetAll();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var content = response.Content.ReadAsAsync<IEnumerable<GameWaitingModel>>().Result;

            var result = content.ToList();
            var expected = games.AsQueryable()
                .Where(g => g.GameStatus == Status.WaitingForOpponent)
                .OrderBy(g => g.GameStatus)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Skip(page * GamesController.PageSize)
                .Take(GamesController.PageSize)
                .Select(GameWaitingModel.FromDb).ToList();

            Assert.AreEqual(expected.Count, result.Count, "Count problem");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Red, result[i].Red);
                Assert.AreEqual(expected[i].Blue, result[i].Blue);
            }
        }

        [TestMethod]
        public void GetAllPage2_When30GamesInDB_ShouldReturn10Games()
        {
            int page = 2;
            var games = this.GenerateValidGames(30);

            var userProvider = Mock.Create<IUserIdProvider>();
            var logic = Mock.Create<IGameLogic>();

            var data = Mock.Create<IGameData>();
            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data, userProvider, logic);
            this.SetupController(controller);

            var actionResult = controller.GetAll();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var content = response.Content.ReadAsAsync<IEnumerable<GameWaitingModel>>().Result;

            var result = content.ToList();
            var expected = games.AsQueryable()
                .Where(g => g.GameStatus == Status.WaitingForOpponent)
                .OrderBy(g => g.GameStatus)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Skip(page * GamesController.PageSize)
                .Take(GamesController.PageSize)
                .Select(GameWaitingModel.FromDb).ToList();

            Assert.AreEqual(expected.Count, result.Count, "Count problem");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Red, result[i].Red);
                Assert.AreEqual(expected[i].Blue, result[i].Blue);
            }
        }

        private ICollection<Game> GenerateValidGames(int count)
        {
            var guesses = new List<Guess>(){
                new Guess(){
                    Number = 2345,
                    BullsCount = 0,
                    CowsCount = 0,
                    GameId = 1,
                    DateMade = DateTime.Now,
                    User = new User(),
                    GuessId = 1,                     
                }
            };

            var result = new List<Game>(count);
            for (int i = 0; i < count; i++)
            {
                var newArticle = new Game()
                {
                    GameId = i,
                    Name = "Title #" + i,
                    RedPlayerNumber = 1234,
                    BluePlayerNumber = 5678,
                    DateCreated = DateTime.Now.AddDays(-i),
                    GameStatus = Status.BlueInTurn,
                    RedPlayerGuesses = guesses,
                    BluePlayerGuesses = guesses,
                    RedPlayer = new User(),
                    BluePlayer = new User(),


                };

                result.Add(newArticle);
            }

            return result;
        }

        private void SetupController(ApiController controller)
        {
            var request = new HttpRequestMessage() { RequestUri = new Uri("http://test-url.com") };
            controller.Request = request;
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;
            controller.RequestContext.RouteData = new HttpRouteData(
              route: new HttpRoute(),
              values: new HttpRouteValueDictionary { 
              { "controller", "games" } 
              });
        }
    }
}
