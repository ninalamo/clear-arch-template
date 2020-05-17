using application.cqrs.auditTrail.queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : BaseController
    {
        [HttpGet("get")]
        public async Task<ActionResult<GetAuditTrailsResponse>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAuditTrailsRequest()));
        }
    }
}