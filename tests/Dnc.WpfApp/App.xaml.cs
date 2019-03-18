using Dnc.Framework;
using System.Windows;

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
                .CreateAndRunScheduleAsync("gainorloss", "Dnc.WpfApp.Jobs.HelloJob", "* 5 13 ? * *", "Dnc.WpfApp.exe")
                .Wait();
            base.OnStartup(e);
        }
    }
}
