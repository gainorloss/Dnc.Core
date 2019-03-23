using System.Linq;
using System.Threading;
using System.Windows;
using Dnc.Core.Helpers;
using Dnc.Extensions;
using Dnc.Helpers;
using Dnc.Serializers;
using Dnc.WpfApp.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace Dnc.WpfApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var framework = Framework.Construct<DefaultFrameworkConstruction>()
                .UseScheduleCenter()
                .Build();

            var scheduler = framework.ScheduleCenter;

            scheduler.RunScheduleAsync()
                .ConfigureAwait(false)
                .GetAwaiter();//sample schedule.

            scheduler.CreateAndRunScheduleAsync("gainorloss",
                "Dnc.WpfApp.Jobs.HelloJob",
                "* */1 * ? * *",
                "Dnc.WpfApp.exe")
                .ConfigureAwait(false)
                .GetAwaiter();

            var items = Enumerable.Range(0, 100);//批次任务

            items.Page(30, selected =>
            {
                System.Console.WriteLine(string.Join(",", selected));//同步处理
            });

            var log = items.Parallel(30, selected =>
              {
                  System.Console.WriteLine(string.Join(",", selected));//并行处理
              });
            System.Console.WriteLine(log);


            //serializers.
            new SerializerTest(framework.ServiceProvider.GetRequiredService<IMessageSerializer>())
                .Test();

            base.OnStartup(e);
        }
    }
}

