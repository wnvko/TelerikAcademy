namespace MusicLibrary.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;

    using MusicLibrary.Models;

    using MusicLibrary.Data.Repositories;

    public class MusicLibraryData : IMusicLibraryData
    {
        private IMusicLibraryDbContext context;
        private IDictionary<Type, object> repositories;

        public MusicLibraryData()
            : this(new MusicLibraryDbContext())
        {
        }

        public MusicLibraryData(IMusicLibraryDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Album> Albums
        {
            get { return this.GetRepository<Album>(); }
        }

        public Repositories.IGenericRepository<Artist> Artists
        {
            get { return this.GetRepository<Artist>(); }
        }

        public Repositories.IGenericRepository<Country> Countries
        {
            get { return this.GetRepository<Country>(); }
        }

        public Repositories.IGenericRepository<Genre> Genres
        {
            get { return this.GetRepository<Genre>(); }
        }

        public Repositories.IGenericRepository<Producer> Producers
        {
            get { return this.GetRepository<Producer>(); }
        }

        public Repositories.IGenericRepository<Song> Songs
        {
            get { return this.GetRepository<Song>(); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
