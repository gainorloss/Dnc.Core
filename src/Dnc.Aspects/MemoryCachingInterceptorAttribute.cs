using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Microsoft.Extensions.Caching.Memory;

namespace Dnc.Aspects
{
    public class MemoryCachingInterceptorAttribute
        : AbstractInterceptorAttribute
    {
        public int ExpireMS { get; set; } = 20 * 1000;
        public MemoryCachingInterceptorAttribute(int seconds= 20)
        {
            ExpireMS = seconds * 1000;
        }

        [FromContainer]
        private IMemoryCache _memoryCache { get; set; }
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var typeFullName = context.ServiceMethod.DeclaringType.FullName;
            var method = context.ServiceMethod.Name;
            var args = string.Join(",", context.Parameters);

            var cachingKey = $"{typeFullName}_{method}_{args}".Trim('_');

            if (_memoryCache.TryGetValue(cachingKey, out var cachingValue))
            {
                context.ReturnValue = cachingValue;
                return;
            }
            if (string.IsNullOrEmpty(cachingKey))
            {
                await context.Invoke(next);
                return;
            }
            await context.Invoke(next);
            _memoryCache.Set(cachingKey, context.ReturnValue, DateTimeOffset.Now.AddMilliseconds(ExpireMS));
        }
    }
}
