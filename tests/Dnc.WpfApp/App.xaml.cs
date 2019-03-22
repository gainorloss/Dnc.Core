using System.Linq;
using System.Threading;
using System.Windows;
using Dnc.Extensions;

namespace Dnc.WpfApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var framework = new DefaultFrameworkConstruction()
                .UseScheduleCenter()
                .Build();
            framework.ScheduleCenter.RunScheduleAsync().Wait();//sample schedule.
            framework.ScheduleCenter
                .CreateAndRunScheduleAsync("gainorloss", "Dnc.WpfApp.Jobs.HelloJob", "0 32 9 ? * *", "Dnc.WpfApp.exe")
                .Wait();

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
            base.OnStartup(e);
        }
    }
}

