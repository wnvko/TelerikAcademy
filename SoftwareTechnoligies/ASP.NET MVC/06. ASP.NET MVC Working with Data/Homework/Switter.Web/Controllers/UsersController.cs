namespace Switter.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.UsersModels;
    using Ninject;
    using Services.Contracts;

    public class UsersController : Controller
    {
        [Inject]
        public IUsersServices Users{ get; set; }


        public ActionResult Index(string id)
        {
            var user = this.Users
                        .GetById(id)
                        .ProjectTo<SwittUserPublicModel>()
                        .FirstOrDefault();
            return View(user);
        }
    }
}