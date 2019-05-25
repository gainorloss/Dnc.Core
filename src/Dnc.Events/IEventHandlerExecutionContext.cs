using System;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public interface IEventHandlerExecutionContext:IPlugin
    {
        void RegisterHandler<TEvent,TEventHandler>() 
            where TEvent:IEvent
            where TEventHandler:IEventHandler<TEvent>;
        void RegisterHandler(Type eventType,Type handlerType);

        bool HandlerRegistered<TEvent,TEventHandler>()
            where TEvent:IEvent
            where TEventHandler:IEventHandler<TEvent>;

        bool HandlerRegistered(Type eventType, Type handlerType);

        Task HandleAsync<TEvent>(TEvent @event) where TEvent:IEvent;
    }
}
