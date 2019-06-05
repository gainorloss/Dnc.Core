using Microsoft.Extensions.DependencyInjection;

namespace Dnc
{
    public interface IPluginInitializer:IPlugin
    {
        void ConfigureServices(IServiceCollection services);
    }
}
