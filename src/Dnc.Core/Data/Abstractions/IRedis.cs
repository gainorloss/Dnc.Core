using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Data
{
    public interface IRedis
    {
        void Set<T>(string key, T t, int expireMS=20);

        T TryGetOrCreate<T>(string key,
           Func<T> func,int expireMS = 20);

        T TryGetOrCreateDistributely<T>(string key, Func<T> func,int expireMS = 20);

        Task SetAsync<T>(string key, T t, int expireMS = 20);

        Task<T> TryGetOrCreateAsync<T>(string key,
            Func<Task<T>> func,int expireMS = 20);

        Task<T> TryGetOrCreateDistributelyAsync<T>(string key, Func<T> func, int expireMS = 20);
    }
}
