namespace api.Controllers
{
    using application.cqrs.auditTrail.queries;
    using application.cqrs.client.commands;
    using application.cqrs.client.queries;
    using application.cqrs.job.queries;
    using application.cqrs.workplace.queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="MiscController" />.
    /// </summary>
    public class MiscController : BaseController
    {
        /// <summary>
        /// Defines the _provider.
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiscController"/> class.
        /// </summary>
        /// <param name="provider">The provider<see cref="IActionDescriptorCollectionProvider"/>.</param>
        public MiscController(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// The GetAll.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetAuditTrailsResponse}}"/>.</returns>
        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetAuditTrailsResponse>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAuditTrailsRequest()));
        }

        /// <summary>
        /// The GetClients.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetClientList_Response}}"/>.</returns>
        [HttpGet("client")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetClientList_Response>> GetClients()
        {
            return Ok(await Mediator.Send(new GetClientList_Request()));
        }

        /// <summary>
        /// The GetClients.
        /// </summary>
        /// <param name="command">The command<see cref="CreateClient_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateClient_Response}}"/>.</returns>
        [HttpPost("client")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateClient_Response>> GetClients([FromBody] CreateClient_Request command)
        {
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("client-migrate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateManyClient_Response>> GetClients([FromBody] CreateManyClient_Request command)
        {
            IssueKey(command);
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// The GetSites.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetWorkplaceList_Response}}"/>.</returns>
        [HttpGet("site")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetWorkplaceList_Response>> GetSites()
        {
            return Ok(await Mediator.Send(new GetWorkplaceList_Request()));
        }

        /// <summary>
        /// The GetPurposeOfHireEnums.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetPurposeofHireEnum_Response}}"/>.</returns>
        [HttpGet("purpose-of-hire")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetPurposeofHireEnum_Response>> GetPurposeOfHireEnums()
        {
            return Ok(await Mediator.Send(new GetPurposeOfHireEnum_Request()));
        }

        /// <summary>
        /// The GetEmploymentContractType.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetEmploymentContractTypes_Response}}"/>.</returns>
        [HttpGet("employment-contract-type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetEmploymentContractTypes_Response>> GetEmploymentContractType()
        {
            return Ok(await Mediator.Send(new GetEmploymentContractTypes_Request()));
        }

        /// <summary>
        /// The GetRoutes.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("routes")]
        public IActionResult GetRoutes()
        {
            var routes = _provider.ActionDescriptors.Items.Select(x => new
            {
                Controller = x.RouteValues["Controller"],
                //Id = _provider.ActionDescriptors.Items.ToList().IndexOf(x),
                Method = $"{x.RouteValues["Action"]}",
                Url = x.AttributeRouteInfo.Template.ToLower()
            }).ToList();
            return Ok(routes);
        }
    }
}