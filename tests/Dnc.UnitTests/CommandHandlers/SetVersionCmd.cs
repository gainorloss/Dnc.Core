using Dnc.CQRS;

namespace Dnc.UnitTests
{
    public class SetVersionCmd:ICommand
    {
        public SetVersionCmd(int version)
        {
            Version = version;
        }
        public int Version { get; set; }
    }
}
