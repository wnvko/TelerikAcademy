namespace Switter.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<SwitterDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "Switter.Data.SwitterDbContext";
        }

        protected override void Seed(Switter.Data.SwitterDbContext context)
        {
            if (context.Switts.Any())
            {
                return;
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole(AdminRoleConstants.AdminRole));
            }

            var admin = new SwitterUser()
            {
                Email = AdminRoleConstants.AdminEmail,
                UserName = AdminRoleConstants.AdminEmail,
            };

            var userManager = new UserManager<SwitterUser>(new UserStore<SwitterUser>(context));
            var adminResult = userManager.Create(admin, AdminRoleConstants.AdminPassword);
            if (adminResult.Succeeded)
            {
                userManager.AddToRole(admin.Id, AdminRoleConstants.AdminRole);
            }

            var seed = new SeedData(
                                context,
                                SeedDataConstants.UsersCount,
                                SeedDataConstants.SwittsCount,
                                SeedDataConstants.MinTagsPerSwitt,
                                SeedDataConstants.MaxTagsPerSwitt);
        }
    }
}
