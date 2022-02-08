namespace Switter.Web.Models.UsersModels
{
    using System.Collections.Generic;
    using Common;
    using Switter.Models;

    public class SwittUserPublicModel : IMapFrom<SwitterUser>
    {
        public string Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string UserName { get; set; }

        public ICollection<Switt> Switts { get; set; }
    }
}