namespace MusicLibrary.Web.Controllers
{
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;

    using MusicLibrary.Data.UnitOfWork;
    using MusicLibrary.Models;
    using MusicLibrary.Web.Models;

    public class SongsController : ApiController
    {
        private IMusicLibraryData data;

        public SongsController()
            : this(new MusicLibraryData())
        {
        }

        public SongsController(IMusicLibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<SongModel> All()
        {
            var songs = this.data.Songs
                .All()
                .Select(SongModel.FromSong);

            return songs;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var song = this.data.Songs
                .SearchFor(s => s.Id == id)
                .Select(SongModel.FromSong);

            if (song.Any())
            {
                return this.Ok(song);
            }

            return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newSong = new Song
            {
                Title = song.Title,
                Year = song.Year,
                AlbumId = song.AlbumId,
                GenreId = song.GenreId,
            };

            this.data.Songs.Add(newSong);
            this.data.SaveChanges();

            song.Id = newSong.Id;

            return this.Ok(song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingSong = this.GetSongById(id);

            if (existingSong == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, id));
            }

            existingSong.Title = song.Title;
            existingSong.Year = song.Year;
            existingSong.AlbumId = song.AlbumId;
            existingSong.GenreId = song.GenreId;

            this.data.SaveChanges();

            song.Id = existingSong.Id;
            return this.Ok(song);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.GetSongById(id);

            if (existingSong == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, id));
            }

            this.data.Songs.Delete(existingSong);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IQueryable<ArtistModel> Artists(int id)
        {
            var existingSong = this.GetSongById(id);

            if (existingSong == null)
            {
                throw new HttpResponseException(new HttpResponseMessage());
            }

            var artists = existingSong.Artists
                .AsQueryable()
                .Select(ArtistModel.FromArtist);

            return artists;
        }

        [HttpPut]
        public IHttpActionResult AddArtist(int id, int artistId)
        {
            var existingSong = this.GetSongById(id);

            if (existingSong == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, id));
            }

            var artist = this.data.Artists
                .SearchFor(a => a.Id == artistId)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoArtistWithSuchId, artistId));
            }

            existingSong.Artists.Add(artist);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveArtist(int id, int artistId)
        {
            var existingSong = this.GetSongById(id);

            if (existingSong == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, id));
            }

            var artist = existingSong.Artists
                .Where(a => a.Id == artistId)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoArtistWithSuchId, artistId));
            }

            existingSong.Artists.Remove(artist);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult Album(int id)
        {
            var existingSong = this.GetSongById(id);

            if (existingSong == null)
            {
                throw new HttpResponseException(new HttpResponseMessage());
            }

            var album = existingSong.Album;
            var albumModel = this.GetAlbumModel(album);

            return this.Ok(albumModel);
        }

        [HttpPut]
        public IHttpActionResult SetAlbum(int id, int albumId)
        {
            var existingSong = this.GetSongById(id);

            if (existingSong == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, id));
            }

            var album = this.data.Albums
                .SearchFor(a => a.Id == albumId)
                .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoAlbumWithSuchId, albumId));
            }

            existingSong.Album = album;
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveAlbum(int id)
        {
            var existingSong = this.GetSongById(id);

            if (existingSong == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoSongWithSuchId, id));
            }

            existingSong.Album = null;
            this.data.SaveChanges();

            return this.Ok();
        }

        private Song GetSongById(int id)
        {
            var existingSong = this.data.Songs
                .SearchFor(s => s.Id == id)
                .FirstOrDefault();

            return existingSong;
        }

        private object GetAlbumModel(Album album)
        {
            AlbumModel albumModel = new AlbumModel();
            albumModel.Id = album.Id;
            albumModel.Title = album.Title;
            albumModel.Year = album.Year;
            albumModel.ProducerId = album.ProducerId;

            return albumModel;
        }
    }
}
