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
        public static event Action<Exception> ExceptionThrownEvent;

        public static void Build(this FrameworkConstruction construction, bool logStarted = true)
        {
            construction.ConfigureBuild(fxConstruction => fxConstruction.Services.BuildServiceProvider());
        }


        public static FrameworkConstruction Construct<T>()
            where T : FrameworkConstruction, new()
        {
            try
            {
                Construction = new T();

                Construction.Configure()
                            .UseDefaultLogger();
                Construction.Services.AddMemoryCache();
                Construction.Services.AddAssemblyPluginTypes();
            }
            catch (Exception ex)
            {
                ExceptionThrownEvent?.Invoke(ex);
            }

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
            try
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
            catch (Exception ex)
            {
                ExceptionThrownEvent?.Invoke(ex);
            }
        }

        public static T Resolve<T>() => ServiceProvider.GetRequiredService<T>();
    }
}
