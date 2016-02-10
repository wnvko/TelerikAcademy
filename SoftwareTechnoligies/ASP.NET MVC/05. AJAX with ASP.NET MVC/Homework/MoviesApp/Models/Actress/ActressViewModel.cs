namespace MoviesApp.Models.Actress
{
    using Movies.Common;
    using Movies.Models;
    public class ActressViewModel : IMapFrom<LeadingFemaleRole>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Studio { get; set; }

        public string Address { get; set; }
    }
}