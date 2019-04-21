using Dnc.Dispatcher;
using Dnc.Spiders;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dnc
{
    public static class SpiderExtensions
    {
        /// <summary>
        /// Configures framework use default spider ,get it from a <see cref="ISpider"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <param name="configurePipelineProcessor"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseDefaultSpider(this FrameworkConstruction construction,
            Action<IServiceCollection> configurePipelineProcessor)
        {
            if (configurePipelineProcessor == null)
                throw new ArgumentNullException(nameof(configurePipelineProcessor));

            configurePipelineProcessor?.Invoke(construction.Services);
            construction.UseAgentPool();//based on agent getter.
            construction.Services.AddSingleton<IUrlManager, MemoryUrlManager>();
            construction.Services.AddSingleton<ISpider, DefaultSpider>();
            return construction;
        }

        /// <summary>
        /// Configures  framework use agent getter,get it from a <see cref="IAgentGetter"/> & a <see cref="IAgentPool"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseAgentPool(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IHtmlParser, AngleSharpHtmlParser>();
            construction.Services.AddSingleton<IHtmlDownloader, PuppeteerHtmlDownloader>();
            construction.Services.AddSingleton<IAgentGetter, XiCiAgentGetter>();
            construction.Services.AddSingleton<IAgentPool, MemoryAgentPool>();

            return construction;
        }
    }
}