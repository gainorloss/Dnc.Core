using Dnc.Dispatcher;
using Dnc.Spiders;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dnc
{
    public static class SpiderExtensions
    {
        /// <summary>
        /// Configures  framework use agent getter,get it from a <see cref="IAgentPool"/> & a <see cref="IAgentGetter"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseMemoryAgentPool(this FrameworkConstruction construction)
        {
            construction.UseAgentGetter();
            construction.Services.AddSingleton<IAgentPool, MemoryAgentPool>();
            return construction;
        }

        /// <summary>
        /// Configures  framework use agent getter,get it from a <see cref="IAgentPool"/>  & a <see cref="IAgentGetter"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseRedisAgentPool(this FrameworkConstruction construction)
        {
            construction.UseAgentGetter();
            construction.Services.AddSingleton<IAgentPool, RedisAgentPool>();
            return construction;
        }

        /// <summary>
        /// Configures  framework use agent getter,get it from a <see cref="IHtmlDownloader"/> & a <see cref="IHtmlParser"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UsePuppeteerHtmlDownloader(this FrameworkConstruction construction)
        {
            construction.UseHtmlParser();
            construction.Services.AddSingleton<IHtmlDownloader, PuppeteerHtmlDownloader>();
            return construction;
        }

        /// <summary>
        /// Configures  framework use agent getter,get it from a <see cref="IHtmlDownloader"/> & a <see cref="IHtmlParser"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseHttpRequestHtmlDownloader(this FrameworkConstruction construction)
        {
            construction.UseHtmlParser();
            construction.Services.AddSingleton<IHtmlDownloader,HttpRequestHtmlDownloader>();
            return construction;
        }

        /// <summary>
        /// Configures  framework use agent getter,get it from a <see cref="IAgentGetter"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        internal static FrameworkConstruction UseAgentGetter(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IAgentGetter, XiCiAgentGetter>();
            return construction;
        }

        /// <summary>
        /// Configures  framework use agent getter,get it from a <see cref="IAgentGetter"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        internal static FrameworkConstruction UseHtmlParser(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IHtmlParser, AngleSharpHtmlParser>();
            return construction;
        }
    }
}