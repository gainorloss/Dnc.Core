using Dnc.Spiders;
using Microsoft.Extensions.DependencyInjection;
using PuppeteerSharp;
using System;

namespace Dnc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var framework = Framework
                .Construct<DefaultFrameworkConstruction>()
                .UseDefaultSpider()
                .Build();

            // var spider = framework.ServiceProvider.GetRequiredService<ISpider>();

            // spider
            //    .GetItemsAsync<string>("https://www.qichacha.com/news", ".list-group", ele =>
            //{
            //    return "";
            //})
            //.Wait();


             TestAsync().Wait();

            Console.Read();
            Console.WriteLine("Hello World!");
        }

        private static async System.Threading.Tasks.Task TestAsync()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("http://www.google.com");
        }
    }
}
