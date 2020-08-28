using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Tests.Common;
using Xunit;

namespace WebAPI.Tests.Controllers
{
    public class BaseTestController : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly string BaseUrl = "/api";
        protected readonly CustomWebApplicationFactory<Startup> _factory;

        public BaseTestController(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Add("X-Api-Key", "ff8e5ae7-f75a-4fe5-b18b-8c22052e3438");
        }

        protected async Task<HttpResponseMessage> GetAsync(string url, bool isAuthenticated = true, bool throwError = true)
        {
            HttpClient _client;

            _client = isAuthenticated ? await _factory.GetAuthenticatedClientAsync("superadmin", "Got2groove!") : _factory.GetAnonymousClient();

            var response = await _client.GetAsync($"{BaseUrl}/{url}");

            if (throwError)
                response.EnsureSuccessStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> PostAsync(string url, object data, bool ensureSuccess = true)
        {
            var response = await _client.PostAsync($"{BaseUrl}/{url}", Utilities.GetRequestContent(data));

            if (ensureSuccess) response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
