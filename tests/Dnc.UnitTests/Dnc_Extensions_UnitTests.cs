using Dnc.Seedwork;
using Dnc.Test;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class Dnc_Extensions_UnitTests
        : UnitTestBase
    {
        public Dnc_Extensions_UnitTests(ITestOutputHelper output)
            : base(output)
        {
            Fx.CreateDefaultConstruction()
                .Build();
        }

        [Fact]
        public void DateTime_Humanization()
        {
            _output.WriteLine(DateTime.UtcNow.AddYears(-1).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddYears(-2).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddYears(-3).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddYears(-4).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddYears(-5).ToHumanization());

            _output.WriteLine(DateTime.UtcNow.AddMonths(-1).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddMonths(-2).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddMonths(-3).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddMonths(-4).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddMonths(-5).ToHumanization());

            _output.WriteLine(DateTime.UtcNow.AddDays(-1).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddDays(-2).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddDays(-3).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddDays(-4).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddDays(-5).ToHumanization());

            _output.WriteLine(DateTime.UtcNow.AddHours(-1).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddHours(-2).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddHours(-3).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddHours(-4).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddHours(-5).ToHumanization());

            _output.WriteLine(DateTime.UtcNow.AddMinutes(-1).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddMinutes(-2).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddMinutes(-3).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddMinutes(-4).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddMinutes(-5).ToHumanization());

            _output.WriteLine(DateTime.UtcNow.AddSeconds(-1).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddSeconds(-2).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddSeconds(-3).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddSeconds(-4).ToHumanization());
            _output.WriteLine(DateTime.UtcNow.AddSeconds(-5).ToHumanization());

            _output.WriteLine(DateTime.UtcNow.ToHumanization());
            _output.WriteLine(new DateTime(2019, 6, 10).ToHumanization());
        }

        [Fact]
        public void TimeSpan_Humanization()
        {
            _output.WriteLine(TimeSpan.FromDays(-1).ToHumanization());
            _output.WriteLine(TimeSpan.FromDays(-2).ToHumanization());
            _output.WriteLine(TimeSpan.FromDays(-3).ToHumanization());
            _output.WriteLine(TimeSpan.FromDays(-4).ToHumanization());
            _output.WriteLine(TimeSpan.FromDays(-5).ToHumanization());
        }

        [Fact]
        public void Enumerable_Humanization()
        {
            var mockRepository = Fx.Resolve<IMockRepository>();
            var events = mockRepository.CreateMultiple<VersionSetEvent>();
            _output.WriteLine(events.ToHumanization());
        }

        [Fact]
        public void Object_Humanization()
        {
            var mockRepository = Fx.Resolve<IMockRepository>();
            var @event = mockRepository.Create<VersionSetEvent>();
            _output.WriteLine(@event.ToHumanization());
        }
    }
}
