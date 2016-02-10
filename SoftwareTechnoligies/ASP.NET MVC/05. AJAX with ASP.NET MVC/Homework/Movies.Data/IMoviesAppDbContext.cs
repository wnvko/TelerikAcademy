namespace Movies.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IMoviesAppDbContext
    {
        int SaveChanges();

        IDbSet<Movie> Movies { get; set; }

        IDbSet<LeadingMaleRole> LeadingMaleRoles { get; set; }

        IDbSet<LeadingFemaleRole> LeadingFemaleRoles { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();
    }
}
