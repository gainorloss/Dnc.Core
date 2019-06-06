using Dnc.Test;
using Dnc.UnitTests.Queries;
using Dnc.UnitTests.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class Dnc_Aspects_UnitTest
        :UnitTestBase
    {
        public Dnc_Aspects_UnitTest(ITestOutputHelper output) 
            : base(output)
        {
            Fx.SrvRegisteredEvent += Fx_SrvRegisteredEvent;
            Fx.CreateDefaultConstruction()
                .AspectsBuild();
        }

        private void Fx_SrvRegisteredEvent(IServiceCollection services)
        {
            services.AddTransient<ILogQueries,LogQueries>();
        }

        [Fact]
        public void MemeoryCacheInterceptor_ShouldBe_Normal()
        {
            var logQueries = Fx.Resolve<ILogQueries>();
            logQueries.GetAllLogs();
        }

        [Fact]
        public void HystrixCommandInterceptor_ShouldBe_Normal()
        {
            var logQueries = Fx.Resolve<ILogQueries>();
            logQueries.GetAllLogs();
        }

        [Fact]
        public async Task MiniProfilerIntercepter_ShouldBe_NormalAsync()
        {
            var syslogService = Fx.Resolve<ISysLogService>();
            await syslogService.AddLogAsync("log");
        }
    }
}
