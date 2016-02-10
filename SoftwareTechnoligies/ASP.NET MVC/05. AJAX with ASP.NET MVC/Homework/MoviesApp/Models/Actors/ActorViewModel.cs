namespace MoviesApp.Models.Actors
{
    using Movies.Common;
    using Movies.Models;

    public class ActorViewModel : IMapFrom<LeadingMaleRole>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Studio { get; set; }

        public string Address { get; set; }
    }
}