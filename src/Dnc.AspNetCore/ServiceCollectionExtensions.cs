using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dnc.AspNetCore.Controllers;
using Dnc.AspNetCore.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Runtime.Loader;

namespace Dnc.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// apidoc,api versioning,global log exception filter,log dashboard "/logdashboard".
        /// mvc cookie authentication:login【/AccountArea/Account/SignIn】
        /// logout:【/AccountArea/Account/SignOutAsync】
        /// cookie name:【.Dnc.AspNetCore】
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider AddAspNetCore(this IServiceCollection services, Type type, AspNetCoreType aspNetCoreType = AspNetCoreType.Api)
        {
            if (aspNetCoreType == AspNetCoreType.Api)
            {
                services.AddSwaggerAPIDoc();
                services.AddAPIVersion();
            }
            else
            {
                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(opt =>
              {
                  opt.LoginPath = "/AccountArea/Account/SignIn";
                  opt.LogoutPath = "/AccountArea/Account/SignOutAsync";
                  opt.Cookie.Path = "/";
                  opt.Cookie = new CookieBuilder()
                  {
                      Name = ".Dnc.AspNetCore"
                  };
              }); ;
            }

            services.AddMvc(opt =>
            {
                if (aspNetCoreType == AspNetCoreType.Api)
                {
                    opt.Filters.Add<ApiGlobalLogExceptionFilter>();
                }
                else
                {
                    opt.Filters.Add<MvcGlobalLogExceptionFilter>();
                    opt.Filters.Add<MvcGlobalLoginAuthorizationFilter>();
                }
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssembly(type.Assembly);
                cfg.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            #region 永远不要相信用户输入
            //关闭默认的ApiBehavior
            services.Configure<ApiBehaviorOptions>(option =>
            {
                //使用自己的模型验证返回数据          
                option.InvalidModelStateResponseFactory = (action =>
                {
                    var errMessages = action.ModelState.Values.SelectMany(v => v.Errors).Select(g => g.ErrorMessage).Aggregate((i, next) => $"{i}【>_<】{next}");
                    return new BadRequestObjectResult(new AjaxResult(false, HttpStatusCodes.BadRequest, errMessages));
                });
            });
            #endregion

            return services.GetAutofacServiceProvider(type);
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
