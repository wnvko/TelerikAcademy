using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceControlSystem.Api.Controllers;
using SourceControlSystem.Api.Models.Projects;

namespace SourceControlSystem.Api.Tests.ControllerTests
{
    [TestClass]
    class ProjectsControllerTests
    {
        [TestMethod]
        public void PostShoulValidateModuleState()
        {
            var controller = new ProjectsController(TestObjectsFactory.GetProjectsService());
            controller.Configuration = new HttpConfiguration();
            var model = TestObjectsFactory.GetInvalidModel();

            controller.Validate(model);
            var result = controller.Post(model);

            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void PostShouldReturnBadRequestWithInvalidModel()
        {
            var controller = new ProjectsController(TestObjectsFactory.GetProjectsService());
            controller.Configuration = new HttpConfiguration();
            var model = TestObjectsFactory.GetInvalidModel();

            controller.Validate(model);
            var result = controller.Post(model);

            Assert.AreEqual(typeof(InvalidModelStateResult), result.GetType());
        }
    }
}
