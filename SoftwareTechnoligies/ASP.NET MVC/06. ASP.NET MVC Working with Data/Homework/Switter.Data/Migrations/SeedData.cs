namespace Switter.Data.Migrations
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Switter.Common;
    using Switter.Models;

    public class SeedData
    {
        private SwitterDbContext context;
        private int maxTagsPerSwitt;
        private int minTagsPerSwitt;
        private int swittsCount;
        private int usersCount;
        private Random random;

        public SeedData(SwitterDbContext context, int usersCount, int swittsCount, int minTagsPerSwitt, int maxTagsPerSwitt)
        {
            this.context = context;
            this.usersCount = usersCount;
            this.swittsCount = swittsCount;
            this.minTagsPerSwitt = minTagsPerSwitt;
            this.maxTagsPerSwitt = maxTagsPerSwitt;
            this.random = new Random();
            this.Seed();
        }

        private void Seed()
        {
            this.SeedUsers(this.context, this.usersCount);
            this.SeedSwitts(this.context, this.swittsCount, this.minTagsPerSwitt, this.maxTagsPerSwitt);

        }

        private void SeedUsers(SwitterDbContext context, int usersCount)
        {
            var userManager = new UserManager<SwitterUser>(new UserStore<SwitterUser>(this.context));

            for (int index = 0; index < usersCount; index++)
            {
                var user = new SwitterUser()
                {
                    Email = string.Format(UsersConstants.UserEmail, index),
                    UserName = string.Format(UsersConstants.UserEmail, index),
                };

                userManager.Create(user, string.Format(UsersConstants.UserPassword, index));
            }
        }

        private void SeedSwitts(SwitterDbContext context, int swittsCount, int minTagsPerSwitt, int maxTagsPerSwitt)
        {
            var users = context.Users.ToList();
            var usersCount = users.Count;

            for (int index = 0; index < swittsCount; index++)
            {
                var switt = new Switt();

                switt.SwitterUserId = users[this.random.Next(usersCount)].Id;
                switt.Content = this.GetRandomText(this.random.Next(50, 200));
                switt.CreatedOn = DateTime.Now.AddDays(this.random.Next(100) * (-1));

                var tagsCount = this.random.Next(minTagsPerSwitt, maxTagsPerSwitt);
                for (int i = 0; i < tagsCount; i++)
                {
                    var tag = new Tag();
                    tag.Name = this.GetRandomText(this.random.Next(3, 10));
                    switt.Tags.Add(tag);
                }

                this.context.Switts.Add(switt);

                if (index % 10 == 0)
                {
                    this.context.SaveChanges();
                }
            }

            this.context.SaveChanges();
        }

        private string GetRandomText(int charsCount)
        {
            // thanks to StackOverflow http://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings-in-c
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";
            return new string(
                Enumerable.Repeat(chars, charsCount)
                           .Select(s => s[this.random.Next(s.Length)])
                           .ToArray());
        }
    }
}
