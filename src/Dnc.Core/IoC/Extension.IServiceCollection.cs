using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dnc
{
    public static class Extension
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
                services.AddScoped(@interface, implementType);
            }

            return services;
        }
    }
}
