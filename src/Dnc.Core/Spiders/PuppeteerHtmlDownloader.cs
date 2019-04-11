using AngleSharp.Dom;
using Dnc.Core.Spiders.Abstractions;
using Dnc.Spiders;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class PuppeteerHtmlDownloader
        :IHtmlDownloader
    {
        #region Private member.
        private readonly IHtmlParser _htmlParser;
        #endregion

        #region Static ctor.
        static PuppeteerHtmlDownloader()
        {
            new BrowserFetcher()
               .DownloadAsync(BrowserFetcher.DefaultRevision)
               .ConfigureAwait(false)
               .GetAwaiter();
        }
        #endregion

        #region Default ctor.
        public PuppeteerHtmlDownloader(IHtmlParser htmlParser)
        {
            _htmlParser = htmlParser;
        }
        #endregion

        #region Methods for getting item.
        public async Task<IEnumerable<T>> GetItemsAsync<T>(string url,
           string selectors,
           Func<IElement, T> buildItemFunc)
           where T : class, ISpiderItem, new()
        {
            var html = await GetHtmlContentUsingPuppeteerAsync(url);
            var elements = await _htmlParser.GetElementsAsync(html, selectors);

            var items = new List<T>();

            foreach (var ele in elements)
            {
                var item = buildItemFunc.Invoke(ele);
                items.Add(item);
            }
            return items;
        }


        public async Task<T> GetItemAsync<T>(string url,
            string selector,
            Func<IElement, T> buildItemFunc)
            where T : class, ISpiderItem, new()
        {
            var html = await GetHtmlContentUsingPuppeteerAsync(url);
            var element = await _htmlParser.GetElementAsync(html, selector);

            var item = buildItemFunc.Invoke(element);

            return item;
        }
        #endregion

        #region Helper.
        private async Task<string> GetHtmlContentUsingPuppeteerAsync(string url)
        {
            var option = new LaunchOptions()
            {
                Headless = false
            };

            using (var browser = await Puppeteer.LaunchAsync(option))
            {
                using (var page = await browser.NewPageAsync())
                {
                    await page.GoToAsync(url);
                    var html = await page.GetContentAsync();

                    return html;
                }
            }
        }
        #endregion
    }
}
