using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public class InMemoryEventBus : IEventBus
    {
        private event EventHandler<EventProcessedArgs> EventPushed;
        private readonly IEnumerable<IEventHandler> _eventHandlers;
        public InMemoryEventBus(IEnumerable<IEventHandler> eventHandlers)
        {
            _eventHandlers = eventHandlers;
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent => await Task.Run(() => EventPushed?.Invoke(this, new EventProcessedArgs(@event)));

        public void Subscribe() => EventPushed += InMemoryEventBus_EventPushed;

        private void InMemoryEventBus_EventPushed(object sender, EventProcessedArgs e)
        {
            if (_eventHandlers == null || !_eventHandlers.Any()) return;

            _eventHandlers.Where(eh => eh.CanHandle(e.Event))
                .ToList()
                .ForEach(async eh => await eh.HandleEventAsync(e.Event));
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    EventPushed -= InMemoryEventBus_EventPushed;
                }
                disposedValue = true;
            }
        }

        public void Dispose() => Dispose(true);
        #endregion
    }
}
