using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BugLogger.Model;
using Telerik.JustMock;
using BugLogger.Data;
using BugLogger.Data.Repositories;
using System.Net;

namespace BugLogger.WebApi.Tests
{
    [TestClass]
    public class BugLoggerIntegrationTests
    {
        [TestMethod]
        public void GetBugs_ShouldReturnStatusOkAndNonEmptyContent()
        {
            var bugs = new List<Bug>() { new Bug() { Text = "Test bug" } };

            var fakeRepo = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => fakeRepo.Bugs.All()).Returns(() => bugs.AsQueryable());

            var server = new InMemoryHttpServer("Http://lockalhost:12345/api/", fakeRepo);

            var responce = server.CreateGetRequest("bugs");

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
            Assert.IsNotNull(responce.Content);
        }

        [TestMethod]
        public void PostBugs_WhenBugWithNoText_ShouldReturnStatusBadRequest()
        {
            var bugs = new List<Bug>() { new Bug() { Text = "Test bug" } };
            var fakeRepo = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => fakeRepo.Bugs.All()).Returns(() => bugs.AsQueryable());

            var server = new InMemoryHttpServer("Http://lockalhost:12345/api/", fakeRepo);

            var responce = server.CreatePostRequest("bugs", new Bug());

            Assert.AreEqual(HttpStatusCode.BadRequest, responce.StatusCode);
        }

        [TestMethod]
        public void PutBugs_WhenBugIsFound_ShouldReturnStatusOk()
        {
            var bugs = new List<Bug>() { new Bug() { Text = "Test bug", Status = Status.Pending } };

            var fakeRepo = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => fakeRepo.Bugs.All()).Returns(() => bugs.AsQueryable());
            Mock.Arrange(() => fakeRepo.Bugs.Find(Arg.AnyInt)).Returns(() => bugs.First());

            var server = new InMemoryHttpServer("Http://lockalhost:12345/api/", fakeRepo);

            var responce = server.CreatePutRequest("bugs", 1);

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
            Assert.IsNotNull(responce.Content);
        }
    }
}
