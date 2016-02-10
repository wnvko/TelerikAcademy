namespace Movies.Services
{
    using System.Linq;
    using Movies.Data.Repositories;
    using Movies.Models;
    using Movies.Services.Contracts;

    public class ActressServices : IActressServices
    {
        private IRepository<LeadingFemaleRole> actresses;

        public ActressServices(IRepository<LeadingFemaleRole> actresses)
        {
            this.actresses = actresses;
        }

        public void Add(LeadingFemaleRole actress)
        {
            this.actresses.Add(actress);
            this.actresses.SaveChanges();
        }

        IQueryable<LeadingFemaleRole> IActressServices.GetAll()
        {
            return actresses.All();
        }

        public LeadingFemaleRole GetById(int id)
        {
            return this.actresses.GetById(id);
        }

        public void Update(LeadingFemaleRole actress)
        {
            this.actresses.Update(actress);
            this.actresses.SaveChanges();
        }

        public void Delete(LeadingFemaleRole actress)
        {
            this.actresses.Delete(actress);
            this.actresses.SaveChanges();
        }
    }
}
