namespace api.Controllers
{
    using application.cqrs.job.queries;
    using application.cqrs.person.commands;
    using application.cqrs.person.queries;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="PersonsController" />.
    /// </summary>
    public class PersonsController : BaseController
    {
        /// <summary>
        /// The GetPersonByPersonalEmail.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetPersonByPersonalEmail_Response}}"/>.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetPersonByPersonalEmail_Response>> GetPersonByPersonalEmail([FromQuery]string email)
        {
            return Ok(await Mediator.Send(new GetPersonByPersonalEmail_Request { PersonalEmail = email }));
        }

        /// <summary>
        /// The GetEducationByPersonID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetEducationByPersonID_Response}}"/>.</returns>
        [HttpGet("{id}/education")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetEducationByPersonID_Response>> GetEducationByPersonID(Guid id)
        {
            return Ok(await Mediator.Send(new GetEducationByPersonID_Request { ID = id }));
        }

        /// <summary>
        /// The CreateEducation.
        /// </summary>
        /// <param name="command">The command<see cref="CreateEducation_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateEducation_Response}}"/>.</returns>
        [HttpPost("education")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateEducation_Response>> CreateEducation([FromBody] CreateEducation_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateEducation.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateEducation_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateEducation_Response}}"/>.</returns>
        [HttpPut("education")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateEducation_Response>> UpdateEducation([FromBody] UpdateEducation_Request command)
        {
            return Accepted(await Mediator.Send(command));
        }

        /// <summary>
        /// The DeleteEducation.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{Unit}}"/>.</returns>
        [HttpDelete("education/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<Unit>> DeleteEducation(long id)
        {
            return Ok(await Mediator.Send(new DeleteEducation_Request { ID = id }));
        }

        /// <summary>
        /// The CreateGovernmentInfo.
        /// </summary>
        /// <param name="applicantID">The applicantID<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetGovernmentInfoByApplicantID_Response}}"/>.</returns>
        [HttpGet("government-info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetGovernmentInfoByApplicantID_Response>> CreateGovernmentInfo(long applicantID)
        {
            return Ok(await Mediator.Send(new GetGovernmentInfoByApplicantID_Request { ID = applicantID }));
        }

        /// <summary>
        /// The CreateGovernmentInfo.
        /// </summary>
        /// <param name="command">The command<see cref="CreateGovernmentDocs_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateGovernmentDocs_Response}}"/>.</returns>
        [HttpPost("government-info")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateGovernmentDocs_Response>> CreateGovernmentInfo([FromBody] CreateGovernmentDocs_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateGovernmentInfo.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateGovernmentDoc_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateGovernmentDoc_Response}}"/>.</returns>
        [HttpPut("government-info")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateGovernmentDoc_Response>> UpdateGovernmentInfo([FromBody] UpdateGovernmentDoc_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }
    }
}