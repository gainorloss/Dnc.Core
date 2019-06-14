using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace Dnc.AspNetCore.WebApi
{
    public static class DocsExtensions
    {
        /// <summary>
        /// project property xml generator 【apidoc{version}.xml】.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="n"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        internal static IServiceCollection AddSwaggerAPIDoc(this IServiceCollection services, string n = null, double v = 1)
        {
            var title = string.IsNullOrWhiteSpace(n)? "开放平台API文档":$"{n} 开放平台API文档";
            var version = $"v{v}";

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(version, new Swashbuckle.AspNetCore.Swagger.Info() { Title = title, Version = version });
                options.DocInclusionPredicate((docName, description) => true);

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                var apiXmlPath = Path.Combine(basePath, $"apidoc{version}.xml");
                options.IncludeXmlComments(apiXmlPath);

                var appXmlPath = Path.Combine(basePath, $"appdoc{version}.xml");
                options.IncludeXmlComments(appXmlPath);
            });
            return services;
        }

        internal static IApplicationBuilder UseSwaggerAPIDoc(this IApplicationBuilder app, double v = 1)
        {
            var version = $"v{v}";

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.ShowExtensions();
                c.EnableValidator();
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}/apidoc");
            });
            return app;
        }
    }
}
