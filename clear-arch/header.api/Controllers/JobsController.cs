namespace api.Controllers
{
    using application.cqrs.job.commands;
    using application.cqrs.job.queries;
    using application.cqrs.request.commands;
    using application.cqrs.request.queries;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="JobsController" />.
    /// </summary>
    public class JobsController : BaseController
    {
        /// <summary>
        /// The GetEmploymentTypes.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetEmploymentContractTypes_Response}}"/>.</returns>
        [HttpGet("employment-types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetEmploymentContractTypes_Response>> GetEmploymentTypes()
        {
            return Ok(await Mediator.Send(new GetEmploymentContractTypes_Request()));
        }

        /// <summary>
        /// The GetJobCategories.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetJobCategories_Response}}"/>.</returns>
        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetJobCategories_Response>> GetJobCategories()
        {
            return Ok(await Mediator.Send(new GetJobCategories_Request()));
        }

        /// <summary>
        /// The GetJobRequestByID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetJobRequestByID_Response}}"/>.</returns>
        [HttpGet("request")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetJobRequestByID_Response>> GetJobRequestByID(long id)
        {
            return Ok(await Mediator.Send(new GetJobRequestByID_Request { ID = id }));
        }

        /// <summary>
        /// The CreateInternalJobRequest.
        /// </summary>
        /// <param name="command">The command<see cref="CreateInternalJob_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateInternalJob_Response}}"/>.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateInternalJob_Response>> CreateInternalJobRequest([FromBody] CreateInternalJob_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The GetPendingJobRequestByEmail.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <param name="isRequestor">The isRequestor<see cref="bool"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetPendingJobRequestList_Response}}"/>.</returns>
        [HttpGet("request/pending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetPendingJobRequestList_Response>> GetPendingJobRequestByEmail(string email, bool isRequestor = true)
        {
            return Ok(await Mediator.Send(new GetPendingJobRequestList_Request { Email = email.ToLower(), IsRequestor = isRequestor }));
        }

        /// <summary>
        /// The GetRejectedJobRequestByEmail.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <param name="isRequestor">The isRequestor<see cref="bool"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetRejectedJobRequestList_Response}}"/>.</returns>
        [HttpGet("request/rejected")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetRejectedJobRequestList_Response>> GetRejectedJobRequestByEmail(string email, bool isRequestor = true)
        {
            return Ok(await Mediator.Send(new GetRejectedJobRequestList_Request { Email = email.ToLower(), IsRequestor = isRequestor }));
        }

        /// <summary>
        /// The GetRevertedJobRequestByEmail.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <param name="isRequestor">The isRequestor<see cref="bool"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetRevertedJobRequestList_Response}}"/>.</returns>
        [HttpGet("request/reverted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetRevertedJobRequestList_Response>> GetRevertedJobRequestByEmail(string email, bool isRequestor = true)
        {
            return Ok(await Mediator.Send(new GetRevertedJobRequestList_Request { Email = email.ToLower(), IsRequestor = isRequestor }));
        }

        /// <summary>
        /// The CanceJobRequest.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{Unit}}"/>.</returns>
        [HttpDelete("request")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<Unit>> CanceJobRequest(long id)
        {
            var command = new CancelJobRequest_Request { ID = id };

            return Accepted(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The ReviewJobRequest.
        /// </summary>
        /// <param name="command">The command<see cref="ReviewJobRequest_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{ReviewJobRequest_Response}}"/>.</returns>
        [HttpPost("request")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<ReviewJobRequest_Response>> ReviewJobRequest([FromBody] ReviewJobRequest_Request command)
        {
            return Accepted(await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateInternalJobRequest.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateJobRequest_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateJobRequest_Response}}"/>.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateJobRequest_Response>> UpdateInternalJobRequest([FromBody] UpdateJobRequest_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The CreateJobTemplate.
        /// </summary>
        /// <param name="command">The command<see cref="CreateJobTemplate_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateJobTemplate_Response}}"/>.</returns>
        [HttpPost("template")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateJobTemplate_Response>> CreateJobTemplate([FromBody] CreateJobTemplate_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateJobTemplate.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateJobTemplate_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateJobTemplate_Response}}"/>.</returns>
        [HttpPut("template")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateJobTemplate_Response>> UpdateJobTemplate([FromBody] UpdateJobTemplate_Request command)
        {
            return Accepted(HttpContext.Request.Path, await Mediator.Send(command));
        }
    }
}