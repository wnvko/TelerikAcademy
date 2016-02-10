namespace MoviesApp.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Actress;
    using Movies.Models;

    public class ActressController : BaseController
    {
        public ActionResult ViewAll()
        {
            var result = this.actresses
                .GetAll()
                .ProjectTo<ActressViewModel>();

            return View(result);
        }

        public ActionResult Details(int id)
        {
            var actress = this.actresses.GetById(id);
            AutoMapper.Mapper.CreateMap<LeadingFemaleRole, ActressViewModel>();
            var result = AutoMapper.Mapper.Map<ActressViewModel>(actress);
            return this.View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new ActressViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(LeadingFemaleRole actress)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("~/Actress/Add");
            }

            this.actresses.Add(actress);

            return Redirect("~/Home");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var actress = this.actresses.GetById(id);
            AutoMapper.Mapper.CreateMap<LeadingFemaleRole, ActressViewModel>();
            var result = AutoMapper.Mapper.Map<ActressViewModel>(actress);
            return this.View(result);
        }

        [HttpPost]
        public ActionResult Update(LeadingFemaleRole actress)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("~/Actress/Update/" + actress.Id);
            }

            this.actresses.Update(actress);

            return Redirect("~/Home");
        }

        public ActionResult Delete(int id)
        {
            var actress = this.actresses.GetById(id);
            this.actresses.Delete(actress);
            return Redirect("~/Actress/ViewAll");
        }
    }
}