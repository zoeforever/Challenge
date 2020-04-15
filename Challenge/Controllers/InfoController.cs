using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class InfoController : ControllerBase
    {
        IUserService userService;
        public InfoController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            List<User> users = await userService.GetAll();
            return new JsonResult(users.Select(xx => new { xx.UserId, xx.UserName }));
        }

        [HttpGet("{username}")]
        public async Task<JsonResult> Get(string username)
        {
            User user = await userService.GetUserByUsername(username);
            return new JsonResult(new { user.UserId, user.UserName });
        }
    }
}