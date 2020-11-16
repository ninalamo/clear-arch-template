using Core.Application.Biz.People.Commands.UpsertPerson;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController
    {
      
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreatePerson([FromBody] UpsertPersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}