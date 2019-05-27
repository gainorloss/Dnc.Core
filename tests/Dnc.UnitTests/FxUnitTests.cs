using Dnc.Events;
using Dnc.FaultToleranceProcessors;
using Dnc.Files;
using Dnc.ObjectId;
using Dnc.Output;
using Dnc.Seedwork;
using Dnc.Sender;
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
                services.AddTransient<IEventHandlerExecutionContext>(sp => new EventHandlerExecutionContext(services));
            };
            Fx.CreateDefaultConstruction().Build();
        }

        [Fact]
        public void ConsoleOutputHelper_ShouldBe_Resolved()
        {
            var consoleOutputHelper = Fx.Resolve<IConsoleOutputHelper>();
            consoleOutputHelper.Dump(new VersionSetEvent());
            Assert.NotNull(consoleOutputHelper);
        }

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
            var es = Fx.Resolve<IEventStore>();
            var eventbus = Fx.Resolve<IEventBus>();
            eventbus.Subscribe<TimeUpdatedEvent,TimeUpdatedEventHandler>();
            eventbus.Subscribe<VersionSetEvent, VersionSetEventHandler>();
            eventbus.PublishAsync(new TimeUpdatedEvent());
            eventbus.PublishAsync(new VersionSetEvent());
            Assert.NotNull(eventbus);
        }
    }
}
