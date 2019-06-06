using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Dnc
{
    public static class RuntimeExtension
    {
        public static IEnumerable<Type> GetImplementType(this Type intefaceType)
        {
            var types = new List<Type>();
            foreach (var lib in RuntimeHelper.GetDependencyAssemblies())
            {
                if (lib.GetTypes().Any(t => !t.IsInterface && !t.IsAbstract && intefaceType.IsAssignableFrom(t)))
                {
                    var implementTypes = lib.GetTypes().Where(t => !t.IsInterface && !t.IsAbstract && intefaceType.IsAssignableFrom(t));
                    types.AddRange(implementTypes);
                }
            }
            return types;
        }

        public static Assembly GetAssemblyByName(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("message", nameof(name));

            return AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(name));
        }
    }
}
