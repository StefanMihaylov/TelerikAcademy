namespace BugLogger.WebApi.Tests
{
    using BugLogger.WebApi.Tests.FakeRepos;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Routing;

    using Telerik.JustMock;

    using BugLogger.Data;
    using BugLogger.Model;
    using BugLogger.WebApi.Controllers;
    using System.Net;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection()
        {
            var fakeData = new FakeLoggerData();
            var bugs = new List<Bug>(){
                new Bug(){ Text = "Test bug #1"},
                new Bug(){ Text = "Test bug #2"},
                new Bug(){ Text = "Test bug #3"},
            };

            foreach (var bug in bugs)
            {
                fakeData.Bugs.Add(bug);
            }

            var controller = new BugsController(fakeData);
            var result = controller.GetAll();

            CollectionAssert.AreEqual(bugs, result.ToList());
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_SholdBeAddedToRepoWithValidDateAndStatus()
        {
            var fakeData = new FakeLoggerData();
            var bug = new Bug() { Text = "Test bug" };
            var controller = new BugsController(fakeData);

            this.SetupController(controller);

            controller.PostBug(bug);

            var record = fakeData.Bugs.All().FirstOrDefault();
            var count = fakeData.Bugs.All().Count();

            Assert.IsNotNull(record, "Recond is not Null");
            Assert.AreEqual(count, 1, "Count is 1");
            Assert.AreEqual(bug.Text, record.Text, "Record Text are equal");
            Assert.AreEqual(Status.Pending, record.Status, "Status is set");
            Assert.IsNotNull(record.LogDate, "Date is set");
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection_WithMock()
        {
            var bugs = new List<Bug>(){
                new Bug(){ Text = "Test bug #1"},
                new Bug(){ Text = "Test bug #2"},
                new Bug(){ Text = "Test bug #3"},
            };

            var fakeData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => fakeData.Bugs.All()).Returns(() => bugs.AsQueryable());

            var controller = new BugsController(fakeData);
            var result = controller.GetAll();

            CollectionAssert.AreEqual(bugs, result.ToList());
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_SholdBeAddedToRepoWithValidData_withMock()
        {
            bool isItemAdded = false;
            var bug = new Bug() { Text = "Test bug" };

            var fakeData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => fakeData.Bugs.Add(Arg.IsAny<Bug>()))
                .DoInstead(() => isItemAdded = true);

            var controller = new BugsController(fakeData);
            this.SetupController(controller);

            controller.PostBug(bug);

            Assert.IsTrue(isItemAdded, "Recond is added");
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsInvalid_SholdReturnBadRequest()
        {
            bool isItemAdded = false;
            var bug = new Bug();

            var fakeData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => fakeData.Bugs.Add(Arg.IsAny<Bug>()))
                .DoInstead(() => isItemAdded = true);

            var controller = new BugsController(fakeData);
            this.SetupController(controller);

            controller.PostBug(bug);

            Assert.IsFalse(isItemAdded, "Recond is added");
        }

        [TestMethod]
        public void GetAllBugsByStatus_WhenValid_ShouldReturnBugsCollection()
        {
            var bugs = new List<Bug>(){
                new Bug(){ Text = "Test bug #1", Status = Status.Pending},
                new Bug(){ Text = "Test bug #2", Status = Status.Fixed},
                new Bug(){ Text = "Test bug #3", Status = Status.Assigned},
            };

            var fakeData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => fakeData.Bugs.All()).Returns(() => bugs.Where(b => b.Status == Status.Pending).AsQueryable());

            var controller = new BugsController(fakeData);
            var result = controller.GetByStatus(Status.Pending);

            Assert.IsNotNull(result, "Recond is not Null");
            Assert.AreEqual(result.Count(), 1, "Count is 1");
            Assert.AreEqual(bugs.First().Text, result.First().Text, "Record Text are equal");
            Assert.AreEqual(Status.Pending, result.First().Status, "Status is set");
        }

        [TestMethod]
        public void PugBug_WhenValid_ShouldChangeBugStatus()
        {
            var bugs = new List<Bug>(){
                new Bug(){ Text = "Test bug #1", Status = Status.Pending},
            };

            var fakeData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => fakeData.Bugs.Find(1)).Returns(() => bugs[0]);

            var controller = new BugsController(fakeData);
            this.SetupController(controller);

            var result = controller.PutBug(1);

            Assert.IsNotNull(result, "Response is not Null");
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Status Code is OK");
            Assert.AreEqual(Status.Fixed, bugs.First().Status, "Status is set");
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
              { "controller", "bugs" } 
              });
        }
    }
}
