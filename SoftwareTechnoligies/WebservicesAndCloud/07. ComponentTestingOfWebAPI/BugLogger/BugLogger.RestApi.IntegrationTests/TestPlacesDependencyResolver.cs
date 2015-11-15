using System;
using System.Collections.Generic;
using BugLogger.RestApi.Controllers;
using DataLayer;
using Repositories;

namespace BugLogger.RestApi.IntegrationTests
{
    public class TestPlacesDependencyResolver<T> where T :class
    {
        private IRepository<T> repository;

        public IRepository<T> Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(BugsController))
            {
                return new BugsController(this.repository as IRepository<Bug>);
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