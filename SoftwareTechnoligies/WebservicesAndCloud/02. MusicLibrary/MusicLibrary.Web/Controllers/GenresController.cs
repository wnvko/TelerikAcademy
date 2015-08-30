namespace MusicLibrary.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicLibrary.Data.UnitOfWork;
    using MusicLibrary.Models;
    using MusicLibrary.Web.Models;

    public class GenresController : ApiController
    {
        private IMusicLibraryData data;

        public GenresController()
            : this(new MusicLibraryData())
        {
        }

        public GenresController(IMusicLibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<GenreModel> All()
        {
            var genres = this.data.Genres
                .All()
                .Select(GenreModel.FromGenre);

            return genres;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var genre = this.data.Genres
                .SearchFor(g => g.Id == id)
                .Select(GenreModel.FromGenre);

            if (genre.Any())
            {
                return this.Ok(genre);
            }

            return this.BadRequest(string.Format(HelperClass.NoGenreWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(GenreModel genre)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newGenre = new Genre
            {
                Name = genre.Name,
            };

            this.data.Genres.Add(newGenre);
            this.data.SaveChanges();

            genre.Id = newGenre.Id;

            return this.Ok(genre);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, GenreModel genre)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingGenre = this.GetGenreById(id);

            if (existingGenre == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoGenreWithSuchId, id));
            }

            existingGenre.Name = genre.Name;

            this.data.SaveChanges();

            genre.Id = existingGenre.Id;
            return this.Ok(genre);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingGenre = this.GetGenreById(id);

            if (existingGenre == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoGenreWithSuchId, id));
            }

            this.data.Genres.Delete(existingGenre);
            this.data.SaveChanges();

            return this.Ok();
        }

        private Genre GetGenreById(int id)
        {
            var existingGenre = this.data.Genres
                .SearchFor(g => g.Id == id)
                .FirstOrDefault();

            return existingGenre;
        }
    }
}
