using Dnc.Dispatcher;
using Dnc.Serializers;
using Dnc.Spiders;
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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine("logs", "log.txt"),
                 rollingInterval: RollingInterval.Day,
                 rollOnFileSizeLimit: true)
                .CreateLogger();

            construction.Services.AddLogging(opt =>
            {
                opt.AddConfiguration(construction.Configuration?.GetSection("Logging"));
                //opt.AddConsole();
                //opt.AddDebug();
                opt.AddSerilog();
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

        #region Configure serializer.
        public static FrameworkConstruction UseDefaultSerializer(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IMessageSerializer, NewtonsoftJsonSerializer>();

            return construction;
        }


        public static FrameworkConstruction UseSerializer<T>(this FrameworkConstruction construction,
             Func<IServiceCollection, IMessageSerializer> configureMessageSerializer = null)
        {
            var serializer = configureMessageSerializer.Invoke(construction.Services);
            construction.Services.AddSingleton<IMessageSerializer>(serializer);

            return construction;
        }
        #endregion

        #region Configure spider.
        public static FrameworkConstruction UseDefaultSpider(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IHtmlParser, AngleSharpHtmlParser>();
            construction.Services.AddSingleton<ISpider, PuppeteerSpider>();

            return construction;
        }


        public static FrameworkConstruction UseSpider<T>(this FrameworkConstruction construction,
            Func<IServiceCollection, ISpider> configureSpider = null)
           where T : class, ISpider
        {
            var spider = configureSpider.Invoke(construction.Services);
            construction.Services.AddSingleton(spider);

            return construction;
        }
        #endregion
    }
}
