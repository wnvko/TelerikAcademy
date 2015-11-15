namespace SourceControlSystem.Api.Tests
{
    using Moq;
    using Services.Data.Contracts;
    using Models.Projects;

    static class TestObjectsFactory
    {
        public static IProjectService GetProjectsService()
        {
            var projectService = new Mock<IProjectService>();
            projectService
                .Setup(pr => pr.Add(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Returns(1);

            return projectService.Object;
        }

        public static SaveProjectRequestModel GetInvalidModel()
        {
            return new SaveProjectRequestModel { Description = "TestDescription" };
        }
    }
}
