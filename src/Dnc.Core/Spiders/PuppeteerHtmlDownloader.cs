using AngleSharp.Dom;
using Dnc.Spiders;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class PuppeteerHtmlDownloader
        : IHtmlDownloader
    {
        #region Static ctor.
        static PuppeteerHtmlDownloader()
        {
            new BrowserFetcher()
               .DownloadAsync(BrowserFetcher.DefaultRevision)
               .ConfigureAwait(false)
               .GetAwaiter();
        }
        #endregion

        #region Methods for getting html content.
        public async Task<string> DownloadHtmlContentAsync(string url)
        {
            return await GetHtmlContentUsingPuppeteerAsync(url);
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
