using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dnc.AspNetCore.Controllers;
using Dnc.AspNetCore.Filters;
using Dnc.Biz.Admin;
using FluentValidation.AspNetCore;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Loader;

namespace Dnc.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// <para>Api:"apidoc,api versioning,global log exception filter" </para>
        /// <para>Mvc:"httpcontext accessor,
        /// cookie authentication(
        /// login=>【/AccountArea/Account/SignIn】,
        /// logout=>【/AccountArea/Account/SignOutAsync】,
        /// cookie name=>【.Dnc.AspNetCore】,
        /// schema=>Cookies)".
        /// </para> 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider AddAspNetCore<TType>(this IServiceCollection services, 
            string authorityUrl,
            string appName=null,
            string appSecret=null,
            AspNetCoreType aspNetCoreType = AspNetCoreType.Api)
        {
            if (aspNetCoreType == AspNetCoreType.Api)
            {
                services.AddSwaggerAPIDoc();//api doc.
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
            }
            else
            {
                #region cookie(obsolete).
                //authentication cookie.
                //  services
                //      .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                //      .AddCookie(opt =>
                //{
                //    opt.LoginPath = "/AccountArea/Account/SignIn";
                //    opt.LogoutPath = "/AccountArea/Account/SignOutAsync";
                //    opt.Cookie.Path = "/";
                //    opt.Cookie = new CookieBuilder()
                //    {
                //        Name = ".Dnc.AspNetCore"
                //    };
                //}); 
                #endregion

                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

                services.AddAuthentication(opt =>
                {
                    opt.DefaultScheme = "Cookies";
                    opt.DefaultChallengeScheme = "oidc";
                }).AddCookie("Cookies", opt => opt.AccessDeniedPath = "/Authorization/AccessDenied")
                .AddOpenIdConnect("oidc", opt =>
                {
                    opt.ClientId = appName;
                    opt.ClientSecret = appSecret;
                    opt.SignInScheme = "Cookies";
                    opt.SaveTokens = true;
                    opt.RequireHttpsMetadata = false;
                    opt.ResponseType = "code id_token";
                    opt.Authority = authorityUrl;
                    opt.Scope.Clear();
                    opt.Scope.Add("openid");
                    opt.Scope.Add("profile");
                    opt.Scope.Add("email");
                    opt.Scope.Add("restapi");
                    opt.GetClaimsFromUserInfoEndpoint = true;
                });
                services.AddHttpContextAccessor();//httpcontext accessor.
            }

            services
                .AddMvc(opt =>
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

            return services.GetAutofacServiceProvider(typeof(TType));//autofac.
        }

        /// <summary>
        /// <para>Registers the given admin db context as a service in the <see cref="IServiceCollection"/>.</para>
        /// <para>Registers a default scoped <see cref="ISysUserManager"/> as a service in the <see cref="IServiceCollection"/>.</para>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAdmin<TAdminDbContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null)
            where TAdminDbContext : AdminDbContext
        {
            services.AddDbContext<TAdminDbContext>(optionsAction);
            services.AddScoped<ISysUserManager, SysUserManager>();
            return services;
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
