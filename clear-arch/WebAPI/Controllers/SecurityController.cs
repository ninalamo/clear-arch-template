using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<string>> Login(string userName, string password)
        {
            return Ok(await userManager.UserLoginAsync(userName, password));
        }
    }
}
