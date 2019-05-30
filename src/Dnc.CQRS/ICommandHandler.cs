using Dnc.Aspects;
using System.Threading.Tasks;

namespace Dnc.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        [MiniProfilerInterceptor]
        Task HandleAsync(TCommand command);
    }
}
