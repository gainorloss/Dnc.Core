using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public class InMemoryEventBus : IEventBus
    {
        private event EventHandler<EventProcessedArgs> EventPushed;
        private readonly IEventHandlerExecutionContext _ctx;
        public InMemoryEventBus(IEventHandlerExecutionContext ctx)
        {
            _ctx = ctx;
            EventPushed += InMemoryEventBus_EventPushed;
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent => await Task.Run(() => EventPushed?.Invoke(this, new EventProcessedArgs(@event)));

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : IEvent
            where TEventHandler : IEventHandler<TEvent>
        {
            if (!_ctx.HandlerRegistered<TEvent, TEventHandler>())
                _ctx.RegisterHandler<TEvent, TEventHandler>();
        }

        private void InMemoryEventBus_EventPushed(object sender, EventProcessedArgs e)
        {
            _ctx.HandleAsync(e.Event);
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
