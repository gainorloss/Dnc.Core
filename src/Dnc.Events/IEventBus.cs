using System;

namespace Dnc.Events
{
    public interface IEventBus
        : IEventPublisher, IEventSubscriber, IDisposable,IPlugin
    { }
}
