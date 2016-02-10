namespace MoviesApp.Controllers
{
    using System.Web.Mvc;
    using Movies.Data;
    using Movies.Data.Repositories;
    using Movies.Models;
    using Movies.Services;
    using Movies.Services.Contracts;

   public abstract class BaseController : Controller
    {
        protected IMovieServices movies = new MovieServices(new GenericRepository<Movie>(new MoviesAppDbContext()));
        protected IActorServices actors = new ActorServices(new GenericRepository<LeadingMaleRole>(new MoviesAppDbContext()));
        protected IActressServices actresses = new ActressServices(new GenericRepository<LeadingFemaleRole>(new MoviesAppDbContext()));
    }
}