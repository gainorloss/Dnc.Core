using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Spiders
{
    public class BaseAgentSpiderItem
         : BaseSpiderItem
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Address { get; set; }
        public bool Anonymous { get; set; }
        public string AgentType { get; set; }
        public double Speed { get; set; }
        public double ConnectionTime { get; set; }
        public int AliveTime { get; set; }
        public DateTime VerifyTime { get; set; }
    }
}
