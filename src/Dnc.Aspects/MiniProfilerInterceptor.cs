using System.Diagnostics;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace Dnc.Aspects
{
    public class MiniProfilerInterceptorAttribute
        : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var logger = Fx.Resolve<ILogger<MiniProfilerInterceptorAttribute>>();
            var sw = Stopwatch.StartNew();
            await context.Invoke(next);
            sw.Stop();
            logger.LogDebug($"【{context.Implementation}.{context.ServiceMethod.Name}】【{string.Join(",", context.Parameters)}】:{sw.ElapsedMilliseconds}ms");
        }
    }
}
