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
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class Dnc_Core_UnitTests
        : UnitTestBase
    {
        public Dnc_Core_UnitTests(ITestOutputHelper output)
            : base(output)
        {
            Fx.SrvRegisteredEvent += services =>
            {
                services.AddTransient<ISysLogService, SysLogService>();
                services.AddTransient<ICommandHandler<SetVersionCmd>, SetVersionCmdHandler>();
            };
            Fx.ExceptionThrownEvent += ex =>
            {
                _output.WriteLine(ex.Message);
            };
            Fx.CreateDefaultConstruction().Build();
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
        public async Task Alarmer_ShouldBe_ResolvedAsync()
        {
            var alarmer = Fx.Resolve<IAlarmer>();
            await alarmer.AlarmAdminUsingWechatAsync("�ڴ汬ը", "�澯" );
        }

        [Fact]
        public void Downloader_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IDownloader>());
        [Fact]
        public void ObjectSerializer_ShouldBe_Resolved() => Assert.NotNull(Fx.Resolve<IObjectSerializer>());
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
        public async Task CQRS_ShouldBe_NormalAsync()
        {
            var commandbus = Fx.Resolve<ICommandBus>();
            await commandbus.SendAsync(new SetVersionCmd(1));
        }
        [Fact]
        public async Task MailSender_ShouldBe_NormalAsync()
        {
            var sender = Fx.Resolve<IMailSender>();
            await sender.SendMailAsync("519564415@qq.com", "ʱ������", $"<h1 style='text-align:center;color:red'>������{DateTime.Now.ToLongTimeString()}</h1><img src='https://p1.ssl.qhimgs1.com/t01dbec9123dc40203d.jpg' alt='һ���߹���ʮ���,1977���й������ͼ' title='һ���߹���ʮ���,1977���й������ͼ' class='thumb'>");
        }
    }
}