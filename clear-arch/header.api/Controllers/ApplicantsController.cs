namespace api.Controllers
{
    using api.CustomResult;
    using application.cqrs.applicant.commands;
    using application.cqrs.applicant.queries;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ApplicantsController" />.
    /// </summary>
    public class ApplicantsController : BaseController
    {
        /// <summary>
        /// The GetApplicantList.
        /// </summary>
        /// <param name="filter">The filter<see cref="string"/>.</param>
        /// <param name="pageNumber">The pageNumber<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{PageLink{GetApplicants_Response}}}"/>.</returns>
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<PageLink<GetApplicants_Response>>> GetApplicantList(string filter, int pageNumber = 1, int pageSize = 20)
        {
            var result = await Mediator.Send(new GetApplicants_Request
            {
                Filter = filter,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return Ok(PageLink<GetApplicants_Response>.Create(Url, result));
        }

        /// <summary>
        /// The GetApplicantByPersonID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetApplicantByPersonID_Response}}"/>.</returns>
        [HttpGet("person/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetApplicantByPersonID_Response>> GetApplicantByPersonID(long id)
        {
            return Ok(await Mediator.Send(new GetApplicantByPersonID_Request { ID = id }));
        }

        /// <summary>
        /// The GetApplicantByEmail.
        /// </summary>
        /// <param name="ad">The ad<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetApplicantByEmail_Response}}"/>.</returns>
        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetApplicantByEmail_Response>> GetApplicantByEmail([FromQuery] string ad)
        {
            return Ok(await Mediator.Send(new GetApplicantByEmail_Request { Email = ad }));
        }

        /// <summary>
        /// The GetApplicantByID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetApplicantByID_Response}}"/>.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetApplicantByID_Response>> GetApplicantByID(long id)
        {
            return Ok(await Mediator.Send(new GetApplicantByID_Request { ID = id }));
        }

        /// <summary>
        /// The CreateApplicant.
        /// </summary>
        /// <param name="command">The command<see cref="CreateApplicant_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateApplicant_Response}}"/>.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateApplicant_Response>> CreateApplicant([FromBody] CreateApplicant_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateApplicant.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateApplicant_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateApplicant_Response}}"/>.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateApplicant_Response>> UpdateApplicant([FromBody] UpdateApplicant_Request command)
        {
            return Accepted(await Mediator.Send(command));
        }

        /// <summary>
        /// The DEleteApplicant.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{Unit}}"/>.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<Unit>> DEleteApplicant([FromQuery]long id)
        {
            return Ok(await Mediator.Send(new DeleteApplicant_Request { ID = id }));
        }
    }
}