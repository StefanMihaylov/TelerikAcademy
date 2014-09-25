using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugLogger.Data.Repositories;
using BugLogger.Model;
using BugLogger.Data;

namespace BugLogger.WebApi.Tests.FakeRepos
{
    class FakeRepository<T> : IRepository<T> where T : class
    {
        private IList<T> entitties { get; set; }

        public FakeRepository()
        {
            this.entitties = new List<T>();
        }

        public IQueryable<T> All()
        {
            return this.entitties.AsQueryable();
        }

        public T Find(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            this.entitties.Add(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(object id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
