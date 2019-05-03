using Dnc.AspNetCore.Filters;
using LogDashboard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// apidoc,api versioning,global log exception filter,log dashboard "/logdashboard".
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDncCoreAPI(this IServiceCollection services)
        {
            services.AddSwaggerAPIDoc();
            services.AddAPIVersion();
            services.AddLogDashboard();
            services.AddMvc(opt =>
            {
                opt.Filters.Add<APIGlobalLogExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return services;
        }
    }
}
