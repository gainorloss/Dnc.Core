using Microsoft.AspNetCore.Builder;

namespace Dnc.AspNetCore.WebApi
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
            app.UseSwaggerAPIDoc();
            app.UseMvc();
            return app;
        }
    }
}
