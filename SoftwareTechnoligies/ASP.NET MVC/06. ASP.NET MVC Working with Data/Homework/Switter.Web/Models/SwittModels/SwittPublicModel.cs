namespace Switter.Web.Models.SwittModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Common;
    using Switter.Models;

    public class SwittPublicModel : IMapFrom<Switt>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string SwitterUserId { get; set; }

        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<string> Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Switt, SwittPublicModel>(null)
                .ForMember(spm => spm.UserName, opts => opts.MapFrom(u => u.SwitterUser.UserName));

            configuration.CreateMap<Switt, SwittPublicModel>(null)
                .ForMember(spm => spm.Tags, opts => opts.MapFrom(u => u.Tags.Select(t => t.Name).ToList()));
        }
    }
}
