using Dnc.Redis;
using Dnc.Test;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class Dnc_Redis_UnitTests
        : UnitTestBase
    {
        public Dnc_Redis_UnitTests(ITestOutputHelper output)
            : base(output)
        {
            Fx.CreateDefaultConstruction().Build();
        }

        [Fact]
        public async Task Redis_ShouldBe_ResolvedAsync()
        {
            var redis = Fx.Resolve<IRedis>();
            await redis.SetAsync("gainorloss", "gainorloss");
        }
    }
}
