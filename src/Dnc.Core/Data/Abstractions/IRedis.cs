using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Data
{
    public interface IRedis
    {
        T Get<T>(string key)
           where T : class, new();

        void Set<T>(string key, T t)
            where T : class, new();

        Task<T> GetAsync<T>(string key)
           where T : class, new();

        Task SetAsync<T>(string key, T t)
            where T : class, new();

        Task<T> TryGetOrCreateAsync<T>(string key,
            Func<Task<T>> func)
            where T : class, new();

        T TryGetOrCreate<T>(string key,
           Func<T> func)
           where T : class, new();
    }
}
