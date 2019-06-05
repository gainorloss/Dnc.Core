using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Dnc
{
    public static class RuntimeExtension
    {
        public static Type GetImplementType(this Type intefaceType)
        {
            foreach (var lib in RuntimeHelper.GetDependencyAssemblies())
            {
                if (lib.GetTypes().Any(t => !t.IsInterface && !t.IsAbstract && intefaceType.IsAssignableFrom(t)))
                    return lib.GetTypes().FirstOrDefault(t => !t.IsInterface && !t.IsAbstract && intefaceType.IsAssignableFrom(t));
            }
            return null;
        }

        public static Assembly GetAssemblyByName(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("message", nameof(name));

            return AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(name));
        }
    }
}
