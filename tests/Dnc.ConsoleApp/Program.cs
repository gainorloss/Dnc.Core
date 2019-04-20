using Dnc.Compilers;
using Dnc.Files;
using Dnc.Output;
using Dnc.Spiders;
using Microsoft.Extensions.DependencyInjection;
using PuppeteerSharp;
using System;
using Dnc.Extensions;
using System.Threading.Tasks;
using Dnc.Algorithm;
using Dnc.Alarmers;
using Dnc.Data;
using Dnc.SeedWork;

namespace Dnc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fx = Framework
                .Construct<DefaultFrameworkConstruction>()
                .UseDefaultConsoleOutputHelper()
                .UseDefaultSpider(services => services.AddSingleton<IPipelineProcessor, PipelineProcessor>())
                .UseDefaultCompiler()
                .UseDownloader()
                .UseMockRepository()
                .UseRedis(opt =>
               {
                   opt.Host = "140.143.88.100";
                   opt.Port = 6379;
                   opt.InstanceName = "Dnc.Core";
                   opt.Password = "p@ssw0rd";
               })
                .Build();

            var sp = fx.ServiceProvider;

            #region ConsoleOutputHelper.
            //var outputHelper = sp.GetService<IConsoleOutputHelper>() as IConsoleOutputHelper;
            //outputHelper.OutputImage(@"C:\Users\Administrator\Pictures\timg (3).jpg");
            #endregion

            #region Compiler.
            //            var compiler = sp.GetRequiredService<ICompiler>();
            //            var script = @"  public class HelloWorld
            //    {
            //        public string String { get; set; }
            //        public HelloWorld(string str)
            //        {
            //            String = str;
            //        }
            //    }
            //new HelloWorld(Arg1).String";
            //            var rt = compiler.RunAsync<string>(script,
            //                  new Arg<string>() { Arg1 = "gainorloss" },
            //                  nameSpace: "Dnc.ConsoleApp",
            //                  references: typeof(HelloWorld).Assembly)
            //                  .ConfigureAwait(false)
            //                  .GetAwaiter()
            //                  .GetResult();
            #endregion

            #region Downloader.
            //var downloader = sp.GetRequiredService<IDownloader>();
            //var result = downloader.DownloadRemoteImageAsync("https://goss3.vcg.com/creative/vcg/800/version23/VCG41471562191.jpg", "c://")
            //      .ConfigureAwait(false)
            //      .GetAwaiter()
            //      .GetResult();

            //PriceSpiderAsync(sp)
            //    .ConfigureAwait(false)
            //   .GetAwaiter();
            #endregion

            #region Spider.
            //var spider = sp.GetRequiredService<ISpider>();
            //spider.StartAsync("https://www.nuget.org/packages?q=dnc")
            //    .ConfigureAwait(false)
            //    .GetAwaiter(); 
            #endregion

            #region Sort.
            //var items = new int[] { 6, 3, 2, 7, 9, 10 };
            //items.QuickSort(0, 5);
            //items.BubbleSort(); 
            #endregion

            #region Alarmer.
            //var alarmer = sp.GetRequiredService<IAlarmer>();
            //var isSuccess = alarmer.AlarmAdminUsingWechatAsync("您的服务器挂了", "库存同步调度失败请赶紧处理")
            //    .ConfigureAwait(false)
            //    .GetAwaiter()
            //    .GetResult(); 
            #endregion

            //var redis = sp.GetRequiredService<IRedis>();
            //var val = redis.TryGetOrCreate("firstname", () => "gainorloss");
            //val = redis.TryGetOrCreate("firstname", () => "gainorloss");

            var mock = sp.GetRequiredService<IMockRepository>();
            var hello = mock.Create<HelloWorld>();
            var hellos = mock.CreateMultiple<HelloWorld>();
            Console.Read();
            Console.WriteLine("Hello World!");
        }

        private static async Task PriceSpiderAsync(IServiceProvider sp)
        {
            var downloader = sp.GetRequiredService<IHtmlDownloader>();
            var parser = sp.GetRequiredService<IHtmlParser>();

            var url = "https://detail.tmall.com/item.htm?spm=a220m.1000858.1000725.1.46db30909Ff9yt&id=577658727978&skuId=4611686596086115882&user_id=859515618&cat_id=2&is_b=1&rn=b63ddc1ba00d1050fce9ff69fff2724d";
            var content = await downloader.DownloadHtmlContentAsync(url, async page =>
            {
                var closeBtn = await page.QuerySelectorAsync(".sufei-dialog-close");
                var box = await closeBtn.BoundingBoxAsync();
                var x = box.X + box.Width / 2;
                var y = box.Y + box.Height / 2;
                await page.Mouse.ClickAsync(x, y);
                await page.WaitForNavigationAsync();
            });
        }

        private static async Task TestAsync()
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
