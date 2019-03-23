using Dnc.Dispatcher;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.WpfApp.Jobs
{
    class HelloJob
        : AbstractJob
    {
        public override async Task ExecuteJobAsync(IJobExecutionContext context)
        {
            await Task.Run(() => Framework.Construction.ServiceProvider
            .GetRequiredService<ILogger>()
            .LogInformation($"{DateTime.Now.ToLongTimeString()}"));
        }
    }
}
