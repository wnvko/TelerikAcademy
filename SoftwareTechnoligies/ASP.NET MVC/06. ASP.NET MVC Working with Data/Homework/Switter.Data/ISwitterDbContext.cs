namespace Switter.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface ISwitterDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<SwitterUser> Users { get; set; }

        IDbSet<Switt> Switts { get; set; }

        IDbSet<Tag> Tags { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
