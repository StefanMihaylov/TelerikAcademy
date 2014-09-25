namespace BugLogger.WebApi.Tests
{
    using System;
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BugLogger.Model;
    using BugLogger.Data;

    [TestClass]
    public class BugLoggerRepositoryTests
    {
        static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void AddBug_WhenBigIsValid_ShouldAddToDb()
        {
            var context = new BugLoggerDbContext();
            var data = new BugLoggerData(context);

            var bug = new Bug()
            {
                Text = "Test big",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };

            data.Bugs.Add(bug);
            data.SaveChanges();

            var bugInDb = context.Bugs.Find(bug.BugId);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void FindBug_WhenBugInDb_ShouldReturnBug()
        {
            var context = new BugLoggerDbContext();
            var data = new BugLoggerData(context);

            var bug = new Bug()
            {
                Text = "Test big",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };

            context.Bugs.Add(bug);
            data.SaveChanges();

            var bugInDb = data.Bugs.Find(bug.BugId);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void DeleteBug_WhenBugInDb_ShouldDeleteBug()
        {
            var context = new BugLoggerDbContext();
            var data = new BugLoggerData(context);

            var bug = new Bug()
            {
                Text = "Test big",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };

            context.Bugs.Add(bug);
            data.SaveChanges();

            data.Bugs.Delete(bug.BugId);

            var bugInDb = context.Bugs.Find(bug.BugId);

            Assert.IsNotNull(bugInDb);
        }

        [TestMethod]
        public void UpdateBugStatus_WhenBugInDb_ShouldUpdateStatus()
        {
            var context = new BugLoggerDbContext();
            var data = new BugLoggerData(context);

            var bug = new Bug()
            {
                Text = "Test big",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };

            context.Bugs.Add(bug);
            data.SaveChanges();

            var bugInDb = context.Bugs.Find(bug.BugId);
            bugInDb.Status = Status.Fixed;

            data.Bugs.Update(bugInDb);

            bugInDb = data.Bugs.Find(bug.BugId);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(Status.Fixed, bugInDb.Status);
        }
    }
}
