using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Redis
{
    /// <summary>
    /// Redis configuration options.
    /// </summary>
    public class RedisConfigOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }

        public string InstanceName { get; set; }
        public int AvalanchePreventionSeconds { get; set; } = 30;
    }
}
