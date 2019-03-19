using Microsoft.AspNetCore.Hosting;

namespace Dnc.AspNetCore
{

    /// <summary>
    /// Extension methods for <see cref="IWebHostBuilder"/>
    /// </summary>
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UseDncCore(this IWebHostBuilder builder)
        {
            var construction = Framework.Construct<FrameworkConstruction>();
            builder.ConfigureServices((context, services) =>
            {
                services = construction.Services;
            });
            return builder;
        }
    }
}
