using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Dnc.Extensions
{
    public static class RuntimeExtensions
    {
        public static IEnumerable<Type> GetAssemblyInterfaces(this string name)
        {
            var assembly = name.GetAssemblyByName();
            var intefaces = assembly.DefinedTypes.Where(t => t.IsInterface);
            return intefaces;
        }

        public static Type GetImplementType(this string name, Type intefaceType)
        {
            var assembly = name.GetAssemblyByName();
            if (assembly == null)
                return null;
            var implType = assembly.GetTypes().FirstOrDefault(t => t.GetInterface(intefaceType.Name) != null);
            return implType;
        }

        public static Assembly GetAssemblyByName(this string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("message", nameof(name));

            return AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(name));
        }

        public static IEnumerable<Assembly> GetDependencyAssemblies(this Type type)
        {
            var libs = DependencyContext.Default.CompileLibraries.Where(lib=>!lib.Type.Equals("package"));
            var assemblies = libs
               .Select(lib => lib.Name.GetAssemblyByName())
               .ToList();
            return assemblies;
        }
    }
}
