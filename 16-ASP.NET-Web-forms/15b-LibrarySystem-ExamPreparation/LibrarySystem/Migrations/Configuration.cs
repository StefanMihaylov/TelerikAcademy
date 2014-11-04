namespace LibrarySystem.Migrations
{
    using LibrarySystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibrarySystem.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LibrarySystem.Models.AppDbContext context)
        {
            if (!context.Books.Any())
            {
                context.Categories.AddOrUpdate(StaticData.Categories.ToArray());
                context.Books.AddOrUpdate(StaticData.Books.ToArray());

                context.SaveChanges();
            }
        }
    }
}
