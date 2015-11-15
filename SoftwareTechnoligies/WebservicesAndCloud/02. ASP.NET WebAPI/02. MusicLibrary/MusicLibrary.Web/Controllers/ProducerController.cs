namespace MusicLibrary.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicLibrary.Data.UnitOfWork;
    using MusicLibrary.Models;
    using MusicLibrary.Web.Models;

    public class ProducerController : ApiController
    {
        private IMusicLibraryData data;

        public ProducerController()
            : this(new MusicLibraryData())
        {
        }

        public ProducerController(IMusicLibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<ProducerModel> All()
        {
            var producers = this.data.Producers
                .All()
                .Select(ProducerModel.FromProducer);

            return producers;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var producer = this.data.Producers
                .SearchFor(p => p.Id == id)
                .Select(ProducerModel.FromProducer);

            if (producer.Any())
            {
                return this.Ok(producer);
            }

            return this.BadRequest(string.Format(HelperClass.NoProducerWithSuchId, id));
        }

        [HttpPost]
        public IHttpActionResult Create(ProducerModel producer)
        {
            if (!this.ModelState.IsValid)
            {
                this.BadRequest(this.ModelState);
            }

            var newProducer = new Producer
            {
                Name = producer.Name,
            };

            this.data.Producers.Add(newProducer);
            this.data.SaveChanges();

            producer.Id = newProducer.Id;

            return this.Ok(producer);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ProducerModel producer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingProducer = this.GetProducerById(id);

            if (existingProducer == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoProducerWithSuchId, id));
            }

            existingProducer.Name = producer.Name;

            this.data.SaveChanges();

            producer.Id = existingProducer.Id;
            return this.Ok(producer);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingProducer = this.GetProducerById(id);

            if (existingProducer == null)
            {
                return this.BadRequest(string.Format(HelperClass.NoProducerWithSuchId, id));
            }

            this.data.Producers.Delete(existingProducer);
            this.data.SaveChanges();

            return this.Ok();
        }

        private Producer GetProducerById(int id)
        {
            var existingProducer = this.data.Producers
                .SearchFor(p => p.Id == id)
                .FirstOrDefault();

            return existingProducer;
        }
    }
}
