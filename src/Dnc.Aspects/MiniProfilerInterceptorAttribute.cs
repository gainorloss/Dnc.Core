using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Dnc.Aspects
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MiniProfilerInterceptorAttribute
        : AbstractInterceptorAttribute
    {
        public int ExecuteCount { get; private set; } = 10000;
        [FromContainer]
        public ILogger<MiniProfilerInterceptorAttribute> Logger { get; set; }
        [FromContainer]
        public IFrameworkEnvironment Env { get; set; }
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var sw = Stopwatch.StartNew();
            if (Env.IsDevelopment)
            {
                for (int i = 0; i < ExecuteCount; i++)
                    await context.Invoke(next);
            }
            else
                await context.Invoke(next);
            sw.Stop();
            Logger.LogWarning($"【{context.Implementation}.{context.ServiceMethod.Name}】【params:{string.Join(",", context.Parameters)}】:{sw.ElapsedMilliseconds}ms");
        }
    }
}
