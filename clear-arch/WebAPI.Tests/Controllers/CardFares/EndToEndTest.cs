using Core.Application.Biz.Cards.Commands;
using Core.Application.Biz.Cards.Queries;
using Core.Application.Biz.Fares.Queries;
using Shouldly;
using System.Net.Http.Json;
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
            var client = _factory.GetAnonymousClient();

            var purchaseCommand = new PurchaseNewCardCommand();
            var purchaseResponse = await client.PostAsync("/api/card/buy", Utilities.GetRequestContent(purchaseCommand));
            purchaseResponse.EnsureSuccessStatusCode();

            var purchase = await purchaseResponse.Content.ReadFromJsonAsync<PurchaseNewCardResult>();

            var registerCmd = new RegisterCardCommand
            {
                CardNumber = purchase.CardNumber.ToUpper(),
                PWD_SeniorRef = "1234ABCS4321",
                IDForDiscount = 1,
            };

            var registerRes = await client.PostAsync("/api/card/register", Utilities.GetRequestContent(registerCmd));

            registerRes.EnsureSuccessStatusCode();

            var register = await registerRes.Content.ReadFromJsonAsync<RegisterCardResult>();

            var balanceRes = await client.GetAsync($"/api/card/balance?cardnumber={purchase.CardNumber}");

            var balance = await balanceRes.Content.ReadFromJsonAsync<CheckBalanceResult>();

            balance.Balance.ShouldBe(100);

            var reloadCmd = new ReloadCardCommand
            {
                CardNumber = purchase.CardNumber,
                LoadAmount = 1230,
            };

            var reloadRes = await client.PostAsync("/api/card/reload", Utilities.GetRequestContent(reloadCmd));

            reloadRes.EnsureSuccessStatusCode();

            var newBalance = await reloadRes.Content.ReadFromJsonAsync<ReloadCardResult>();

            newBalance.Balance.ShouldBe(1330);


            //see stations 1 = Baclaran 20= check it out
            var fare = await client.GetAsync($"/api/card/fares?from={1}&to={20}");

            fare.EnsureSuccessStatusCode();

            var exactFare = await fare.Content.ReadFromJsonAsync<GetFareResult>();

            var payCmd = new PayWithCardCommand
            {
                Amount = exactFare.Amount,
                CardNumber = purchase.CardNumber
            };

            var payRes = await client.PostAsync("/api/card/pay", Utilities.GetRequestContent(payCmd));

            payRes.EnsureSuccessStatusCode();

            var afterPayBalance = await payRes.Content.ReadFromJsonAsync<PayWithCardResult>();

            afterPayBalance.Balance.ShouldNotBe(newBalance.Balance);
             
        }
    }
}

