using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Dnc.FaultToleranceProcessors;

namespace Dnc.Aspects
{
    public class HystrixCommandInterceptorAttribute
        : AbstractInterceptorAttribute
    {
        [FromContainer]
        public IFaultToleranceProcessor FaultToleranceProcessor { get; set; }
        public async override Task Invoke(AspectContext context, AspectDelegate next) => await FaultToleranceProcessor.RetryAsync(async () => await context.Invoke(next), 5);
    }
}
