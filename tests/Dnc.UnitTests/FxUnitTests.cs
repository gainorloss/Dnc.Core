using Dnc.CQRS;
using Dnc.Events;
using Dnc.FaultToleranceProcessors;
using Dnc.Files;
using Dnc.ObjectId;
using Dnc.Output;
using Dnc.Seedwork;
using Dnc.Sender;
using Dnc.Serializers;
using Dnc.Test;
using Dnc.UnitTests.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
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
                services.AddTransient<ISysLogService, SysLogService>();
                services.AddTransient<ICommandHandler<SetVersionCmd>, SetVersionCmdHandler>();
            };
            Fx.CreateDefaultConstruction().AspectsBuild();
        }

        [Fact]
        public void ConsoleOutputHelper_ShouldBe_Resolved()
        {
            var consoleOutputHelper = Fx.Resolve<IConsoleOutputHelper>();
            consoleOutputHelper.SetTitle("Black Apple");
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
        public void MessageSerializer_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IObjectSerializer>());
        [Fact]
        public void MockRepository_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IMockRepository>());
        [Fact]
        public void FaultToleranceProcessor_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IFaultToleranceProcessor>());
        [Fact]
        public void EventBus_ShouldBe_Resolved()
        {
            var es = Fx.Resolve<IEventStore>();
            var eventbus = Fx.Resolve<IEventBus>();
            eventbus.Subscribe<TimeUpdatedEvent, TimeUpdatedEventHandler>();
            eventbus.Subscribe<VersionSetEvent, VersionSetEventHandler>();
            eventbus.PublishAsync(new TimeUpdatedEvent());
            eventbus.PublishAsync(new VersionSetEvent());
            Assert.NotNull(eventbus);
        }
        [Fact]
        public async Task MiniProfilerIntercepter_ShouldBe_NormalAsync()
        {
            var syslogService = Fx.Resolve<ISysLogService>();
            await syslogService.AddLogAsync("log");
        }
        [Fact]
        public async Task CQRS_ShouldBe_NormalAsync()
        {
            var commandbus = Fx.Resolve<ICommandBus>();
            await commandbus.SendAsync(new SetVersionCmd(1));
        }
        [Fact]
        public async Task MailSender_ShouldBe_NormalAsync()
        {
            var sender = Fx.Resolve<IMailSender>();
            await sender.SendMailAsync("519564415@qq.com","aja","aja");
        }
    }
}
