using AspNetCore.ApiDoc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dnc.AspNetCore
{
    public static class DocsExtensions
    {

        /// <summary>
        /// Default path=v1/apidoc
        /// </summary>
        /// <param name="services"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static IServiceCollection AddAPIDoc(this IServiceCollection services, string title = "API文档", string version = "v1")
        {
            services.AddApiDoc(t =>
            {
                t.ApiDocPath = $"{version}/apidoc";
                t.Title = title;
                t.SummaryType = SummaryType.Html;
                t.Summary = $"{title}摘要";
            });
            return services;
        }

        /// <summary>
        /// project property xml generator 【apidoc{version}.xml】.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="title"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerAPIDoc(this IServiceCollection services, string title = "API文档", string version = "v1")
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = title,
                    Version = "v1",
                });

                var basePath =PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath,$"apidoc{version}.xml");
                c.IncludeXmlComments(xmlPath);

            });
            return services;
        }


        public static IApplicationBuilder UseSwaggerAPIDoc(this IApplicationBuilder app,string version="v1")
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.ShowExtensions();
                c.EnableValidator();
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json",$"{version}/apidoc");
            });
            return app;
        }
    }
}
