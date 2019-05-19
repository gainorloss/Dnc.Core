using Dnc.Compilers;
using Dnc.Dispatcher;
using Dnc.Files;
using Dnc.Rpc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace Dnc
{
    /// <summary>
    /// Extension methods from framework.
    /// </summary>
    public static class FrameworkExtensions
    {
        public static IServiceCollection AddDefaultLogger(this IServiceCollection services)
        {
            services.AddTransient(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("dnc"));
            return services;
        }

        public static FrameworkConstruction Configure(this FrameworkConstruction construction,
            Action<IConfigurationBuilder> configure = null)
        {

            var configurationBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{construction.Environment.Environment}.json", true, true);
            configure?.Invoke(configurationBuilder);

            var configuration = configurationBuilder.Build();
            construction.Services.AddSingleton<IConfiguration>(configuration);

            construction.Configuration = configuration;
            return construction;
        }

        #region Configure default logger.
        public static FrameworkConstruction UseDefaultLogger(this FrameworkConstruction construction)
        {
            #region Serilog settings.
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File(Path.Combine("logs", "log.txt"),
                     rollingInterval: RollingInterval.Day,
                     rollOnFileSizeLimit: true)
                    .CreateLogger();
            #endregion

            construction.Services.AddLogging(opt =>
            {
                opt.AddConfiguration(construction.Configuration?.GetSection("Logging"));
                opt.AddSerilog(Log.Logger);
            });

            construction.Services.AddTransient(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("dnc"));
            return construction;
        }
        #endregion

        #region Configure schedule center.
        public static FrameworkConstruction UseScheduleCenter(this FrameworkConstruction construction)
        {
            var scheduleCenter = new ScheduleCenter();

            construction.ScheduleCenter = scheduleCenter;

            construction.Services.AddSingleton(scheduleCenter);

            return construction;
        }

        #endregion

        #region Configure rpc.
        public static FrameworkConstruction UseDefaultRpc(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IRpcServer, GrpcServer>();
            construction.Services.AddSingleton<IRpcClient, GrpcClient>();

            return construction;
        }
        #endregion

        #region Configure compiler.
        public static FrameworkConstruction UseDefaultCompiler(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<ICompiler, RoslynCompiler>();

            return construction;
        }
        #endregion

        #region Configure downloader.
        public static FrameworkConstruction UseDownloader(this FrameworkConstruction construction)
        {
            construction.Services.AddScoped<IDownloader, FileDownloader>();

            return construction;
        }
        #endregion

    }
}
