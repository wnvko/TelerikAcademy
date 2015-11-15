namespace MusicLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MusicLibrary.Models;

    public sealed class Configuration : DbMigrationsConfiguration<MusicLibrary.Data.MusicLibraryDbContext>
    {
        private Random random;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MusicLibrary.Data.MusicLibraryDbContext";

            this.random = new Random();
        }

        protected override void Seed(MusicLibrary.Data.MusicLibraryDbContext context)
        {
            this.SeedGenres(context);
            this.SeedProducers(context);
            this.SeedCountries(context);
            this.SeedArtists(context);
            this.SeedAlbums(context);
        }

        private void SeedGenres(MusicLibraryDbContext context)
        {
            if (!context.Genres.Any())
            {
                string[] genreNames = new string[] { "Metal", "Rock", "Pop", "Jazz", "Clasic" };
                foreach (string name in genreNames)
                {
                    Genre genre = new Genre();
                    genre.Name = name;
                    context.Genres.Add(genre);
                }

                context.SaveChanges();
            }
        }

        private void SeedProducers(MusicLibraryDbContext context)
        {
            if (!context.Producers.Any())
            {
                string[] producerNames = new string[] { "Joe Meek", "George Martin", "Quincy Jones", "Nile Rodgers" };
                foreach (string name in producerNames)
                {
                    Producer producer = new Producer();
                    producer.Name = name;
                    context.Producers.Add(producer);
                }

                context.SaveChanges();
            }
        }

        private void SeedCountries(MusicLibraryDbContext context)
        {
            if (!context.Countries.Any())
            {
                string[] contryNames = new string[] { "United States of America", "United Kingdom", "France", "Russia" };
                foreach (string name in contryNames)
                {
                    Country country = new Country();
                    country.Name = name;
                    context.Countries.Add(country);
                }

                context.SaveChanges();
            }
        }

        private void SeedArtists(MusicLibraryDbContext context)
        {
            if (!context.Artists.Any())
            {
                Artist metallica = new Artist();
                metallica.Name = "Metallica";
                metallica.DateOfBirth = new DateTime(1980, 1, 1);
                metallica.CountryId = this.GetRandomCountry(context);
                context.Artists.Add(metallica);

                Artist ironMaiden = new Artist();
                ironMaiden.Name = "Iron Maiden";
                ironMaiden.DateOfBirth = new DateTime(1978, 1, 1);
                ironMaiden.CountryId = this.GetRandomCountry(context);
                context.Artists.Add(ironMaiden);

                Artist deepPurple = new Artist();
                deepPurple.Name = "Deep Purple";
                deepPurple.DateOfBirth = new DateTime(1968, 1, 1);
                deepPurple.CountryId = this.GetRandomCountry(context);
                context.Artists.Add(deepPurple);

                context.SaveChanges();
            }
        }

        private void SeedAlbums(MusicLibraryDbContext context)
        {
            if (!context.Albums.Any())
            {
                Album album1 = new Album();
                album1.Title = "Master of Puppets";
                album1.Year = 1986;
                album1.ProducerId = this.GetRandomProducer(context);
                album1.Songs.Add(this.GetSong(context, "Master of Puppets", album1.Year, "Metallica"));
                album1.Songs.Add(this.GetSong(context, "Welcome Home (Sanitarium)", album1.Year, "Metallica"));
                context.Albums.Add(album1);

                Album album2 = new Album();
                album2.Title = "and justice for all";
                album2.Year = 1988;
                album2.ProducerId = this.GetRandomProducer(context);
                album2.Songs.Add(this.GetSong(context, "Blackened", album1.Year, "Metallica"));
                album2.Songs.Add(this.GetSong(context, "One", album1.Year, "Metallica"));
                context.Albums.Add(album2);

                Album album3 = new Album();
                album3.Title = "The number of the beast";
                album3.Year = 1982;
                album3.ProducerId = this.GetRandomProducer(context);
                album3.Songs.Add(this.GetSong(context, "The Prisoner", album1.Year, "Iron Maiden"));
                album3.Songs.Add(this.GetSong(context, "Run to the hills", album1.Year, "Iron Maiden"));
                context.Albums.Add(album3);

                Album album4 = new Album();
                album4.Title = "Fear of the dark";
                album4.Year = 1992;
                album4.ProducerId = this.GetRandomProducer(context);
                album4.Songs.Add(this.GetSong(context, "Fear of the dark", album1.Year, "Iron Maiden"));
                context.Albums.Add(album4);

                Album album5 = new Album();
                album5.Title = "Machine Head";
                album5.Year = 1972;
                album5.ProducerId = this.GetRandomProducer(context);
                album5.Songs.Add(this.GetSong(context, "Highway Star", album1.Year, "Deep Purple"));
                album5.Songs.Add(this.GetSong(context, "Smoke on the Water", album1.Year, "Deep Purple"));
                context.Albums.Add(album5);
                
                context.SaveChanges();
            }
        }

        private Song GetSong(MusicLibraryDbContext context, string title, int year, string artistName)
        {
            Song song = new Song();
            song.Title = title;
            song.Year = year;
            song.GenreId = this.GetRandomGenre(context);
            song.Artists.Add(context.Artists.Where(a => a.Name == artistName).FirstOrDefault());

            return song;
        }

        private int GetRandomProducer(MusicLibraryDbContext context)
        {
            int[] producerIds = context.Producers.Select(p => p.Id).ToArray();
            return producerIds[this.random.Next(0, producerIds.Length - 1)];
        }

        private int GetRandomGenre(MusicLibraryDbContext context)
        {
            int[] genreIds = context.Genres.Select(g => g.Id).ToArray();
            return genreIds[this.random.Next(0, genreIds.Length - 1)];
        }

        private int GetRandomCountry(MusicLibraryDbContext context)
        {
            int[] countryIds = context.Countries.Select(c => c.Id).ToArray();
            return countryIds[this.random.Next(0, countryIds.Length - 1)];
        }
    }
}
