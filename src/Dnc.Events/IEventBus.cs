using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Events
{
    public interface IEventBus
        : IEventPublisher, IEventSubscriber, IDisposable
    { }
}
