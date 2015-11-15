namespace MusicLibrary.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicLibrary.Data.UnitOfWork;
    using MusicLibrary.Models;
    using MusicLibrary.Web.Models;

    public class CountryController : ApiController
    {
        private IMusicLibraryData data;

        public CountryController()
            : this(new MusicLibraryData())
        {
        }

        public CountryController(IMusicLibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<CountryModel> All()
        {
            var countries = this.data.Countries
                .All()
                .Select(CountryModel.FromCountry);

            return countries;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var country = this.data.Countries
                .SearchFor(c => c.Id == id)
                .Select(CountryModel.FromCountry);

            if (country.Any())
            {
                return this.Ok(country);
            }

            return this.BadRequest(string.Format(HelperClass.NoCountryWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(CountryModel country)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newCountry = new Country
            {
                Name = country.Name,
            };

            this.data.Countries.Add(newCountry);
            this.data.SaveChanges();

            country.Id = newCountry.Id;

            return this.Ok(country);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CountryModel country)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingCountry = this.GetCountryById(id);

            if (existingCountry == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCountryWithSuchId, id));
            }

            existingCountry.Name = country.Name;

            this.data.SaveChanges();

            country.Id = existingCountry.Id;
            return this.Ok(country);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingCountry = this.GetCountryById(id);

            if (existingCountry == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoCountryWithSuchId, id));
            }

            this.data.Countries.Delete(existingCountry);
            this.data.SaveChanges();

            return this.Ok();
        }

        private Country GetCountryById(int id)
        {
            var existingCountry = this.data.Countries
                .SearchFor(c => c.Id == id)
                .FirstOrDefault();

            return existingCountry;
        }
    }
}
