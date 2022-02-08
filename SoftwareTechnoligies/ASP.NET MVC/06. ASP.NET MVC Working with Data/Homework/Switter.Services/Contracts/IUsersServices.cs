namespace Switter.Services.Contracts
{
    using System.Linq;
    using Switter.Models;

    public interface IUsersServices
    {
        IQueryable<SwitterUser> GetById(string id);
    }
}
