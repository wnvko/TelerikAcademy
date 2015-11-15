namespace SourceControlSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Common.Constants;
    using Models.Projects;
    using Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using SourceControlSystem.Models;
    using Infrastructure;

    public class ProjectsController : ApiController
    {
        private readonly IProjectService projects;

        public ProjectsController(IProjectService projectService)
        {
            this.projects = projectService;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            //var projectService = ObjectFactory.Get<IProjectService>();

            var result = this.projects
                .All(page: 1)
                .ProjectTo<SoftwareProjectsDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Project name cannot be null or empty.");
            }

            var result = this.projects
                .All()
                .Where(pr =>
                    (pr.Name == id) && (!pr.Private || (pr.Private && pr.Users.Any(u => u.UserName == this.User.Identity.Name))))
                .ProjectTo<SoftwareProjectsDetailsResponseModel>()
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(SaveProjectRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var dbModel = Mapper.Map<SoftwareProject>(model);

            var createdProjectId = this.projects.Add(
                model.Name,
                model.Description,
                this.User.Identity.Name,
                model.Private);

            return this.Ok(createdProjectId);
        }

        [Route("api/projects/all")]
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.projects
                .All(page, pageSize)
                .ProjectTo<SoftwareProjectsDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }
    }
}
