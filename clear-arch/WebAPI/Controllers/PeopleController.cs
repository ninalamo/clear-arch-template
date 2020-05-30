using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Allow()
        {
            return Ok("test");
        }
    }
}