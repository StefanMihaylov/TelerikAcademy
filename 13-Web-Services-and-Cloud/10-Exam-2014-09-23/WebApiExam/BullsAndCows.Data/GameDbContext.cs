namespace BullsAndCows.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using BullsAndCows.Model;
    using BullsAndCows.Data.Migrations;

    public class GameDbContext : IdentityDbContext<User>
    {
        public GameDbContext()
            : base("BullsAndCows", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GameDbContext, Configuration>());
        }

        public static GameDbContext Create()
        {
            return new GameDbContext();
        }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Guess> Guesses { get; set; }

         public virtual IDbSet<Notification> Notifications { get; set; }
    }
}
