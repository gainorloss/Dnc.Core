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
using Dnc.Dispatcher;
using System.Threading;
using Dnc.ObjectId;
using System.Linq;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using Dnc.Senders;
using Dnc.ViewEngines;
using Dnc.FaultToleranceProcessors;

namespace Dnc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fx = Framework
                .Construct<DefaultFrameworkConstruction>()
                .UseConsoleOutputHelper()
                .UseMemoryAgentPool()
                .UseHttpRequestHtmlDownloader()
                .UseDefaultCompiler()
                .UseDownloader()
                .UseRedis(opt =>
                {
                    opt.Host = "140.143.88.100";
                    opt.Port = 6379;
                    opt.InstanceName = "Dnc.Core";
                    opt.Password = "p@ssw0rd";
                })
                .UseFaultToleranceProcessor()
                .UseMailSender()
                .Build();

            var sp = fx.ServiceProvider;

            #region ConsoleOutputHelper.
            var outputHelper = sp.GetService<IConsoleOutputHelper>() as IConsoleOutputHelper;
            //outputHelper.OutputImage(@"C:\Users\Administrator\Pictures\timg (3).jpg");
            //Enumerable.Range(1, 10).ToList()
            //    .ForEach(i => Task.Factory.StartNew(() =>
            //    {
            //        Thread.Sleep(500);
            //        outputHelper.Debug("Server error.");
            //        outputHelper.Info("Server error.");
            //        outputHelper.Warning("Server error.");
            //        outputHelper.Error("Server error.");
            //    }));
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
            DangdangCategoryGetterAsync(sp)
                .ConfigureAwait(false)
                .GetAwaiter();
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

            #region redis.
            //var redis = sp.GetRequiredService<IRedis>();
            //var val = redis.TryGetOrCreate("firstname", () => "gainorloss");
            //val = redis.TryGetOrCreate("firstname", () => "gainorloss"); 
            #endregion

            #region mock.
            //var mock = sp.GetRequiredService<IMockRepository>();
            //var hello = mock.Create<HelloWorld>();
            //var hellos = mock.CreateMultiple<HelloWorld>(); 
            #endregion

            #region object id generator.
            //var objectIdGenerator = sp.GetRequiredService<IObjectIdGenerator>();
            //Enumerable.Range(0, 10000).ToList()
            //    .ForEach(i =>
            //    {
            //        var uuid = objectIdGenerator.Uuid();
            //        var intGuid = objectIdGenerator.IntGuid();
            //        var combinedGuid = objectIdGenerator.CombinedGuid();
            //        Console.WriteLine($"{uuid},{intGuid},{combinedGuid}");
            //    }); 
            #endregion

            #region mail sender.
            //var mailer = sp.GetRequiredService<IMailSender>();
            //mailer.SendMailAsync("519564415@qq.com","this is a title","this is a content")
            //    .ConfigureAwait(false)
            //    .GetAwaiter();
            #endregion

            #region view engine.
            //var viewEngine = sp.GetRequiredService<IViewEngine>();
            //var rt = viewEngine.ParseAsync("<h1>@Model.FirstName</h1><p>@Model.LastName</p>", new { FirstName = "gainorloss", LastName = "gain" })
            //      .ConfigureAwait(false)
            //      .GetAwaiter()
            //      .GetResult();
            //outputHelper.Info(rt);
            #endregion

            //var faultToleranceProcessor = sp.GetRequiredService<IFaultToleranceProcessor>();
            //faultToleranceProcessor.RetryAsync(async () =>
            //await Task.Run(() =>
            //     {
            //         var zero = 0;
            //         var a = 1 / zero;
            //     })).Wait();
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

        private static async Task DangdangCategoryGetterAsync(IServiceProvider sp)
        {
            var manager = sp.GetRequiredService<IAgentPool>();
            var scheduler = sp.GetRequiredService<ScheduleCenter>();
            var downloader = sp.GetRequiredService<IHtmlDownloader>();
            var parser = sp.GetRequiredService<IHtmlParser>();
            var outputHelper = sp.GetService<IConsoleOutputHelper>() as IConsoleOutputHelper;
            var agentGetter = sp.GetService<IAgentGetter>() as IAgentGetter;

            //start a scheduler to get proxies.
            //await scheduler.CreateAndRunScheduleAsync("spider", "Dnc.ConsoleApp.Jobs.ProxyManagerJob", "*/10 * * ? * *", "Dnc.ConsoleApp.dll");
            //Thread.Sleep(10000);

            var isbns = new List<string>
            {
                "9787560099347",
                "9787313171115",
                "9787565600524",
                "9787111575184"
            };
            foreach (var isbn in isbns)
            {
                //var item = await manager.GetAgentAsync<BaseAgentSpiderItem>();
                //var agent = $"{item.AgentType}://{item.Host}:{item.Port}";
                var agent = "https://111.177.191.237:9999";

                var queryUrl = $"http://search.dangdang.com/?key={isbn}";
                var queryHtml = await downloader.DownloadHtmlContentAsync(queryUrl,agent:agent);
                var li = await parser.GetElementAsync(queryHtml, "#search_nature_rg ul li");
                var skuId = li.GetAttribute("sku");

                var itemUrl = $"http://product.dangdang.com/{skuId}.html";
                var itemHtml = await downloader.DownloadHtmlContentAsync(itemUrl, agent: agent);
                var spans = await parser.GetElementsAsync(itemHtml, ".clearfix .fenlei .lie");
                var categories = new List<string>();
                foreach (var span in spans)
                {
                    var categoryNodes = span.QuerySelectorAll("a");
                    var categoryNodeStrs = categoryNodes.Select(n => n.TextContent);
                    categories.Add(string.Join("&gt", categoryNodeStrs));
                }

                var category = string.Join(";", categories);
                outputHelper.Info(category, "当当营销分类");
            }
            scheduler.Shutdown();
            #region Obsolete.
            //var item= manager.GetProxyAsync<BaseProxySpiderItem>().Result;
            //var spider = sp.GetRequiredService<ISpider>();
            //spider.StartAsync("https://www.nuget.org/packages?q=dnc")
            //    .ConfigureAwait(false)
            //    .GetAwaiter(); 
            #endregion
        }
    }
}
