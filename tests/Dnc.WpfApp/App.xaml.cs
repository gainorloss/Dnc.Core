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
            var construction = Framework.Construct<DefaultFrameworkConstruction>();
            construction.Build();
            construction.ScheduleCenter.RunScheduleAsync().Wait();//sample schedule.
            construction.ScheduleCenter
                .CreateAndRunScheduleAsync("gainorloss", "Dnc.WpfApp.Jobs.HelloJob", "0 32 9 ? * *", "Dnc.WpfApp.exe")
                .Wait();
            base.OnStartup(e);
        }
    }
}
