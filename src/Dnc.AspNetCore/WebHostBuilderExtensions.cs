using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Dnc.AspNetCore
{

    /// <summary>
    /// Extension methods for <see cref="IWebHostBuilder"/>
    /// </summary>
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// Configure services in <see cref="Dnc"/> can be used in AspnetCore.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseDncCore(this IWebHostBuilder builder)
        {
            var construction = Framework.Construct<DefaultFrameworkConstruction>();
            builder.ConfigureServices((context, services) =>
            {
                foreach (var service in construction.Services)
                {
                    services.Add(service);
                }
            });
            return builder;
        }
    }
}
