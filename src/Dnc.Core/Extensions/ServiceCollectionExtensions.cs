using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dnc.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAssemblyTypes(this IServiceCollection services, Type type)
        {
            var libs = type.GetDependencyAssemblies();

            foreach (var lib in libs)
            {
                var assemblyName = lib.GetName().Name;
                var interfaces = assemblyName.GetAssemblyInterfaces();
                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, assemblyName.GetImplementType(@interface));
                }
            }
            return services;
        }

        public static IServiceCollection UseAutofac(this IServiceCollection services)
        {

            return services;
        }
    }
}
