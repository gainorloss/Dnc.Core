using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Dnc.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DncAspNetCore.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = "Cookies";
                opt.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies", opt => opt.AccessDeniedPath = "/Authorization/AccessDenied")
            .AddOpenIdConnect("oidc", opt =>
            {
                opt.ClientId = "site";
                opt.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
                opt.SignInScheme = "Cookies";
                opt.SaveTokens = true;
                opt.RequireHttpsMetadata = false;
                opt.ResponseType = "code id_token";
                opt.Authority = "http://localhost:8001";
                opt.Scope.Clear();
                opt.Scope.Add("openid");
                opt.Scope.Add("profile");
                opt.Scope.Add("email");
                opt.Scope.Add("restapi");
                opt.GetClaimsFromUserInfoEndpoint = true;
            });
            //services.AddAspNetCore(typeof(Startup), AspNetCoreType.Mvc);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAspNetCore(AspNetCoreType.Mvc);
        }
    }
}
