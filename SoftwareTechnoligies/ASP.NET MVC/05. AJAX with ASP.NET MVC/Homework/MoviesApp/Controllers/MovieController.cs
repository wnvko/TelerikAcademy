namespace Movies.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models;
    using MoviesApp.Controllers;
    using MoviesApp.Models.Movie;

    public class MovieController : BaseController
    {
        // for some reason Ninject did not want to work for my homework :(
        //[Inject]
        //public IMovieServices Movies { get; set; }

        public ActionResult ViewAll()
        {
            var result = this.movies
                .GetAll()
                .ProjectTo<MovieViewModel>();

            return View(result);
        }

        public ActionResult Details(int id)
        {
            var movie = this.movies.GetById(id);
            AutoMapper.Mapper.CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.LeadingMaleRole,
                           opts => opts.MapFrom(act => act.LeadingMaleRole.Name))
                .ForMember(dest => dest.LeadingFemaleRole,
                           opts => opts.MapFrom(act => act.LeadingFemaleRole.Name));
            var result = AutoMapper.Mapper.Map<MovieViewModel>(movie);
            return this.View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddMovieModel();
            model.Movie = new Movie();
            model.Actors = this.actors.GetAll();
            model.Actresses = this.actresses.GetAll();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("~/Movie/Add");
            }

            this.movies.Add(movie);

            return Redirect("~/Home");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var movie = this.movies.GetById(id);
            var result = new AddMovieModel();
            result.Movie = movie;
            result.Actors = this.actors.GetAll();
            result.Actresses = this.actresses.GetAll();
            return this.View(result);
        }

        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("~/Movie/Update/" + movie.Id);
            }

            this.movies.Update(movie);

            return Redirect("~/Home");
        }

        public ActionResult Delete(int id)
        {
            var movie = this.movies.GetById(id);
            this.movies.Delete(movie);

            return Redirect("~/Movie/ViewAll");
        }
    }
}