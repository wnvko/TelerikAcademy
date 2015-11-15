using System.Linq;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using Telerik.JustMock;

namespace BugLogger.RestApi.IntegrationTests
{
    [TestClass]
    public class BugsControllerIntegrationTests
    {
        [TestMethod]
        public void GetBugs_ShouldReturnStatusOkAndNonEmptyContent()
        {
            // Arrange
            var repository = Mock.Create<IRepository<Bug>>();
            Bug[] bugs =
            {
                new Bug
                {
                    Text = "Test Bug",
                }
            };
            Mock.Arrange(() => repository.All())
                .Returns(() => bugs.AsQueryable());

            // Act

        }
    }
}
