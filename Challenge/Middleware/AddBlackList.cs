using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Middleware
{
    public class AddBlackList
    {
        private readonly RequestDelegate next;
        private readonly IBlacklistService blacklistService;
        public AddBlackList(RequestDelegate _next, IBlacklistService _blacklistService)
        {
            //通过注入方式获得对象
            next = _next;
            blacklistService = _blacklistService;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("BAN"))
            {
                context.Request.Headers.Remove("BAN");
                await blacklistService.AddBlacklist(new Blacklist { Ip = context.Request.Host.Host, Createtime = DateTime.Now });
                context.Response.StatusCode = 409;
            }
            else
            {
                await next(context);
            }
        }
    }
}
