using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugLogger.RestApi.Tests.Fakes
{
    public class FakeRepository<T> : IRepository<T> where T : class
    {
        public FakeRepository()
        {
            this.IsSaveCalled = false;
        }

        public IList<T> Entities { get; set; }

        public bool IsSaveCalled { get; private set; }

        public T Add(T entity)
        {
            this.Entities.Add(entity);
            return entity;
        }

        public IQueryable<T> All()
        {
            return this.Entities.AsQueryable();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            this.IsSaveCalled = true;
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
