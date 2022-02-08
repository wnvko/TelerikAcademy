namespace Switter.Services
{
    using System;
    using System.Linq;
    using Switter.Data.Repositories;
    using Switter.Models;
    using Switter.Services.Contracts;

    public class UsersServices : IUsersServices
    {
        private IRepository<SwitterUser> users;

        public UsersServices(IRepository<SwitterUser> users)
        {
            this.users = users;
        }

        IQueryable<SwitterUser> IUsersServices.GetById(string id)
        {
            return this.users.All().Where(u => u.Id == id);
        }
    }
}
