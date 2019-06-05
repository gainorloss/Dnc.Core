using Dnc.Aspects;

namespace Dnc.UnitTests.Queries
{
    public interface ILogQueries
    {
        [MiniProfilerInterceptor]
        [MemoryCachingInterceptor]
        [HystrixCommandInterceptor]
        string GetAllLogs();
    }
}
