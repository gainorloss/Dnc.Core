using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Dnc.AspNetCore.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCore<TType>(this IServiceCollection services,
            string authorityUrl,
            string appName = null,
            string appSecret = null)
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

            //routint url+querystring lowercase.
            services.AddRouting(opt =>
            {
                opt.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
                opt.LowercaseUrls = true;
                opt.LowercaseQueryStrings = true;
            });
            services
                .AddMvc(opt =>
            {
                opt.Filters.Add<MvcGlobalLogExceptionFilter>();
                //opt.Filters.Add<MvcGlobalLoginAuthorizationFilter>();
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

            return services;
        }
    }
}
