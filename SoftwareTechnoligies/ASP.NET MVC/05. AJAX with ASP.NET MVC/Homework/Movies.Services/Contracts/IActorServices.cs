namespace Movies.Services.Contracts
{
    using System.Linq;
    using Models;
    public interface IActorServices
    {
        IQueryable<LeadingMaleRole> GetAll();

        LeadingMaleRole GetById(int id);

        void Add(LeadingMaleRole actor);

        void Update(LeadingMaleRole actor);

        void Delete(LeadingMaleRole actor);
    }
}
