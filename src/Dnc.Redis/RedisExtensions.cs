using CSRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dnc.Redis
{
    public static class RedisExtensions
    {
        public static FrameworkConstruction UseRedis(this FrameworkConstruction construction,
            Action<RedisConfigOptions> configRedisOptions = null)
        {
            var options = new RedisConfigOptions();
            if (configRedisOptions != null)
            {
                configRedisOptions(options);
            }
            else
            {
                options = construction.Configuration.Get<RedisConfigOptions>();
            }

            var myConn = $"{options.Host}:{options.Port},password={options.Password},defaultDatabase = 0,poolsize = 10,ssl = false,writeBuffer = 10240,prefix = {options.InstanceName}:";
            var client = new CSRedisClient(myConn);
            construction.Services.AddSingleton(sp => client);
            construction.Services.AddSingleton<IRedis>(sp => new CsRedis(sp.GetRequiredService<CSRedisClient>(), options.AvalanchePreventionSeconds));
            return construction;
        }
    }
}
