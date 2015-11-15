using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web.Http;
using Repositories;

namespace BugLogger.RestApi.IntegrationTests
{
    public class InMemoryHttpServer<T>
    {
        private readonly HttpClient client;
        private string baseUrl;

        public InMemoryHttpServer(string baseUrl, IRepository<T> repository)
        {
            this.baseUrl = baseUrl;
            var config = new HttpConfiguration();
            this.AddHttpRoutes(config.Routes);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var resolver = new TestPlacesDependencyResolver<T>();
            resolver.Repository = repository;
            config.DependencyResolver = resolver;

            var server = new HttpServer(config);
            this.client = new HttpClient(server);
        } 

        public HttpResponseMessage CreateGetRequest(string requestUrl, string mediaType)
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(baseUrl + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Get;

            var response = this.client.SendAsync(request).Result;
            return response;
        }

        private void AddHttpRoutes(HttpRouteCollection routes)
        {
            throw new NotImplementedException();
        }
    }
}
