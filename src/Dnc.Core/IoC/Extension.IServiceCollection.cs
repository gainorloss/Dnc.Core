using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Dnc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAssemblyTypes(this IServiceCollection services)
        {
            var interfaces = RuntimeHelper.GetAssemblyInterfaces();

            foreach (var @interface in interfaces)
            {
                var implementType = @interface.GetImplementType();
                if (implementType == null)
                    continue;
                services.AddScoped(@interface, implementType);
            }

            return services;
        }
        internal static IServiceCollection AddAssemblyPluginTypes(this IServiceCollection services)
        {
            var interfaces = RuntimeHelper.GetAssemblyPluginInterfaces();

            foreach (var @interface in interfaces)
            {
                var implementType = @interface.GetImplementType();
                if (implementType == null)
                    continue;

                if (typeof(IPluginInitializer).IsAssignableFrom(implementType))
                {
                    var pluginInitializer = (IPluginInitializer)Activator.CreateInstance(implementType);
                    if (pluginInitializer != null)
                        pluginInitializer.ConfigureServices(services);
                    continue;
                }
                services.AddScoped(@interface, implementType);
            }
            return services;
        }
    }
}
