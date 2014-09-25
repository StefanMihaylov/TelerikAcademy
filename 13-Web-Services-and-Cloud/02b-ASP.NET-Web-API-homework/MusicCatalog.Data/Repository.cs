namespace MusicCatalog.Data
{
    using MusicCatalog.Data.Contracts;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T> where T : class
    {
        private IMusicCatalogDbContext context;
        private IDbSet<T> set;

        public Repository()
            : this(new MusicCatalogDbContext())
        {
        }

        public Repository(IMusicCatalogDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}

