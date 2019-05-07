using LogDashboard;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
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
            app.UseLogDashboard();
            app.UseAuthentication();
            if (aspNetCoreType== AspNetCoreType.Api)
            {
                app.UseSwaggerAPIDoc();
                app.UseMvc();
            }
            else
            {
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                       name: "static",
                       template: "{area}/{controller=Home}-{action=Index}.html");
                    routes.MapRoute(
                        name: "area",
                        template: "{area}/{controller=Home}/{action=Index}/{id?}");
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
            return app;
        }
    }
}
