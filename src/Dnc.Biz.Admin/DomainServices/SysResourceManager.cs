using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dnc.Biz.Admin
{
    public class SysResourceManager
        : ISysResourceManager
    {
        public IEnumerable<SysResource> GetAll<TStartup>()
            where TStartup : IStartup
        {
            var resources = new List<SysResource>();
            var assembly = typeof(TStartup).Assembly;
            var ctrlTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase));
            if (ctrlTypes == null || !ctrlTypes.Any())
                throw new Exception($"There is no any controllers in the current project.");
            foreach (var ctrlType in ctrlTypes)
            {
                var attrs = ctrlType.GetCustomAttributes(typeof(ResourceAttribute), false);
                if (attrs == null || attrs.Any())
                    continue;
                var attr = attrs.FirstOrDefault() as ResourceAttribute;
                var father = new SysResource(attr.Name, attr.IsMenu, attr.CssClass, $"{ctrlType.Namespace}.{ctrlType.Name}", attr.Father);
                resources.Add(father);

                var members = ctrlType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
                if (members == null || !members.Any())
                    throw new Exception($"There is no any actions in the controll {father.Resource}.");
                foreach (var member in members)
                {
                    var funcAttr = member.GetCustomAttribute(typeof(ResourceAttribute), false);
                    if (funcAttr == null)
                        continue;
                    var func = funcAttr as ResourceAttribute;
                    var resource = new SysResource(func.Name,
                        func.IsMenu,
                        func.CssClass,
                        $"{father.Resource}.{member.Name}",
                        func.Father ?? father.Resource);
                    resources.Add(resource);
                }
            }
            return resources;
        }
    }
}
