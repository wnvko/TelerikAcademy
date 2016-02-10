namespace Movies.Data
{
    using System.Data.Entity;
    using Movies.Models;

    public class MoviesAppDbContext : DbContext, IMoviesAppDbContext
    {
        public MoviesAppDbContext() : base("DefaultConnection")
        {
        }

        public IDbSet<LeadingFemaleRole> LeadingFemaleRoles { get; set; }

        public IDbSet<LeadingMaleRole> LeadingMaleRoles { get; set; }

        public IDbSet<Movie> Movies { get; set; }
    }
}
