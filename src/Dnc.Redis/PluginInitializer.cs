using CSRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dnc.Redis
{
    public class PluginInitializer
        : IPluginInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = Fx.Construction.Configuration;

            var options = new RedisOptions();
            configuration.GetSection(nameof(RedisOptions)).Bind(options);

            var myConn = $"{options.Host}:{options.Port},password={options.Password},defaultDatabase = 0,poolsize = 10,ssl = false,writeBuffer = 10240,prefix = {options.InstanceName}:";
            var client = new CSRedisClient(myConn);
            services.AddSingleton(sp => client);
            services.AddSingleton<IRedis>(sp => new CsRedis(sp.GetRequiredService<CSRedisClient>(), options.AvalanchePreventionSeconds));
        }
    }
}
