namespace MoviesApp.Models.Movie
{
    using System.Linq;
    using Movies.Models;

    public class AddMovieModel
    {
        public Movie Movie { get; set; }

        public IQueryable<LeadingFemaleRole> Actresses { get; set; }

        public IQueryable<LeadingMaleRole> Actors { get; set; }
    }
}