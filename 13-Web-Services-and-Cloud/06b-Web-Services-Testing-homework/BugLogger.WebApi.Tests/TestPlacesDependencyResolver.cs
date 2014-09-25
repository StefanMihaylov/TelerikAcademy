using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

using BugLogger.Data.Repositories;
using BugLogger.Model;
using BugLogger.WebApi.Controllers;
using BugLogger.Data;

namespace BugLogger.WebApi.Tests
{
    public class TestPlacesDependencyResolver : IDependencyResolver
    {
        private IBugLoggerData repository;

        public IBugLoggerData Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(BugsController))
            {
                return new BugsController(this.Repository as IBugLoggerData);
            }
            else if (serviceType == typeof(BugsController))
            {
                // other controller
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}
