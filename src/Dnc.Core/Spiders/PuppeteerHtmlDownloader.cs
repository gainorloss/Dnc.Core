using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class PuppeteerHtmlDownloader
        : IHtmlDownloader
    {
        private readonly IFrameworkEnvironment _env;
         
        #region Static ctor.
        static PuppeteerHtmlDownloader()
        {
            new BrowserFetcher()
               .DownloadAsync(BrowserFetcher.DefaultRevision)
               .Wait();
        }
        #endregion

        public PuppeteerHtmlDownloader(IFrameworkEnvironment env)
        {
            _env = env;
        }

        #region Methods for getting html content.
        public async Task<string> DownloadHtmlContentAsync(string url, Func<Page, Task> beforeGetContentHandler = null, string agent = null)
        {
            return await GetHtmlContentUsingPuppeteerAsync(url, beforeGetContentHandler, agent);
        }
        #endregion

        #region Helper.
        private async Task<string> GetHtmlContentUsingPuppeteerAsync(string url, Func<Page, Task> beforeGetContentHandler = null, string agent = null)
        {
            var option = new LaunchOptions()
            {
                Timeout = 30 * 1000,
                Headless= !_env.IsDevelopment
            };

            var args = new List<string>()
            {
                "--no-sandbox",
                "--disable-setuid-sandbox"
            };

            if (!string.IsNullOrEmpty(agent))
                args.Add($"--proxy-server={agent}");

            option.Args = args.ToArray();

            using (var browser = await Puppeteer.LaunchAsync(option))
            {
                using (var page = await browser.NewPageAsync())
                {
                    await page.SetViewportAsync(new ViewPortOptions()
                    {
                         Width=1366,
                         Height=768
                    });
                    await page.GoToAsync(url);
                    if (beforeGetContentHandler != null)
                    {
                        await beforeGetContentHandler.Invoke(page);//control browser before get content.
                    }
                    await page.WaitForNavigationAsync();
                    var html = await page.GetContentAsync();
                    return html;
                }
            }
        }
        #endregion
    }
}
