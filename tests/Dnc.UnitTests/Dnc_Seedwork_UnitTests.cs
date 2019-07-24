using Dnc.Test;
using Dnc.UnitTests.Seedwork;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class Dnc_Seedwork_UnitTests : UnitTestBase
    {
        public Dnc_Seedwork_UnitTests(ITestOutputHelper output)
            : base(output)
        {
            Fx.SrvRegisteredEvent += Fx_SrvRegisteredEvent;
            Fx.CreateDefaultConstruction()
                .Build();
        }

        private void Fx_SrvRegisteredEvent(IServiceCollection services)
        {
           
        }

        [Fact]
        public void EntityBaseIClone_ShouldBeNormal()
        {
            var work = new TestWork();
            var deepClone = work.DeepClone() as TestWork;
            var shallowClone = work.ShallowClone() as TestWork;
            deepClone.Creator = "gainorloss";
            shallowClone.Creator = "gainorloss";
        }
    }

}
