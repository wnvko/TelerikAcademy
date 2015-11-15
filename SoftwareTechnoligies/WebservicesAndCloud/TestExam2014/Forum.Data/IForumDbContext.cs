namespace Forum.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Forum.Models;

    public interface IForumDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Thread> Threads { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Vote> Votes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
