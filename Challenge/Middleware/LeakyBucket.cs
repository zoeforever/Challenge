using Entities;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Middleware
{
    public class LeakyBucket
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration config;
        private readonly IClusterClient client;
        double rate; //流水速率

        double bucketSize; //桶的大小
        public LeakyBucket(RequestDelegate next, IClusterClient _client, IConfiguration _config)
        {
            //通过注入方式获得对象
            _next = next;
            client = _client;
            config = _config;
            rate = double.Parse(config["LeakyBucket:Rate"]);
            bucketSize = double.Parse(config["LeakyBucket:BucketSize"]);
        }

        public async Task Invoke(HttpContext context)
        {
            IRateLimit rateLimit = client.GetGrain<IRateLimit>(context.Request.Host.Host);
            var para = new RateLimitParameter { Rate = rate, BucketSize = bucketSize };
            double left = await rateLimit.IsNeedToLimit(para);
            if (left > 0)
            { // 水桶还没满,继续加1
                await _next(context);
            }
            else
            {
                ///如果超出30，进入下一个中间件，下一个中间件是用来加入黑名单的
                if (left <= -30)
                {
                    //Header中加入一个标志
                    context.Request.Headers.Add("BAN", "1");
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = 429;
                }
            }
        }
    }
}
