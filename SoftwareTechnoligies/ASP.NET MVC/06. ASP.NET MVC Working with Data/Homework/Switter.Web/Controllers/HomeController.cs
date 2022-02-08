namespace Switter.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.SwittModels;
    using Ninject;
    using Services.Contracts;

    public class HomeController : Controller
    {
        [Inject]
        public ISwittsServices Switts { get; set; }

        public ActionResult Index()
        {
            var a = this.Switts.GetLastTenSwitts();
            var lastTenSwitts = this.Switts
                                    .GetLastTenSwitts()
                                    .ProjectTo<SwittPublicModel>()
                                    .ToList();
            return View(lastTenSwitts);
        }
    }
}