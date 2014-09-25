namespace BugLogger.Data
{
    using BugLogger.Data.Migrations;
    using BugLogger.Model;
    using System.Data.Entity;

    public class BugLoggerDbContext : DbContext
    {
        public BugLoggerDbContext()
            : base("BugLoggerDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }
    }
}
