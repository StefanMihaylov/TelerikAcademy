namespace ChatChannel.Migrations
{
    using ChatChannel.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChatChannel.Models.AppDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ChatChannel.Models.AppDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var user = new User()
            {
                FirstName = "Admin",
                LastName = "SysAdmin",
                Email = "admin@admin.com",
                
            };

            //user.Roles.Add();
        }
    }
}
