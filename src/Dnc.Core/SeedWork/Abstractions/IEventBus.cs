using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public interface IEventBus
        : IEventPublisher, IEventSubscriber, IDisposable
    { }
}
