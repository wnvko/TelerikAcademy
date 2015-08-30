namespace MusicLibrary.Web.Controllers
{
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;

    using MusicLibrary.Data.UnitOfWork;
    using MusicLibrary.Models;
    using MusicLibrary.Web.Models;

    public class AlbumsController : ApiController
    {
        private IMusicLibraryData data;

        public AlbumsController()
            : this(new MusicLibraryData())
        {
        }

        public AlbumsController(IMusicLibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<AlbumModel> All()
        {
            var albums = this.data.Albums
                .All()
                .Select(AlbumModel.FromAlbum);

            return albums;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var album = this.data.Albums
                .SearchFor(a => a.Id == id)
                .Select(AlbumModel.FromAlbum);

            if (album.Any())
            {
                return this.Ok(album);
            }

            return this.BadRequest(string.Format(HelperClass.NoAlbumWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newAlbum = new Album
            {
                Title = album.Title,
                Year = album.Year,
                ProducerId = album.ProducerId,
            };

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            album.Id = newAlbum.Id;

            return this.Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingAlbum = this.GetAlbumById(id);

            if (existingAlbum == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoAlbumWithSuchId, id));
            }

            existingAlbum.Title = album.Title;
            existingAlbum.Year = album.Year;
            existingAlbum.ProducerId = album.ProducerId;

            this.data.SaveChanges();

            album.Id = existingAlbum.Id;
            return this.Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAlbum = this.GetAlbumById(id);

            if (existingAlbum == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoAlbumWithSuchId, id));
            }

            this.data.Albums.Delete(existingAlbum);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IQueryable<SongModel> Songs(int id)
        {
            var existingAlbum = this.GetAlbumById(id);

            if (existingAlbum == null)
            {
                throw new HttpResponseException(new HttpResponseMessage());
            }

            var songs = existingAlbum.Songs
                .AsQueryable()
                .Select(SongModel.FromSong);

            return songs;
        }

        [HttpPut]
        public IHttpActionResult AddSong(int id, int songId)
        {
            var existingAlbum = this.GetAlbumById(id);

            if (existingAlbum == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoAlbumWithSuchId, id));
            }

            var song = this.data.Songs
                .SearchFor(s => s.Id == songId)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, songId));
            }

            existingAlbum.Songs.Add(song);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveSong(int id, int songId)
        {
            var existingAlbum = this.GetAlbumById(id);

            if (existingAlbum == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoAlbumWithSuchId, id));
            }

            var song = existingAlbum.Songs
                .Where(s => s.Id == songId)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, songId));
            }

            existingAlbum.Songs.Remove(song);
            this.data.SaveChanges();

            return this.Ok();
        }

        private Album GetAlbumById(int id)
        {
            var existingAlbum = this.data.Albums
                .SearchFor(a => a.Id == id)
                .FirstOrDefault();

            return existingAlbum;
        }
    }
}
