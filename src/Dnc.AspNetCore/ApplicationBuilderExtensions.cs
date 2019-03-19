using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
namespace Dnc.AspNetCore
{
    /// <summary>
    /// Extension methods for <see cref=""/>
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDncCore(this IApplicationBuilder app)
        {
            Framework.Construction.Build(app.ApplicationServices);
            return app;
        }
    }
}
