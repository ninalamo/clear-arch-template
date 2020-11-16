using Core.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUserManager userManager;

        public SecurityController(IUserManager manager)
        {
            userManager = manager;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<string>> Login(string userName, string password)
        {
            return Ok(await userManager.UserLoginAsync(userName, password));
        }
    }
}
