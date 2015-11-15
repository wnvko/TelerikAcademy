namespace SourceControlSystem.Api.Models.Projects
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Mappings;
    using SourceControlSystem.Models;

    public class SoftwareProjectsDetailsResponseModel : IMapFrom<SoftwareProject>, IHaveCusomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TotalUsers { get; set; }

        public void Createmapings(IConfiguration config)
        {
            config
                .CreateMap<SoftwareProject, SoftwareProjectsDetailsResponseModel>()
                .ForMember(s => s.TotalUsers, opts => opts.MapFrom(s => s.Users.Count()));
        }
    }
}