namespace MusicLibrary.Data.UnitOfWork
{
    using MusicLibrary.Models;

    using MusicLibrary.Data.Repositories;

    public interface IMusicLibraryData
    {
        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Country> Countries { get; }

        IGenericRepository<Genre> Genres { get; }

        IGenericRepository<Producer> Producers { get; }

        IGenericRepository<Song> Songs { get; }

        void SaveChanges();
    }
}
