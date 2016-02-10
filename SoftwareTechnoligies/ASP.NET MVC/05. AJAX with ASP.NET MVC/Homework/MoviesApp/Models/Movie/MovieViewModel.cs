namespace MoviesApp.Models.Movie
{
    using AutoMapper;
    using Movies.Common;
    using Movies.Models;

    public class MovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        public int LeadingMaleRoleId { get; set; }

        public string LeadingMaleRole { get; set; }

        public int LeadingFemaleRoleId { get; set; }

        public string LeadingFemaleRole { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Movie, MovieViewModel>(null)
                .ForMember(m => m.LeadingMaleRole, opts => opts.MapFrom(act => act.LeadingMaleRole.Name));

            configuration.CreateMap<Movie, MovieViewModel>(null)
                .ForMember(f => f.LeadingFemaleRole, opts => opts.MapFrom(act => act.LeadingFemaleRole.Name));
        }
    }
}