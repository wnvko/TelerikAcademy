namespace BugLogger.RestApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Policy;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using DataLayer;
    using Repositories;

    [EnableCors("*", "*", "*")]
    public class BugsController : ApiController
    {
        private IRepository<Bug> repo;

        public BugsController()
            : this(new DbBugsRepository(new BugLoggerContext()))
        {
        }

        public BugsController(IRepository<Bug> repository)
        {
            this.repo = repository;
        }
        public IQueryable<Bug> GetAll()
        {
            return this.repo.All();
        }

        public HttpResponseMessage PostBug(Bug bug)
        {
            // TODO: validate bug.Text
            bug.LoggedDate = DateTime.Now;
            bug.Status = Status.Pending;
            this.repo.Add(bug);
            this.repo.Save();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, bug);
            var location = new Uri(Url.Link("DefaultApi", new { id = bug.Id }));
            response.Headers.Location = location;
            return response;
        }
    }
}
