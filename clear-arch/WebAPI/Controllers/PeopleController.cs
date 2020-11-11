using Core.Application;
using Core.Application.Biz.People.Commands.UpsertPerson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("allow")]
        public IActionResult Allow()
        {
            return Ok("test");
        }

        [HttpPost]
        [Route("upsert")]
        public async Task<ActionResult<string>> Upsert(UpsertPersonCommand command) => Ok(await Mediator.Send(command));


        [HttpGet]
        [Route("testing")]
        public async Task<ActionResult<string>> GejPositions() => Ok(await Mediator.Send(new GetPositionQuery()));


    }
}