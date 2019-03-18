using Quartz;
using System;
using System.Collections.Generic;
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
        public async Task Execute(IJobExecutionContext context)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            await ExecuteJobAsync(context);

            Console.ForegroundColor = oldColor;
        }

        public abstract Task ExecuteJobAsync(IJobExecutionContext context);
    }
}
