using Dnc.Aspects;
using System.Threading.Tasks;

namespace Dnc.UnitTests.Services
{
    public  interface ISysLogService
    {
        [MiniProfilerInterceptor]
        Task AddLogAsync(string msg);
    }
}
