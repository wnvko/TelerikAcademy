namespace Switter.Services
{
    using System.Linq;
    using Data.Repositories;
    using Models;
    using Switter.Services.Contracts;

    public class SwittsServices : ISwittsServices
    {
        private IRepository<Switt> switts;
        public SwittsServices(IRepository<Switt> switts)
        {
            this.switts = switts;
        }

        public IQueryable<Switt> GetAll()
        {
            return this.switts.All();
        }

        public IQueryable<Switt> GetLastTenSwitts()
        {
            return this.GetAll()
                .OrderByDescending(s => s.CreatedOn)
                .Take(10);
        }
    }
}
