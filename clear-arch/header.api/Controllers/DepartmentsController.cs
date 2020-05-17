namespace api.Controllers
{
    using application.cqrs.department.commands;
    using application.cqrs.department.queries;
    using application.cqrs.group.queries;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="DepartmentsController" />.
    /// </summary>
    public class DepartmentsController : BaseController
    {
        /// <summary>
        /// The GetDepartments.
        /// </summary>
        /// <param name="active">The active<see cref="bool"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetDepartmentList_Response}}"/>.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetDepartmentList_Response>> GetDepartments([FromQuery] bool active = false)
        {
            return Ok(await Mediator.Send(new GetDepartmentList_Request { ActiveOnly = active }));
        }

        /// <summary>
        /// The GetDepartmentByID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetDepartmentByID_Response}}"/>.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetDepartmentByID_Response>> GetDepartmentByID(long id)
        {
            return Ok(await Mediator.Send(new GetDepartmentByID_Request { ID = id }));
        }

        /// <summary>
        /// The CreateDepartment.
        /// </summary>
        /// <param name="command">The command<see cref="CreateDepartment_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateDepartment_Response}}"/>.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateDepartment_Response>> CreateDepartment([FromBody] CreateDepartment_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateDepartment.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateDepartment_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateDepartment_Response}}"/>.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateDepartment_Response>> UpdateDepartment([FromBody] UpdateDepartment_Request command)
        {
            return Accepted(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The DeleteDepartment.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{DeleteDepartment_Response}}"/>.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<DeleteDepartment_Response>> DeleteDepartment(long id)
        {
            return Accepted(await Mediator.Send(new DeleteDepartment_Request { ID = id }));
        }

        /// <summary>
        /// The GetRolesByDepartmentID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetRolesByDepartmentID_Response}}"/>.</returns>
        [HttpGet("{id}/role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetRolesByDepartmentID_Response>> GetRolesByDepartmentID(long id)
        {
            return Ok(await Mediator.Send(new GetRolesByDepartmentID_Request { ID = id }));
        }

        /// <summary>
        /// The CreateDepartmentRole.
        /// </summary>
        /// <param name="command">The command<see cref="CreateDepartmentRole_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateDepartmentRole_Response}}"/>.</returns>
        [HttpPost("role")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateDepartmentRole_Response>> CreateDepartmentRole([FromBody] CreateDepartmentRole_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateDepartmentRole.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateDepartmentRole_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateDepartmentRole_Response}}"/>.</returns>
        [HttpPut("role")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateDepartmentRole_Response>> UpdateDepartmentRole([FromBody] UpdateDepartmentRole_Request command)
        {
            return Accepted(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The GetDepartmentMembers.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <param name="execs">The execs<see cref="bool"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetDepartmentMemberList_Response}}"/>.</returns>
        [HttpGet("{id}/members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetDepartmentMemberList_Response>> GetDepartmentMembers(long id, [FromQuery]bool execs = false)
        {
            return Ok(await Mediator.Send(new GetDepartmentMemberList_Request { ID = id, IncludeExecutives = execs }));
        }

        /// <summary>
        /// The AddMembersToPosition.
        /// </summary>
        /// <param name="command">The command<see cref="AddMembersToDepartmentRole_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{AddMembersToDepartmentRole_Response}}"/>.</returns>
        [HttpPost("member")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<AddMembersToDepartmentRole_Response>> AddMembersToPosition([FromBody] AddMembersToDepartmentRole_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The RemoveMemberFromPosition.
        /// </summary>
        /// <param name="command">The command<see cref="RemoveMemberFromDepartmentRole_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{RemoveMemberFromDepartmentRole_Response}}"/>.</returns>
        [HttpDelete("member")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<RemoveMemberFromDepartmentRole_Response>> RemoveMemberFromPosition([FromBody] RemoveMemberFromDepartmentRole_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }
    }
}