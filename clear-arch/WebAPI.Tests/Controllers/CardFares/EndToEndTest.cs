using System.Threading.Tasks;
using WebAPI.Tests.Common;
using Xunit;

namespace WebAPI.Tests.Controllers.CardFares
{
    public class EndToEndTest : BaseTestController
    {
        public EndToEndTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task StartE2E()
        {
        }
    }
}