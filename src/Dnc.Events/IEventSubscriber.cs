using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Events
{
    public interface IEventSubscriber
    {
        void Subscribe<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
