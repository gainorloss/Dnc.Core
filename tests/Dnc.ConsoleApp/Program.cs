using Dnc.Output;
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
            var fx = Framework
                .Construct<DefaultFrameworkConstruction>()
                .UseDefaultConsoleOutputHelper()
                .UseDefaultSpider()
                .Build();

            var sp = fx.ServiceProvider;

            var spider = sp.GetRequiredService<ISpider>();

            // spider.GetItemsAsync<string>("https://www.qichacha.com/news", ".list-group", ele =>
            //{
            //    return "";
            //})
            //.Wait();

         
            var outputHelper = sp.GetService<IConsoleOutputHelper>() as IConsoleOutputHelper;
            outputHelper.OutputImage(@"C:\Users\Administrator\Pictures\u=1775280576,2212885380&fm=26&gp=0.jpg");

            //TestAsync().Wait();

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
