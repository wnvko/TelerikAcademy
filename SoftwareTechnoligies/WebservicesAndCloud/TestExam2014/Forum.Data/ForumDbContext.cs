namespace Forum.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class ForumDbContext : DbContext, IForumDbContext
    {
        public ForumDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumDbContext, Configuration>());
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Thread> Threads { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Vote> Votes { get; set; }
    }
}
