namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoList.Data;
    using TodoList.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TodoDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var currentDate = DateTime.Now;

            var categories = new Category[]
            {
                new Category() { Name = "Supermarker" },
                new Category() { Name = "Academy" },
                new Category() { Name = "Friends" }
            };

            var todos = new TodoItem[]
            {
                new TodoItem()
                {
                    Title = "Beer",
                    Body = "To buy a few bottles of beer",
                    Category = categories[0],
                    LastChanged = currentDate
                },
                new TodoItem()
                {
                    Title = "Rakia",
                    Body = "To buy a few bottles of rakia",
                    Category = categories[0],
                    LastChanged = currentDate.AddDays(-1)
                },
                new TodoItem()
                {
                    Title = "Pub",
                    Body = "To meet some friends at friday evening",
                    Category = categories[2],
                    LastChanged = currentDate.AddDays(-2)
                },
                new TodoItem()
                {
                    Title = "Team project",
                    Body = "To finish my teamwork",
                    Category = categories[1],
                    LastChanged = currentDate.AddDays(-3)
                },
                new TodoItem()
                {
                    Title = "Homework",
                    Body = "To write my homework",
                    Category = categories[1],
                    LastChanged = currentDate.AddDays(-4)
                }
            };

            context.TodoItems.AddOrUpdate(todos);
            context.SaveChanges();
        }
    }
}