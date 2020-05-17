namespace api.Controllers
{
    using application.cqrs.request.commands;
    using application.cqrs.request.queries;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ApproversController" />.
    /// </summary>
    public class ApproversController : BaseController
    {
        /// <summary>
        /// The GetApprovers.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetApprovers_Response}}"/>.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetApprovers_Response>> GetApprovers()
        {
            //var apikey = HttpContext.Request.Headers["x-api-key"];

            return Ok(await Mediator.Send(new GetApprovers_Request()));
        }

        /// <summary>
        /// The CreateApprover.
        /// </summary>
        /// <param name="command">The command<see cref="CreateApprover_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateApprover_Response}}"/>.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateApprover_Response>> CreateApprover([FromBody] CreateApprover_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }
    }
}