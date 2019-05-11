using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
