using System.Threading.Tasks;
using Dnc.CQRS;

namespace Dnc.UnitTests
{
    public class SetVersionCmdHandler : ICommandHandler<SetVersionCmd>
    {
        public Task HandleAsync(SetVersionCmd command)
        {
            var @version = command.Version;
            return Task.CompletedTask;
        }
    }
}
