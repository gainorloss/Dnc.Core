using System.Threading.Tasks;

namespace Dnc.Dispatcher
{
    public interface IDispatcher:IPlugin
    {
        Task StartAsync(string name = "default", string groupName = "default");
        Task RegisterAndStartAsync(string name, string cronExpression, string typeName,  string assemblyName, string groupName = "default");
        Task ShutdownAsync();
    }
}
