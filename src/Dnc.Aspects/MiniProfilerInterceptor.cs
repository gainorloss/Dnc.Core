using System.Diagnostics;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Microsoft.Extensions.Logging;

namespace Dnc.Aspects
{
    public class MiniProfilerInterceptorAttribute
        : AbstractInterceptorAttribute
    {
        [FromContainer]
        public ILogger<MiniProfilerInterceptorAttribute> Logger { get; set; }
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var sw = Stopwatch.StartNew();
            await context.Invoke(next);
            sw.Stop();
            Logger.LogDebug($"【{context.Implementation}.{context.ServiceMethod.Name}】【{string.Join(",", context.Parameters)}】:{sw.ElapsedMilliseconds}ms");
        }
    }
}
