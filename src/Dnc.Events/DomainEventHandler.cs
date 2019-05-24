using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public abstract class DomainEventHandler<TEvent> : IEventHandler<TEvent>
         where TEvent : class, IEvent
    {
        public bool CanHandle<TEvent1>(TEvent1 @event) where TEvent1 : IEvent => @event.GetType() == typeof(TEvent);

        public abstract Task HandleAsync(TEvent @event);

        public async Task HandleAsync<TEvent1>(TEvent1 @event) where TEvent1 : IEvent => await HandleAsync(@event as TEvent);
    }
}
