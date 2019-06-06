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
                var implementType = @interface.GetImplementType().FirstOrDefault();
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
                if (@interface == typeof(IPlugin))
                    continue;

                var implementTypes = @interface.GetImplementType();

                if (@interface == typeof(IPluginInitializer))
                {
                    foreach (var item in implementTypes)
                    {
                        var pluginInitializer = (IPluginInitializer)Activator.CreateInstance(item);
                        if (pluginInitializer == null)
                            continue;
                        pluginInitializer.ConfigureServices(services);
                    }
                    continue;
                }
                var implementType = implementTypes.FirstOrDefault();
                if (implementType == null)
                    continue;
                services.AddScoped(@interface, implementType);
            }
            return services;
        }
    }
}
