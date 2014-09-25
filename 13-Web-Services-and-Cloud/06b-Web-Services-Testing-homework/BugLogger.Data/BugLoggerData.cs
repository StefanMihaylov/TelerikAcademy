namespace BugLogger.Data
{
    using BugLogger.Data.Repositories;
    using BugLogger.Model;

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class BugLoggerData : IBugLoggerData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public BugLoggerData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Bug> Bugs
        {
            get
            {
                return this.GetRepository<Bug>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
