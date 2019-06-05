using Dnc.Test;
using Dnc.UnitTests.Queries;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class AspectsUnitTest
        :UnitTestBase
    {
        public AspectsUnitTest(ITestOutputHelper output) 
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
        public void MemeoryCache_ShouldBe_Normal()
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
    }
}
