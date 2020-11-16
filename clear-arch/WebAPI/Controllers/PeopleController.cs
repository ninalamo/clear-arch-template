using Core.Application.Biz.People.Commands.UpsertPerson;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreatePerson([FromBody] UpsertPersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}