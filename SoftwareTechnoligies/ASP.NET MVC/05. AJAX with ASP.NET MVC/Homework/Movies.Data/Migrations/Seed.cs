namespace Movies.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    public class Seed
    {
        private Random random;

        public Seed()
        {
            this.random = new Random();
        }

        public List<LeadingMaleRole> GetActors(int actorsCount)
        {
            var actors = new List<LeadingMaleRole>();
            for (int index = 0; index < actorsCount; index++)
            {
                var actor = new LeadingMaleRole();
                actor.Name = "Male Actror " + index;
                actor.Studio = "Studio " + this.random.Next(1, 10);
                actor.Address = "Address";
                actor.Age = this.random.Next(10, 80);
                actors.Add(actor);
            }

            return actors;
        }

        public List<LeadingFemaleRole> GetActresses(int actressesCount)
        {
            var actresses = new List<LeadingFemaleRole>();
            for (int index = 0; index < actressesCount; index++)
            {
                var actress = new LeadingFemaleRole();
                actress.Name = "Female Actress " + index;
                actress.Studio = "Studio " + this.random.Next(1, 10);
                actress.Address = "Address";
                actress.Age = this.random.Next(10, 80);
                actresses.Add(actress);
            }

            return actresses;
        }

        public List<Movie> GetMovies(int moviesCount, List<LeadingMaleRole> actors, List<LeadingFemaleRole> actresses)
        {
            var movies = new List<Movie>();
            for (int index = 0; index < moviesCount; index++)
            {
                var movie = new Movie();
                movie.Title = "Best Movie" + index;
                movie.Director = "Director" + this.random.Next(1, 10);
                movie.Year = this.random.Next(1920, 2016);

                var actress = actresses[this.random.Next(0, actresses.Count)];
                movie.LeadingFemaleRole = actress;
                movie.LeadingFemaleRoleId = actress.Id;

                var actor = actors[this.random.Next(0, actors.Count)];
                movie.LeadingMaleRole = actor;
                movie.LeadingMaleRoleId = actor.Id;

                movies.Add(movie);
            }

            return movies;
        }
    }
}
