using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using WebAPI.Tests.Common;
using Xunit;

namespace WebAPI.Tests.Controllers.People
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public Create(CustomWebApplicationFactory<Startup> factoryArg)
        {
            factory = factoryArg;
        }

        [Fact]
        public async Task AddsANewPersonSuccessfully()
        {
            var client = factory.GetAnonymousClient();

            var response = await client.PostAsync("", null);
        }
    }
}
