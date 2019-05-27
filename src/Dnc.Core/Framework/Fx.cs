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
            construction.ConfigureBuild(fxConstruction=> fxConstruction.Services.BuildServiceProvider());
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

        public static FrameworkConstruction CreateDefaultConstruction()
        {
            Construct<FrameworkConstruction>();
            return Construction;
        }

        public static void ConfigureBuild(this FrameworkConstruction construction, 
            Func<FrameworkConstruction, IServiceProvider> serviceProviderFactory = null,
            bool logStarted = true)
        {
            SrvRegisteredEvent?.Invoke(construction.Services);

            if (construction.Services == null)
                throw new Exception("ServiceCollection is null.");

            ServiceProvider = serviceProviderFactory.Invoke(construction);

            if (logStarted)
            {
                var logger = ServiceProvider.GetService<ILogger>();
                var env = ServiceProvider.GetService<IFrameworkEnvironment>();

                logger.LogCritical($"Dnc core  started in {env.Environment}...");
            }
        }

        public static T Resolve<T>() => ServiceProvider.GetRequiredService<T>();
    }
}
