namespace Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using DataLayer;

    public class DbBugsRepository : IBugRepository
    {
        private DbContext dbContext;

        public DbBugsRepository(DbContext context)
        {
            this.dbContext = context;
        }

        public Bug Add(Bug entity)
        {
            // TODO: Validation
            this.dbContext.Set<Bug>().Add(entity);
            return entity;
        }

        public IQueryable<Bug> All()
        {
            return this.dbContext.Set<Bug>();
        }

        public void Delete(Bug entity)
        {
            // TODO: Implement this
        }

        public Bug Find(int id)
        {
            return this.dbContext.Set<Bug>().Find(id);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public void Update(Bug entity)
        {
            // TODO: Implement this
        }
    }
}
