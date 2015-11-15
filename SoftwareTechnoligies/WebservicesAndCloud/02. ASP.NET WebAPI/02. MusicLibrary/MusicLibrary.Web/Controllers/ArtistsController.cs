namespace MusicLibrary.Web.Controllers
{
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;

    using MusicLibrary.Data.UnitOfWork;
    using MusicLibrary.Models;
    using MusicLibrary.Web.Models;

    public class ArtistsController : ApiController
    {
        private IMusicLibraryData data;

        public ArtistsController()
            : this(new MusicLibraryData())
        {
        }

        public ArtistsController(IMusicLibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<ArtistModel> All()
        {
            var artists = this.data.Artists
                .All()
                .Select(ArtistModel.FromArtist);

            return artists;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = this.data.Artists
                .SearchFor(a => a.Id == id)
                .Select(ArtistModel.FromArtist);

            if (artist.Any())
            {
                return this.Ok(artist);
            }

            return this.BadRequest(string.Format(HelperClass.NoArtistWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newArtist = new Artist
            {
                Name = artist.Name,
                DateOfBirth = artist.DateOfBirth,
                CountryId = artist.CountryId,
            };

            this.data.Artists.Add(newArtist);
            this.data.SaveChanges();

            artist.Id = newArtist.Id;

            return this.Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingArtist = this.GetArtistById(id);

            if (existingArtist == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoArtistWithSuchId, id));
            }

            existingArtist.Name = artist.Name;
            existingArtist.DateOfBirth = artist.DateOfBirth;
            existingArtist.CountryId = artist.CountryId;

            this.data.SaveChanges();

            artist.Id = existingArtist.Id;
            return this.Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.GetArtistById(id);

            if (existingArtist == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoGenreWithSuchId, id));
            }

            this.data.Artists.Delete(existingArtist);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IQueryable<SongModel> Songs(int id)
        {
            var existingArtist = this.GetArtistById(id);

            if (existingArtist == null)
            {
                throw new HttpResponseException(new HttpResponseMessage());
            }

            var songs = existingArtist.Songs
                .AsQueryable()
                .Select(SongModel.FromSong);

            return songs;
        }

        [HttpPut]
        public IHttpActionResult AddSong(int id, int songId)
        {
            var existingArtist = this.GetArtistById(id);

            if (existingArtist == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoArtistWithSuchId, id));
            }

            var song = this.data.Songs
                .SearchFor(s => s.Id == songId)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, songId));
            }

            existingArtist.Songs.Add(song);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveSong(int id, int songId)
        {
            var existingArtist = this.GetArtistById(id);

            if (existingArtist == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoArtistWithSuchId, id));
            }

            var song = existingArtist.Songs
                .Where(s => s.Id == songId)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, songId));
            }

            existingArtist.Songs.Remove(song);
            this.data.SaveChanges();

            return this.Ok();
        }

        private Artist GetArtistById(int id)
        {
            var existingArtist = this.data.Artists
                .SearchFor(a => a.Id == id)
                .FirstOrDefault();

            return existingArtist;
        }
    }
}
