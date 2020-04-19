//#define NO_DB

using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MysqlService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistsController : Controller
    {
        DBContext dBContext;
        public BlacklistsController(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        /// <summary>
        /// 由于没有数据库，暂时使用静态字段模拟用户信息
        /// </summary>

        static List<Blacklist> blacklists { get; set; } = new List<Blacklist>()
        {
            new Blacklist{ Id=1,Ip="192.168.1.100",Createtime=DateTime.Now.AddMinutes(-2)},
            new Blacklist{ Id=2,Ip="192.168.1.101",Createtime=DateTime.Now.AddMinutes(-3)},
        };
        [HttpGet]
        public JsonResult Get()
        {
#if NO_DB
            return new JsonResult(blacklists);
#else
            return new JsonResult(dBContext.Blacklists.ToList());
#endif
        }

        [HttpGet("{ip}")]
        public JsonResult Get(string ip)
        {
#if NO_DB
            var blacklistItem = blacklists.FirstOrDefault(xx => xx.Ip == ip);
#else
            var blacklistItem = dBContext.Blacklists.FirstOrDefault(xx => xx.Ip == ip);
#endif
            if (blacklistItem != null)
            {
                return new JsonResult(blacklistItem);
            }
            return new JsonResult("");
        }

        [HttpDelete("{ip}")]
        public JsonResult Delete(string ip)
        {
#if NO_DB
            var blacklistItem = blacklists.FirstOrDefault(xx => xx.Ip == ip);
            if (blacklistItem != null)
            {
                blacklists.Remove(blacklistItem);
                return new JsonResult(blacklistItem);
            }
#else
            var blacklistItem = dBContext.Blacklists.FirstOrDefault(xx => xx.Ip == ip);
            if (blacklistItem != null)
            {
                dBContext.Blacklists.Remove(blacklistItem);
                dBContext.SaveChanges();
            }
#endif
            return new JsonResult("");
        }

        // POST api/users
        [HttpPost]
        public JsonResult Post([FromForm] Blacklist blacklistItem)
        {
#if NO_DB
            var bl = blacklists.FirstOrDefault(xx => xx.Ip == blacklistItem.Ip);
            if (bl == null)
            {
                blacklistItem.Id = blacklists.Count + 1;
                blacklists.Add(blacklistItem);
            }
            else
            {
                bl.Createtime = blacklistItem.Createtime;
            }
#else
            var bl = dBContext.Blacklists.FirstOrDefault(xx => xx.Ip == blacklistItem.Ip);
            if (bl == null)
            {
                dBContext.Blacklists.Add(blacklistItem);
                dBContext.SaveChanges();
            }
            else
            {
                bl.Createtime = blacklistItem.Createtime;
                dBContext.SaveChanges();
            }
#endif
            return new JsonResult(blacklistItem);
        }
    }
}