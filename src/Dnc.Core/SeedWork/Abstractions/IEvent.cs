using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
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
