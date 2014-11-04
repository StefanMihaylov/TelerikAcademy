namespace NewsSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsSystem.Models.AppDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsSystem.Models.AppDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var data = new SeedData();
            context.Categories.AddOrUpdate(data.Categories.ToArray());
            context.Articles.AddOrUpdate(data.Articles.ToArray());
            context.SaveChanges();
        }
    }
}
