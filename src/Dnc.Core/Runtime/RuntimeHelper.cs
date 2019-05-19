using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dnc
{
    public static class RuntimeHelper
    {
        public static IEnumerable<Type> GetAssemblyPluginInterfaces()
        {
            return GetAssemblyInterfaces().Where(t => t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IPlugin)));
        }

        public static IEnumerable<Type> GetAssemblyInterfaces()
        {
            var interfaces = new List<Type>();
            foreach (var lib in GetDependencyAssemblies())
            {
                var assemblyName = lib.GetName().Name;
                var interfacesFromAssembly = assemblyName.GetAssemblyByName().DefinedTypes.Where(t => t.IsInterface);
                interfaces.AddRange(interfacesFromAssembly);
            }
            return interfaces;
        }

        public static IEnumerable<Assembly> GetDependencyAssemblies()
        {
            var libs = DependencyContext.Default.CompileLibraries.Where(lib => !lib.Type.Equals("package"));
            var assemblies = libs
               .Select(lib => lib.Name.GetAssemblyByName())
               .ToList();
            return assemblies;
        }
    }
}
