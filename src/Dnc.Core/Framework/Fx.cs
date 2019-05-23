using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Dnc
{
    public static class Fx
    {
        public static FrameworkConstruction Construction { get; private set; }


        private static IServiceProvider ServiceProvider { get; set; }


        public static event Action<IServiceCollection> SrvRegisteredEvent;

        public static void Build(this FrameworkConstruction construction, bool logStarted = true)
        {
            SrvRegisteredEvent?.Invoke(construction.Services);

            if (construction.Services == null)
                throw new Exception("ServiceCollection is null.");

            ServiceProvider = construction.Services.BuildServiceProvider();

            if (logStarted)
            {
                var logger = ServiceProvider.GetService<ILogger>();
                var env = ServiceProvider.GetService<IFrameworkEnvironment>();

                logger.LogCritical($"Dnc core  started in {env.Environment}...");
            }
        }


        public static FrameworkConstruction Construct<T>()
            where T : FrameworkConstruction, new()
        {
            Construction = new T();

            return Construction;
        }


        public static FrameworkConstruction Construct<T>(T constructionInstance)
           where T : FrameworkConstruction
        {
            Construction = constructionInstance;

            return Construction;
        }

        public static T Resolve<T>() => ServiceProvider.GetRequiredService<T>();
    }
}
