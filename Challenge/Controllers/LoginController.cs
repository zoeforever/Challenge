using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        IUserService userService;
        public LoginController(IUserService _userService)
        {
            userService = _userService;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] User user)
        {
            var token = await userService.IsUserValid(user);
            if (token != null)
            {
                return new JsonResult(new { token = token.Access_Token });
            }
            return new JsonResult(new { code = 400, result = "用户名或密码错误" });
        }
    }
}