using application.cqrs.auth.command;
using application.cqrs.auth.query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecurityController : BaseController
    {
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult> RegisterUser_Authorized([FromBody] RegisterUser_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("register/adhoc")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult> RegisterUser_Anonymouse([FromBody] RegisterUser_Request command)
        {
            command.SetUserApiKey(Guid.NewGuid().ToString());
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult> GetAuthorizedsUsers()
        {
            var command = new GetAuthorizedUsers_Request();
            IssueKey(command);
            return Ok(await Mediator.Send(command));
        }
    }
}