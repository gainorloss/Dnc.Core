using System.Threading.Tasks;
using Dnc.Events;

namespace Dnc.UnitTests
{
    public class TimeUpdatedEventHandler
        : IEventHandler<TimeUpdatedEvent>
    {
        public bool CanHandle<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return true;
        }

        public Task HandleAsync(TimeUpdatedEvent @event)
        {
            System.Console.WriteLine(@event.Timestamp);
            return Task.CompletedTask;
        }

        public Task HandleAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            System.Console.WriteLine(@event.Timestamp);
            return Task.CompletedTask;
        }
    }
}
