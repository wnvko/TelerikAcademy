namespace Switter.Services.Contracts
{
    using System.Linq;
    using Switter.Models;

    public interface ISwittsServices
    {
        IQueryable<Switt> GetAll();

        IQueryable<Switt> GetLastTenSwitts();
    }
}
