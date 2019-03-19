using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Dnc
{
    public static class Framework
    {
        public static FrameworkConstruction Construction { get; private set; }


        private static IServiceProvider ServiceProvider => Construction.ServiceProvider;


        public static void Build(this FrameworkConstruction construction, bool logStarted = true)
        {
            construction.Build();

            if (logStarted)
            {
                var logger = ServiceProvider.GetService<ILogger>();
                var env = ServiceProvider.GetService<FrameworkEnvironment>();

                logger.LogCritical($"Dnc core  started in {env.Environment}...");
            }
        }


        public static FrameworkConstruction Construct<T>()
            where T : FrameworkConstruction, new()
        {
            var construction = new T();

            return construction;
        }


        public static FrameworkConstruction Construct<T>(T constructionInstance)
           where T : FrameworkConstruction
        {
            var construction = constructionInstance;

            return construction;
        }
    }
}
