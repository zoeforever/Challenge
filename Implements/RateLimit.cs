using Entities;
using Interfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Implements
{
    public class RateLimit : Grain, IRateLimit
    {
        double rate; //流水速率

        double bucketSize; //桶的大小

        DateTime refreshTime; //上次刷新时间

        double water; //上次刷新时水量

        double total;//总访问次数，用来记录桶满了以后仍然访问的情况

        void refreshWater()
        {
            DateTime now = DateTime.Now;
            //水随着时间流逝,不断流走,最多就流干到0.
            water = Math.Max(0, water - (now - refreshTime).TotalMinutes * rate);
            refreshTime = now;
        }

        public Task<double> IsNeedToLimit(RateLimitParameter para)
        {
            rate = para.Rate;
            bucketSize = para.BucketSize;
            refreshWater();
            if (water < bucketSize)
            { // 水桶还没满,继续加1
                water++;
            }
            total++;
            Console.WriteLine("work here");
            return Task.FromResult(bucketSize - total);
        }
    }
}
