using Microsoft.AspNetCore.Builder;

namespace Dnc.AspNetCore.Web
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
        public static IApplicationBuilder UseAspNetCore(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "static_areas", template: "{area:exists}/{controller=Home}-{action=Index}.html");

                routes.MapRoute(name: "static", template: "{controller=Home}-{action=Index}.html");

                routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name: "custom", template: "{area:exists}_{controller=Home}_{action=Index}.{id?}");//Custom route template.
                });
            return app;
        }
    }
}
