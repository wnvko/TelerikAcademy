namespace Movies.Services
{
    using System.Linq;
    using Movies.Data.Repositories;
    using Movies.Models;
    using Movies.Services.Contracts;

    public class MovieServices : IMovieServices
    {
        private IRepository<Movie> movies;

        public MovieServices(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public void Add(Movie movie)
        {
            this.movies.Add(movie);
            this.movies.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            this.movies.Delete(movie);
            this.movies.SaveChanges();
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All();
        }

        public Movie GetById(int id)
        {
            return this.movies.GetById(id);
        }

        public void Update(Movie movie)
        {
            this.movies.Update(movie);
            this.movies.SaveChanges();
        }
    }
}
