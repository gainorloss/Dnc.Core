using Dnc.Serializers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Dispatcher
{
    /// <summary>
    /// Extention abstract class  from <see cref="IJob"/>
    /// </summary>
    public abstract class AbstractJob
         : IJob
    {
        protected IServiceProvider ServiceProvider => Framework.Construction.ServiceProvider;
        protected ILogger<AbstractJob> Logger => ServiceProvider.GetRequiredService<ILogger<AbstractJob>>();
        public async Task Execute(IJobExecutionContext context)
        {
            var name = context.JobDetail.JobDataMap.GetString("name");

            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            var sw = new Stopwatch();
            Console.WriteLine($"//******{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}开始执行{name}******");
            sw.Start();
            await ExecuteJobAsync(context);
            sw.Stop();
            Console.WriteLine($"执行结束,总耗时{sw.Elapsed.Hours}:{sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}:{sw.Elapsed.Milliseconds}");
            Console.ForegroundColor = oldColor;
        }

        public abstract Task ExecuteJobAsync(IJobExecutionContext context);
    }
}
