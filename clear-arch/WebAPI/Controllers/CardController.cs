using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Biz.Cards.Commands;
using Core.Application.Biz.Cards.Queries;
using Core.Application.Biz.Fares.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CardController : BaseController
    {
        [HttpPost("pay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<PayWithCardResult>> PayWithCard([FromBody] PayWithCardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("buy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<PurchaseNewCardResult>> PurchaseNewCard([FromBody] PurchaseNewCardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<RegisterCardResult>> Register([FromBody] RegisterCardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("reload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<ReloadCardResult>> Reload([FromBody] ReloadCardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("balance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CheckBalanceResult>> CheckBalance(string cardNumber)
        {
            return Ok(await Mediator.Send(new CheckBalanceQuery { CardNumber = cardNumber }));
        }

        [HttpGet("fares")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetFareResult>> GetFares(int from, int to)
        {
            return Ok(await Mediator.Send(new GetFareQuery { DropOff = to, PickUp = from }));
        }
    }
}
