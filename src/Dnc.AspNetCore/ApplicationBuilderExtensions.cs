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
        public static IApplicationBuilder UseDncCoreAPI(this IApplicationBuilder app)
        {
            app.UseLogDashboard();
            app.UseSwaggerAPIDoc();
            app.UseMvc();
            return app;
        }
    }
}
