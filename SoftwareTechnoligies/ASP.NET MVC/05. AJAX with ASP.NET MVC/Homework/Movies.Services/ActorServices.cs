namespace Movies.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Movies.Data.Repositories;
    using Movies.Models;

    public class ActorServices : IActorServices
    {
        private IRepository<LeadingMaleRole> actors;

        public ActorServices(IRepository<LeadingMaleRole> actors)
        {
            this.actors = actors;
        }

        public void Add(LeadingMaleRole actor)
        {
            this.actors.Add(actor);
            this.actors.SaveChanges();
        }

        public void Delete(LeadingMaleRole actor)
        {
            this.actors.Delete(actor);
            this.actors.SaveChanges();
        }

        public IQueryable<LeadingMaleRole> GetAll()
        {
            return actors.All();
        }

        public LeadingMaleRole GetById(int id)
        {
            return this.actors.GetById(id);
        }

        public void Update(LeadingMaleRole actor)
        {
            this.actors.Update(actor);
            this.actors.SaveChanges();
        }
    }
}
