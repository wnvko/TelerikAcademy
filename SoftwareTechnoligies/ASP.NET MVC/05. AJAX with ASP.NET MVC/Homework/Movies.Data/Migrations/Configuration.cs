namespace Movies.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesAppDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesAppDbContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }

            var seed = new Seed();
            var actors = seed.GetActors(20);
            actors.ForEach(a => context.LeadingMaleRoles.Add(a));
            context.SaveChanges();

            var actresses = seed.GetActresses(20);
            actresses.ForEach(a => context.LeadingFemaleRoles.Add(a));
            context.SaveChanges();

            var movies = seed.GetMovies(20, actors, actresses);
            movies.ForEach(m => context.Movies.Add(m));
            context.SaveChanges();
        }
    }
}
