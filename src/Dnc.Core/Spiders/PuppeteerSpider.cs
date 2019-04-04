using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class PuppeteerSpider
        : ISpider
    {
        static PuppeteerSpider()
        {
            //new BrowserFetcher()
            //   .DownloadAsync(BrowserFetcher.DefaultRevision);
        }
        public async Task<IEnumerable<T>> GetItemsAsync<T>(string url,
            string selectors,
            Func<IElement, T> buildItemFunc)
        {
            await new BrowserFetcher()
                  .DownloadAsync(BrowserFetcher.DefaultRevision);

            var items = new List<T>();

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

                    var parser = new HtmlParser();
                    var doc = await parser.ParseDocumentAsync(html);

                    var elements = doc.QuerySelectorAll(selectors);

                    foreach (var ele in elements)
                    {
                        var item = buildItemFunc.Invoke(ele);
                        items.Add(item);
                    }
                }
            }

            return items;
        }
    }
}
