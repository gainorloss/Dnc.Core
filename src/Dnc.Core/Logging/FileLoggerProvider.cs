using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Logging
{
    /// <summary>
    /// Logging provider.
    /// </summary>
    public class FileLoggerProvider
        : ILoggerProvider
    {
        private readonly string _categoryName;

        private readonly ConcurrentDictionary<string, FileLoggerConfiguration> configurations
            = new ConcurrentDictionary<string, FileLoggerConfiguration>();

        public FileLoggerProvider(string categoryName)
        {
            _categoryName = categoryName;
        }
        public ILogger CreateLogger(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            configurations.Clear();
        }
    }
}
