using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Events
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
