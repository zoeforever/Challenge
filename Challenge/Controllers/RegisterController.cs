using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IUserService userService;
        public RegisterController(IUserService _userService)
        {
            userService = _userService;
        }
        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] User user)
        {
            User old = await userService.GetUserByUsername(user.UserName);
            if (old != null)
            {
                return new JsonResult(new { code = "403", result = "用户已经存在" });
            }
            else
            {
                var regex = new Regex("(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z]).{8,30}");
                if (!regex.IsMatch(user.Password))
                {
                    return new JsonResult(new { code = "400", result = "密码不符合复杂度要求，必须包含大小写字母和数字，并且长度在8-30位！" });
                }
                var newUser = await userService.AddUser(user);
                return new JsonResult(newUser);
            }
        }
    }
}