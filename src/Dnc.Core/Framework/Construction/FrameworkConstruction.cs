using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dnc
{
    public class FrameworkConstruction
    {
        #region Public memebers.

        public IServiceCollection Services { get; set; }
        public IConfiguration Configuration { get; set; }
        public IFrameworkEnvironment Environment { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        #endregion

        #region Default ctor.
        public FrameworkConstruction()
        {
            Services = new ServiceCollection();
            Environment = new FrameworkEnvironment();
            Services.AddSingleton(sp => Environment);

            this.Configure()
                .UseDefaultLogger();

            Services.AddAssemblyPluginTypes();
        }
        #endregion

        /// <summary>
        /// The entrypoint for the framework.
        /// </summary>
        public FrameworkConstruction Build(IServiceProvider provider = null)
        {
            ServiceProvider = provider ?? Services.BuildServiceProvider();

            return this;
        }


        /// <summary>
        /// Use hosted services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public FrameworkConstruction UseHostedServices(IServiceCollection services)
        {
            Services = services;

            return this;
        }


        /// <summary>
        /// Use configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public FrameworkConstruction UseConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;

            return this;
        }
    }
}
