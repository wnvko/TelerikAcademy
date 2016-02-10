namespace Movies.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IMovieServices
    {
        IQueryable<Movie> GetAll();

        void Add(Movie movie);

        Movie GetById(int id);

        void Update(Movie movie);

        void Delete(Movie movie);
    }
}
