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
                routes.MapRoute(name: "static_areas", template: "{area:exists:slugify}/{controller:slugify=Home}-{action=Index}.html");

                routes.MapRoute(name: "static", template: "{controller:slugify=Home}-{action:slugify=Index}.html");

                routes.MapRoute(name: "areas", template: "{area:exists:slugify}/{controller:slugify=Home}/{action:slugify=Index}/{id?}");

                routes.MapRoute(name: "default", template: "{controller:slugify=Home}/{action:slugify=Index}/{id?}");

                routes.MapRoute(name: "custom", template: "{area:exists:slugify}_{controller:slugify=Home}_{action:slugify=Index}.{id?}");//Custom route template.
                });
            return app;
        }
    }
}
