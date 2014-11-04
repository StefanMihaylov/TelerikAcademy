namespace TodoList.Data
{
    using System.Data.Entity;

    using TodoList.Migrations;
    using TodoList.Model;

    public class TodoDbContext : DbContext
    {
        public TodoDbContext()
            : base("TodoListDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoDbContext, Configuration>());
        }

        public IDbSet<TodoItem> TodoItems { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }
}