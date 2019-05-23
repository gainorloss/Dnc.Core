using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public interface IEventHandler
    {
        bool CanHandle<TEvent>(TEvent @event) where TEvent:IEvent;
        Task HandleAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
    public interface IEventHandler<TEvent>: IEventHandler
        where TEvent:IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
