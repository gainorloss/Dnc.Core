using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Events
{
    public interface IEvent
        : IMessage
    { }

    public interface IEvent<TEventId>
        : IEvent
    {
        TEventId EventId { get; set; }
    }
}
