using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.FaultToleranceProcessors
{
    public interface IFaultToleranceProcessor
         : IPlugin
    {
        Task RetryAsync(Func<Task> action,int retryCount=5);

        Task WaitAndRetryAsync(Func<Task> action, int intervalStep=2,int retryCount=5);
    }
}
