using System.Threading.Tasks;

namespace Dnc.Dispatcher
{
    public interface IDispatcher:IPlugin
    {
        Task RunScheduleAsync(string name = "default", string groupName = "default");
        Task CreateAndRunScheduleAsync(string name, string cronExpression, string typeName,  string assemblyName, string groupName = "default");
        Task ShutdownAsync();
    }
}
