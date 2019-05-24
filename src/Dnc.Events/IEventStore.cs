using System.Threading.Tasks;

namespace Dnc.Events
{
    public interface IEventStore:IPlugin
    {
        Task SaveAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
