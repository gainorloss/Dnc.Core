using System.Threading.Tasks;

namespace Dnc.Events
{
    public interface IEventHandler
    {
        bool CanHandle<TEvent>(TEvent @event) where TEvent:IEvent;
        Task HandleEventAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
    public interface IEventHandler<TEvent>: IEventHandler
        where TEvent:IEvent
    {
        Task HandleEventAsync(TEvent @event);
    }
}
