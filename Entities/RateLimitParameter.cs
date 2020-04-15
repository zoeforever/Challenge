using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RateLimitParameter
    {
        public double Rate { get; set; }
        public double BucketSize { get; set; }
    }
}
