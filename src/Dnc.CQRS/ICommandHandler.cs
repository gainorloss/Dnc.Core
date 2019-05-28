using System.Threading.Tasks;

namespace Dnc.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
