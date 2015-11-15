namespace MusicLibrary.Data
{
    using System.Data.Entity;

    using MusicLibrary.Models;

    using MusicLibrary.Data.Migrations;
    
    public class MusicLibraryDbContext : DbContext, IMusicLibraryDbContext
    {
        public MusicLibraryDbContext()
            : base("MusicLibraryConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicLibraryDbContext, Configuration>());
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Producer> Producers { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
