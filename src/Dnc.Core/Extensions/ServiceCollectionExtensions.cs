using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
