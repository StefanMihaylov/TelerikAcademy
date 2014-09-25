namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Model;

    public interface IGameData
    {
        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<User> Users { get; }

        IRepository<Notification> Notifications { get; }

        int SaveChanges();
    }
}
