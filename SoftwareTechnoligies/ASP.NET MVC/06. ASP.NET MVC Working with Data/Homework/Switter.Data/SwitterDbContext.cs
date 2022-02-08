namespace Switter.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Switter.Models;

    public class SwitterDbContext : IdentityDbContext<SwitterUser>, ISwitterDbContext
    {
        public SwitterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Switt> Switts { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public static SwitterDbContext Create()
        {
            return new SwitterDbContext();
        }
    }
}
