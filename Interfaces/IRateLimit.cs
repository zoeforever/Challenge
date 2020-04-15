using Entities;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRateLimit : IGrainWithStringKey
    {
        Task<double> IsNeedToLimit(RateLimitParameter para);
    }
}
