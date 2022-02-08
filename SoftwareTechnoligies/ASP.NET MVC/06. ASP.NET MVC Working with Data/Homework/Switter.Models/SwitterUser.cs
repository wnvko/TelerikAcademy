namespace Switter.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class SwitterUser : IdentityUser
    {
        private ICollection<Switt> switts;

        public SwitterUser()
            : base()
        {
            this.switts = new HashSet<Switt>();
        }

        public virtual ICollection<Switt> Switts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SwitterUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
