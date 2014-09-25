namespace BugLogger.WebApi.Tests.FakeRepos
{
    using BugLogger.Data;
    using BugLogger.Data.Repositories;
    using BugLogger.Model;

    class FakeLoggerData : IBugLoggerData
    {
        private IRepository<Bug> fakeBugs;

        public bool IsSaveCalled { get; set; }

        public FakeLoggerData()
        {
            this.fakeBugs = new FakeRepository<Bug>();
            this.IsSaveCalled = false;
        }

        public Data.Repositories.IRepository<Model.Bug> Bugs
        {
            get { return this.fakeBugs; }
        }

        public int SaveChanges()
        {
            this.IsSaveCalled = true;
            return 1;
        }
    }
}
