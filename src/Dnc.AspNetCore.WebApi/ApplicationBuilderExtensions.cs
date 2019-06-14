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
        public static IApplicationBuilder UseAspNetCore(this IApplicationBuilder app,double versionNo=1)
        {
            app.UseAuthentication();
            app.UseSwaggerAPIDoc(versionNo);
            app.UseMvc();
            return app;
        }
    }
}
