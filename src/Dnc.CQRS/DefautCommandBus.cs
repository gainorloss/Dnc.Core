using System.Threading.Tasks;

namespace Dnc.CQRS
{
    public class DefautCommandBus : ICommandBus
    {
        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = Fx.Resolve<ICommandHandler<TCommand>>();
            if (handler != null)
                await handler.HandleAsync(command);
        }
    }
}
