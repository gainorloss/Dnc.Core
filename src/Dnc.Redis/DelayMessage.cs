using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Redis
{
    public class DelayMessage
    {
        public DateTime Timestamp { get; set; }
        public object Member { get; set; }
    }
}
