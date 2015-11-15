namespace SourceControlSystem.Services.Data.Contracts
{
    using System.Linq;
    using Common.Constants;
    using Models;

    public interface IProjectService
    {
        IQueryable<SoftwareProject> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);

        int Add(string name, string description, string creator, bool isPrivate = false);
    }
}
