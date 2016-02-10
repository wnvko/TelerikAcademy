namespace Movies.Services.Contracts
{
    using System.Linq;
    using Movies.Models;

    public interface IActressServices
    {
        IQueryable<LeadingFemaleRole> GetAll();

        LeadingFemaleRole GetById(int id);

        void Add(LeadingFemaleRole actress);

        void Update(LeadingFemaleRole actress);

        void Delete(LeadingFemaleRole actress);
    }
}