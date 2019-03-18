using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Logging
{
    /// <summary>
    /// The configuration for file logger.
    /// </summary>
    public class FileLoggerConfiguration
    {
        /// <summary>
        /// Log time as the message of the log?
        /// </summary>
        public bool LogTime { get; set; }

        /// <summary>
        /// The level of the log.
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Debug;
    }
}
