using Dnc.Alarmers;
using Dnc.Events;
using Dnc.FaultToleranceProcessors;
using Dnc.Files;
using Dnc.ObjectId;
using Dnc.Output;
using Dnc.Seedwork;
using Dnc.Senders;
using Dnc.Serializers;
using Dnc.Test;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class FxUnitTests
        : UnitTestBase
    {
        public FxUnitTests(ITestOutputHelper output)
            : base(output)
        {
            Fx.SrvRegisteredEvent += services =>
            {
                services.AddScoped<IEventHandler, TimeUpdatedEventHandler>();
                services.AddScoped<IEventHandler, VersionSetEventHandler>();
            };
            Fx.Construct<FrameworkConstruction>().Build();

        }

        [Fact]
        public void ConsoleOutputHelper_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IConsoleOutputHelper>());
        [Fact]
        public void ObjectIdGenerator_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IObjectIdGenerator>());
        [Fact]
        public void Alarmer_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IAlarmer>());
        [Fact]
        public void Downloader_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IDownloader>());
        [Fact]
        public void MailSender_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IMailSender>());
        [Fact]
        public void MessageSerializer_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IMessageSerializer>());
        [Fact]
        public void MockRepository_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IMockRepository>());
        [Fact]
        public void FaultToleranceProcessor_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IFaultToleranceProcessor>());
        [Fact]
        public void EventBus_ShouldBe_Resolved()
        {
            var eventbus = Fx.Resolve<IEventBus>();
            var eh = Fx.Resolve<IEventHandler>();
            eventbus.Subscribe();
            eventbus.Publish(new TimeUpdatedEvent());
            Assert.NotNull(eventbus);
        }
    }
}
