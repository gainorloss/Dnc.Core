using Dnc.Compilers;
using Dnc.Files;
using Dnc.Output;
using Dnc.Spiders;
using Microsoft.Extensions.DependencyInjection;
using PuppeteerSharp;
using System;
using Dnc.Extensions;

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
                .UseDefaultCompiler()
                .UseDownloader()
                .Build();

            var sp = fx.ServiceProvider;

            var spider = sp.GetRequiredService<ISpider>();

            // spider.GetItemsAsync<string>("https://www.qichacha.com/news", ".list-group", ele =>
            //{
            //    return "";
            //})
            //.Wait();


            var outputHelper = sp.GetService<IConsoleOutputHelper>() as IConsoleOutputHelper;
            outputHelper.OutputImage(@"C:\Users\Administrator\Pictures\timg (3).jpg");

            //TestAsync().Wait();

            var compiler = sp.GetRequiredService<ICompiler>();

            var script = @"  public class HelloWorld
    {
        public string String { get; set; }
        public HelloWorld(string str)
        {
            String = str;
        }
    }
new HelloWorld(Arg1).String";
            var rt = compiler.RunAsync<string>(script,
                  new Arg<string>() { Arg1 = "gainorloss" },
                  nameSpace: "Dnc.ConsoleApp",
                  references: typeof(HelloWorld).Assembly)
                  .ConfigureAwait(false)
                  .GetAwaiter()
                  .GetResult();

            var downloader = sp.GetRequiredService<IDownloader>();
            var result = downloader.DownloadRemoteImageAsync("https://goss3.vcg.com/creative/vcg/800/version23/VCG41471562191.jpg","c://")
                  .ConfigureAwait(false)
                  .GetAwaiter()
                  .GetResult();

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
