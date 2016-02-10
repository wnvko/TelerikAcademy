namespace MoviesApp.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Actors;
    using Movies.Models;

    public class ActorController : BaseController
    {
        public ActionResult ViewAll()
        {
            var result = this.actors
                .GetAll()
                .ProjectTo<ActorViewModel>();

            return View(result);
        }

        public ActionResult Details(int id)
        {
            var actor = this.actors.GetById(id);
            AutoMapper.Mapper.CreateMap<LeadingMaleRole, ActorViewModel>();
            var result = AutoMapper.Mapper.Map<ActorViewModel>(actor);
            return this.View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new ActorViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(LeadingMaleRole actor)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("~/Actor/Add");
            }

            this.actors.Add(actor);

            return Redirect("~/Home");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var actor = this.actors.GetById(id);
            AutoMapper.Mapper.CreateMap<LeadingMaleRole, ActorViewModel>();
            var result = AutoMapper.Mapper.Map<ActorViewModel>(actor);
            return this.View(result);
        }

        [HttpPost]
        public ActionResult Update(LeadingMaleRole actor)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("~/Actor/Update/" + actor.Id);
            }

            this.actors.Update(actor);

            return Redirect("~/Home");
        }

        public ActionResult Delete(int id)
        {
            var actor = this.actors.GetById(id);
            this.actors.Delete(actor);
            return Redirect("~/Actor/ViewAll");
        }
    }
}