using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BugLogger.RestApi.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;
    using Controllers;
    using DataLayer;
    using Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repositories;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnAllBugs()
        {
            // Arrange
            var fakeRepo = new FakeRepository<Bug>();
            List<Bug> bugs = this.GeneretaNewBugs();
            fakeRepo.Entities = bugs;
            var controller = new BugsController(fakeRepo);

            // Act
            var result = controller.GetAll().ToList();

            // Assert
            CollectionAssert.AreEquivalent(bugs, result);
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            // Arrange
            var fakeRepo = new FakeRepository<Bug>();
            fakeRepo.Entities = new List<Bug>();
            var bug = new Bug()
            {
                Text = "New test bug",
            };

            var controller = new BugsController(fakeRepo);
            this.SetUpController(controller);
            // Act
            controller.PostBug(bug);

            // Assert
            var bugInDb = fakeRepo.Entities.First();
            Assert.AreEqual(fakeRepo.Entities.Count, 1);
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LoggedDate);
            Assert.IsNotNull(bugInDb.Status);
            Assert.IsTrue(fakeRepo.IsSaveCalled);
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnAllBugs_WithMocks()
        {
            // Arrange
            IRepository<Bug> fakeRepo = Mock.Create<IRepository<Bug>>();

            List<Bug> bugs = this.GeneretaNewBugs();
            Mock.Arrange(() => fakeRepo.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(fakeRepo);

            // Act
            var result = controller.GetAll().ToList();

            // Assert
            CollectionAssert.AreEquivalent(bugs, result);
        }

        private List<Bug> GeneretaNewBugs()
        {
            return new List<Bug>()
            {
                new Bug()
                {
                    Text = "Test new bug 1",
                },
                new Bug()
                {
                    Text = "Test new bug 2",
                },
                new Bug()
                {
                    Text = "Test new bug 2",
                },
                new Bug()
                {
                    Text = "Test new bug 4",
                },
            };
        }


        private void SetUpController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var reguest = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/bugs");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "bugs");
            controller.ControllerContext = new HttpControllerContext(config, routeData, reguest);
            controller.Request = reguest;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
            controller.Url = new UrlHelper(reguest);

        }
    }
}
