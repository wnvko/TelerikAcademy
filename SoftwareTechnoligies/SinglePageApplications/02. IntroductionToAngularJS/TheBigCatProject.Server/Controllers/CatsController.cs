namespace TheBigCatProject.Server.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using Extensions;
    using Models;
    public class CatsController : ApiController
    {
        private List<CatRequestModel> catsData = new List<CatRequestModel>();
        private string[] urls = new string[]
            {
                "http://stuffpoint.com/dogs/image/248703-dogs-nice-cute.jpg",
                "http://images3.alphacoders.com/270/270209.jpg",
                "https://denvilledogpark.files.wordpress.com/2011/11/central-dog-park-044.jpg"
            };


        public CatsController()
        {
            for (int i = 0; i < 20; i++)
            {
                var cat = new CatRequestModel();
                cat.Id = i;
                cat.Name = "Cat " + i % 4;
                cat.Breed = (CatBreed)(i % 3);
                cat.Url = this.urls[i % 3];
                cat.Age = i % 5;

                this.catsData.Add(cat);
            }
        }

        public IHttpActionResult Post(CatRequestModel model)
        {
            if (model != null)
            {
                model.Id = this.catsData.Count + 1;
                this.catsData.Add(model);
            }

            return Ok(model.Id);
        }

        public IHttpActionResult Get([FromUri]CatFilterModel model)
        {
            var result = this.catsData
                .AsQueryable()
                .ToFilterCats(model)
                .Take(10)
                .ToList();

            return this.Ok(result);
        }
    }
}