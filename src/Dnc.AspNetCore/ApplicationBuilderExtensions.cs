using Dnc.AspNetCore.Filters;
using Dnc.Data;
using Dnc.Seedwork;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dnc.AspNetCore
{
    /// <summary>
    /// Extension methods for <see cref="IApplicationBuilder"/>.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure AspnetCore using Dnc.Core.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAspNetCore(this IApplicationBuilder app, AspNetCoreType aspNetCoreType = AspNetCoreType.Api)
        {
            app.UseAuthentication();
            if (aspNetCoreType == AspNetCoreType.Api)
            {
                app.UseSwaggerAPIDoc();
                app.UseMvc();
            }
            else
            {
                app.UseMvc(routes =>
                {
                    routes.MapRoute(name: "static_areas", template: "{area:exists}/{controller=Home}-{action=Index}.html");

                    routes.MapRoute(name: "static", template: "{controller=Home}-{action=Index}.html");

                    routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

                    routes.MapRoute(name: "custom", template: "{area:exists}_{controller=Home}_{action=Index}.{id?}");//Custom route template.
                });

            }
            return app;
        }

        /// <summary>
        /// Configure AspnetCore using Dnc.Core.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAdmin<TAdminDbContext>(this IApplicationBuilder app)
            where TAdminDbContext: AbstractAdminDbContext
        {
            var sp = app.ApplicationServices;
            var ctx = sp.GetRequiredService<AbstractAdminDbContext>();

            var resources = new List<SysResource>();

            var assembly = typeof(TAdminDbContext).Assembly;
            var ctrlTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase));
            if (ctrlTypes == null || !ctrlTypes.Any())
                throw new Exception($"There is no any controllers in the current project.");
            foreach (var ctrlType in ctrlTypes)
            {
                var attrs = ctrlType.GetCustomAttributes(typeof(FunctionAttribute), false);
                if (attrs == null || attrs.Any())
                    continue;
                var attr = attrs.FirstOrDefault() as FunctionAttribute;
                var father = new SysResource(attr.Name, attr.IsMenu, attr.CssClass, $"{ctrlType.Namespace}.{ctrlType.Name}", attr.Father);
                resources.Add(father);

                var members = ctrlType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
                if (members == null || !members.Any())
                    throw new Exception($"There is no any actions in the controll {father.Resource}.");
                foreach (var member in members)
                {
                    var funcAttr = member.GetCustomAttribute(typeof(FunctionAttribute), false);
                    if (funcAttr == null)
                        continue;
                    var func = funcAttr as FunctionAttribute;
                    var resource = new SysResource(func.Name,
                        func.IsMenu,
                        func.CssClass,
                        $"{father.Resource}.{member.Name}",
                        func.Father ?? father.Resource);
                    resources.Add(resource);
                }
            }

            ctx.SysResource.AddRange(resources);
            ctx.SaveChanges();
            return app;
        }
    }
}
