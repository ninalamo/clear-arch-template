using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("allow")]
        public IActionResult Allow()
        {
            return Ok("test");
        }
    }
}