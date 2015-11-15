namespace SourceControlSystem.Services.Data
{
    using System.Linq;
    using Models;
    using Contracts;
    using SourceControlSystem.Data;
    using Common.Constants;
    using System;

    public class ProjectService : IProjectService
    {
        private readonly IRepository<SoftwareProject> projects;
        private readonly IRepository<User> users;

        public ProjectService(
            IRepository<SoftwareProject> projectsRepo,
            IRepository<User> usersRepo)
        {
            this.projects = projectsRepo;
            this.users = usersRepo;
        }

        public int Add(string name, string description, string creator, bool isPrivate = false)
        {
            var curentUser = this.users
              .All()
              .FirstOrDefault(u => u.UserName == creator);

            var newProject = new SoftwareProject
            {
                Name = name,
                Description = description,
                Private = isPrivate,
                CreatedOn = DateTime.Now,
            };

            newProject.Users.Add(curentUser);

            this.projects.Add(newProject);
            this.projects.SaveChanges();

            return newProject.Id;
        }

        public IQueryable<SoftwareProject> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.projects
                       .All()
                       .OrderByDescending(pr => pr.CreatedOn)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize);
        }


    }
}
