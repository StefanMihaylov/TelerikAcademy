namespace BugLogger.Data
{
    using BugLogger.Data.Repositories;
    using BugLogger.Model;

    public interface IBugLoggerData
    {
        IRepository<Bug> Bugs { get; }

        int SaveChanges();
    }
}
