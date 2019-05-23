using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public interface IEventHandler
    {
        void Handle<TEvent>(TEvent @event) where TEvent : IEvent;
        Task HandleAsync<TEvent>(TEvent @event) where TEvent : IEvent;
        bool CanHandle<TEvent>(TEvent @event) where TEvent:IEvent;
    }
    public interface IEventHandler<TEvent>
        where TEvent:IEvent
    {
        void Handle(TEvent @event);

        Task HandleAsync(TEvent @event);

        bool CanHandle(TEvent @event);
    }
}
