using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Dnc.AspNetCore
{

    /// <summary>
    /// Extension methods for <see cref="IWebHostBuilder"/>
    /// </summary>
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// Configure services in <see cref="Dnc"/> can be used in AspnetCore and remove AspnetCore default logger providers.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseCore(this IWebHostBuilder builder, Action<FrameworkConstruction> configureConstruction = null)
        {
            var construction = Framework.Construct<DefaultFrameworkConstruction>();
            configureConstruction?.Invoke(construction);
            builder.ConfigureServices((context, services) =>
            {
                services
                .Where(s => s.ServiceType == typeof(ILoggerProvider))
                .ToList()
                .ForEach(i => services.Remove(i));

                foreach (var service in construction.Services)
                {
                    services.Add(service);
                }
            });
            return builder;
        }
    }
}
