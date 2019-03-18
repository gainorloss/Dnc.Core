using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Dnc.Framework
{
    public static class Framework
    {
        private static IServiceProvider _serviceProvider;

        public static IServiceProvider Provider => _serviceProvider;

        public static Microsoft.Extensions.Logging.ILogger Logger => Provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger>();

        public static IConfiguration Configuration => Provider.GetRequiredService<IConfiguration>();

        public static FrameworkEnvironment Environment => Provider.GetRequiredService<FrameworkEnvironment>();

        /// <summary>
        /// The entrypoint for the framework.
        /// </summary>
        public static FrameworkConstruction Build(this FrameworkConstruction construction)
        {
            _serviceProvider = construction.Services.BuildServiceProvider();

            Logger.LogCritical($"Framework start up in {construction.Environment.Environment}.");
            return construction;
        }
    }
}
