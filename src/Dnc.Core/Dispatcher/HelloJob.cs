using Dnc.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Dispatcher
{
    public class HelloJob
         : AbstractJob
    {
        public override async Task ExecuteJobAsync(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                PerformanceMonitor.MonitorCurrentProcess();
                //PerformanceMonitor.MonitorProcessByName("ET.Erp.Main");
            });
        }
    }
}
