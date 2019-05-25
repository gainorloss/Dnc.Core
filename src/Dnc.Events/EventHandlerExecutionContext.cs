using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public class EventHandlerExecutionContext
        : IEventHandlerExecutionContext
    {
        private readonly ConcurrentDictionary<Type, List<Type>> _registrations = new ConcurrentDictionary<Type, List<Type>>();
        private readonly IServiceCollection _registry;
        public EventHandlerExecutionContext(IServiceCollection registry)
        {
            _registry = registry;
        }
        public async Task HandleAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (_registrations.TryGetValue(@event.GetType(), out var handlerTypes) && handlerTypes != null && handlerTypes.Any())
            {
                var sp = _registry.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedsServiceProvider = scope.ServiceProvider;
                    foreach (var handlerType in handlerTypes)
                    {
                        var eventHandler = (IEventHandler)scopedsServiceProvider.GetService(handlerType);
                        if (eventHandler.CanHandle(@event))
                            await eventHandler.HandleEventAsync(@event);
                    }
                }
            }
        }

        public bool HandlerRegistered<TEvent, TEventHandler>()
            where TEvent : IEvent
            where TEventHandler : IEventHandler<TEvent> => HandlerRegistered(typeof(TEvent), typeof(TEventHandler));

        public bool HandlerRegistered(Type eventType, Type handlerType)
            => _registrations.TryGetValue(eventType, out List<Type> handlerTypes) && handlerTypes != null && handlerTypes.Contains(eventType);


        public void RegisterHandler<TEvent, TEventHandler>()
            where TEvent : IEvent
            where TEventHandler : IEventHandler<TEvent> => RegisterHandler(typeof(TEvent), typeof(TEventHandler));

        public void RegisterHandler(Type eventType, Type handlerType)
        {
            if (!_registrations.TryGetValue(eventType, out var handlerTypes))
            {
                _registrations.TryAdd(eventType, new List<Type> { handlerType });
                return;
            }

            if (handlerTypes == null)
            {
                _registrations[eventType] = new List<Type> { handlerType };
                return;
            }

            if (!handlerTypes.Contains(handlerType))
            {
                _registrations[eventType].Add(handlerType);
                _registry.AddTransient(handlerType);
            }
        }
    }
}
