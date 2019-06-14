using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Panda.DynamicWebApi;
using System;
using System.Linq;
using System.Runtime.Loader;

namespace Dnc.AspNetCore.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider AddAspNetCore<TType>(this IServiceCollection services,
            string authorityUrl,
            string appName = null,
            string appSecret = null,
            double versionNo = 1)
        {
            services.AddOptions();
            services.AddAPIVersion();//api version.

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(factory =>
            {
                var actionContext = factory.GetService<IActionContextAccessor>()
                                        .ActionContext;
                return new UrlHelper(actionContext);
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(opt =>
            {
                opt.Authority = authorityUrl;
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.ApiName = appName;
            });

            services
                .AddMvc(opt =>
            {
                opt.Filters.Add<ApiGlobalLogExceptionFilter>();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt => opt.UseCamelCasing(true))
                .AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssembly(typeof(TType).Assembly);
                cfg.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });//fluent validation.

            #region 永远不要相信用户输入
            //关闭默认的ApiBehavior
            services.Configure<ApiBehaviorOptions>(option =>
            {
                //使用自己的模型验证返回数据          
                option.InvalidModelStateResponseFactory = (action =>
                {
                    var errMessages = action.ModelState.Values.SelectMany(v => v.Errors).Select(g => g.ErrorMessage).Aggregate((i, next) => $"{i}【>_<】{next}");
                    return new UnprocessableEntityObjectResult(new AjaxResult(false, HttpStatusCodes.BadRequest, errMessages));
                });
            });
            #endregion

            services.AddDynamicWebApi();
            services.AddSwaggerAPIDoc(appName, versionNo);//api doc+ app doc.

            return services.GetAutofacServiceProvider(typeof(TType));//autofac.
        }

        /// <summary>
        /// Use autofac to replace default container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceProvider GetAutofacServiceProvider(this IServiceCollection services, Type type)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);

            var context = AssemblyLoadContext.Default;
            var assemblies = type.Assembly.GetReferencedAssemblies()
                .Select(name => context.LoadFromAssemblyName(name)).ToList();
            assemblies.Add(type.Assembly);

            builder.RegisterAssemblyTypes(assemblies.ToArray())//get assembly ends with some keywords.
               .Where(t => t.Name.EndsWith("UnitWork")
                       || t.Name.EndsWith("Repository")
                       || t.Name.EndsWith("CmdHandler")
                       || t.Name.EndsWith("Service")
                       || t.Name.EndsWith("DomainEventHandler")
                       || t.Name.EndsWith("IntegrationEventHandler")
                       || t.Name.EndsWith("Queries", StringComparison.OrdinalIgnoreCase))
               .AsImplementedInterfaces();//as interface

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
