//#define NO_DB
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using MysqlService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        DBContext dBContext;
        public UsersController(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        /// <summary>
        /// 由于没有数据库，暂时使用静态字段模拟用户信息
        /// </summary>

        static List<User> Users { get; set; } = new List<User>()
        {
            new User{UserId=1,Name="张三",Password="123456",UserName="zs"},
            new User{UserId=2,Name="李四",Password="123456",UserName="ls"}
        };
        [HttpGet]
        public JsonResult Get()
        {
#if NO_DB
            return new JsonResult(Users);
#else
            return new JsonResult(dBContext.Uesrs.ToList());
#endif
        }

        [HttpGet("{username}")]
        public JsonResult Get(string username)
        {
#if NO_DB
            var user = Users.FirstOrDefault(xx => xx.UserName.ToLower() == username.ToLower());
#else
            var user = dBContext.Uesrs.FirstOrDefault(xx => xx.UserName.ToLower() == username.ToLower());
#endif
            if (user != null)
            {
                return new JsonResult(user);
            }
            return new JsonResult("");
        }

        // POST api/users
        [HttpPost]
        public JsonResult Post([FromForm] User user)
        {
#if NO_DB
            user.UserId = Users.Count + 1;
            Users.Add(user);
#else
            dBContext.Uesrs.Add(user);
            dBContext.SaveChanges();
#endif
            return new JsonResult(user);
        }
    }
}