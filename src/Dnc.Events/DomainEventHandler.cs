using System.Threading.Tasks;

namespace Dnc.Events
{
    public abstract class DomainEventHandler<TEvent> : IEventHandler<TEvent>
         where TEvent : class, IEvent
    {
        private readonly IEventStore _eventStore;
        public DomainEventHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public bool CanHandle<TEvent1>(TEvent1 @event) where TEvent1 : IEvent => @event.GetType() == typeof(TEvent);

        public async Task HandleEventAsync(TEvent @event)
        {
            await _eventStore.SaveAsync(@event);
            await HandleAsync(@event);
        }

        public async Task HandleEventAsync<TEvent1>(TEvent1 @event) where TEvent1 : IEvent
        {
            if (!CanHandle(@event)) return;
            await HandleEventAsync(@event as TEvent);
        }
        protected abstract Task HandleAsync(TEvent @event);
    }
}
