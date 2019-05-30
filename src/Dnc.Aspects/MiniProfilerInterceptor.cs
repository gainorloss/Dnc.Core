using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Microsoft.Extensions.Logging;

namespace Dnc.Aspects
{
    public class MiniProfilerInterceptorAttribute
        : AbstractInterceptorAttribute
    {
        public int ExecuteCount { get; private set; } = 1000000;
        [FromContainer]
        public ILogger<MiniProfilerInterceptorAttribute> Logger { get; set; }
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < ExecuteCount; i++)
                await context.Invoke(next);
            sw.Stop();
            Logger.LogWarning($"【{context.Implementation}.{context.ServiceMethod.Name}】【params:{string.Join(",", context.Parameters)}】:{sw.ElapsedMilliseconds}ms");
        }
    }
}
