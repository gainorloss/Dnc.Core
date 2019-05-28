using System.Threading.Tasks;

namespace Dnc.CQRS
{
    public interface ICommandBus : IPlugin
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
