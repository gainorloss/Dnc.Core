using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface IEventBus
        : IEventPublisher, IEventSubscriber, IDisposable
    { }
}
