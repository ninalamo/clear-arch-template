namespace api.Controllers
{
    using api.CustomResult;
    using application.cqrs.employee.commands;
    using application.cqrs.employee.queries;
    using application.cqrs.offboarding.commands;
    using application.cqrs.offboarding.queries;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="EmployeesController" />.
    /// </summary>
    public class EmployeesController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("migrate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateManyEmployee_Response>> CreateEmployee([FromBody] CreateManyEmployee_Request command)
        {
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The GetEmployeeList.
        /// </summary>
        /// <param name="pageNumber">The pageNumber<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="filter">The filter<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{PageLink{GetEmployeeList_Response}}}"/>.</returns>
        [HttpGet("{pageNumber}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<PageLink<GetEmployeeList_Response>>> GetEmployeeList(int pageNumber = 1, int pageSize = 10, [FromQuery] string filter = "")
        {
            var result = await Mediator.Send(new GetEmployeeList_Request
            {
                Filter = filter,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return Ok(PageLink<GetEmployeeList_Response>.Create(Url, result));
        }

        /// <summary>
        /// The GetEmployeeByID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetEmployeeByID_Response}}"/>.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetEmployeeByID_Response>> GetEmployeeByID(Guid id)
        {
            return Ok(await Mediator.Send(new GetEmployeeByID_Request { ID = id }));
        }

        /// <summary>
        /// The GetEmployeesWithPosition.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetEmployeesByPosition_Response}}"/>.</returns>
        [HttpGet("position")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetEmployeesByPosition_Response>> GetEmployeesWithPosition([FromQuery]long id)
        {
            return Ok(await Mediator.Send(new GetEmployeesByPosition_Request { ID = id }));
        }

        /// <summary>
        /// The GetEmployeeWithoutDepartmentRole.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{GetEmployeesWithoutDepartmentRole_Response}}"/>.</returns>
        [HttpGet("nonce")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetEmployeesWithoutDepartmentRole_Response>> GetEmployeeWithoutDepartmentRole()
        {
            return Ok(await Mediator.Send(new GetEmployeesWithoutDepartmentRole_Request()));
        }

        /// <summary>
        /// The CreateEmployee.
        /// </summary>
        /// <param name="command">The command<see cref="CreateEmployee_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateEmployee_Response}}"/>.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateEmployee_Response>> CreateEmployee([FromBody] CreateEmployee_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateEmployee.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateEmployee_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateEmployee_Response}}"/>.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateEmployee_Response>> UpdateEmployee([FromBody] UpdateEmployee_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The RemoveEmployee.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <param name="flag">The flag<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult> RemoveEmployee(Guid id, [FromQuery] int flag = 0)
        {
            return Ok(await Mediator.Send(new DeleteEmployee_Request { ID = id, IsHardDelete = flag == 1 }));
        }

        /// <summary>
        /// The GetCompensationListByEmployeeID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetCompensationListByEmployeeID_Response}}"/>.</returns>
        [HttpGet("{id}/compensation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetCompensationListByEmployeeID_Response>> GetCompensationListByEmployeeID(Guid id)
        {
            var command = new GetCompensationListByEmployeeID_Request { ID = id };
            IssueKey(command);
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// The GetCompensationByID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetCompensationByID_Response}}"/>.</returns>
        [HttpGet("compensation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetCompensationByID_Response>> GetCompensationByID([FromQuery]long id)
        {
            var command = new GetCompensationByID_Request { ID = id };
            IssueKey(command);
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// The AddCompensation.
        /// </summary>
        /// <param name="command">The command<see cref="CreateCompensation_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateCompensation_Response}}"/>.</returns>
        [HttpPost("compensation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateCompensation_Response>> AddCompensation([FromBody] CreateCompensation_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateCompensation.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateCompensation_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateCompensation_Response}}"/>.</returns>
        [HttpPut("compensation")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateCompensation_Response>> UpdateCompensation([FromBody] UpdateCompensation_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The RemoveCompensation.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{Unit}}"/>.</returns>
        [HttpDelete("compensation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<Unit>> RemoveCompensation([FromQuery]long id)
        {
            var command = new DeleteCompensation_Request { ID = id };
            IssueKey(command);
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// The CreateHoldSalary.
        /// </summary>
        /// <param name="command">The command<see cref="CreateSalaryOnHold_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateSalaryOnHold_Response}}"/>.</returns>
        [HttpPost("hold-salary")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateSalaryOnHold_Response>> CreateHoldSalary([FromBody] CreateSalaryOnHold_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateHoldSalary.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateSalaryOnHold_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateSalaryOnHold_Response}}"/>.</returns>
        [HttpPut("hold-salary")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateSalaryOnHold_Response>> UpdateHoldSalary([FromBody] UpdateSalaryOnHold_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The GetEmployeeOffboardByID.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{GetOffboardingByEmployeeID_Response}}"/>.</returns>
        [HttpGet("{id}/offboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetOffboardingByEmployeeID_Response>> GetEmployeeOffboardByID(Guid id)
        {
            var command = new GetOffboardingByEmployeeID_Request { EmployeeID = id };
            IssueKey(command);
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// The CreateOffboarding.
        /// </summary>
        /// <param name="command">The command<see cref="CreateOffboarding_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateOffboarding_Response}}"/>.</returns>
        [HttpPost("offboard")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateOffboarding_Response>> CreateOffboarding([FromBody] CreateOffboarding_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        [HttpGet("{sr}/movements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<GetMovementsBySR_Response>> GetMovemementsBYSR(string sr)
        {
            var command = new GetMovementsBySR_Request { SR = sr };
            IssueKey(command);
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// The CreateEmployeeMovement.
        /// </summary>
        /// <param name="command">The command<see cref="CreateEmployeeMovement_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{CreateEmployeeMovement_Response}}"/>.</returns>
        [HttpPost("movement")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<CreateEmployeeMovement_Response>> CreateEmployeeMovement([FromBody] CreateEmployeeMovement_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }

        /// <summary>
        /// The UpdateEmployeeMovement.
        /// </summary>
        /// <param name="command">The command<see cref="UpdateEmployeeMovement_Request"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UpdateEmployeeMovement_Response}}"/>.</returns>
        [HttpPut("movement")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<ActionResult<UpdateEmployeeMovement_Response>> UpdateEmployeeMovement([FromBody] UpdateEmployeeMovement_Request command)
        {
            IssueKey(command);
            return Created(HttpContext.Request.Path, await Mediator.Send(command));
        }
    }
}