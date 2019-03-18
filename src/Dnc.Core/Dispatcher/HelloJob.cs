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
            await Task.Run(() => Console.WriteLine($"{DateTime.Now.ToLongTimeString()}"));
        }
    }
}
