using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Data
{
    public interface IRedis
    {
        void Set<T>(string key, T t, int expireMS = 20);

        void Clear(string key);

        T TryGetOrCreate<T>(string key,
           Func<T> func, int expireMS = 20);

        T TryGetOrCreateDistributely<T>(string key, Func<T> func, int expireMS = 20);

        long Like<T>(object id, string desc, params T[] likedMembers);

        long Count<T>(object id, string desc, long increment=1);

        long Rank<T>(string desc, params Ranking<T>[] rankings);

        Task SetAsync<T>(string key, T t, int expireMS = 20);

        Task ClearAsync(string key);

        Task<T> TryGetOrCreateAsync<T>(string key,
            Func<Task<T>> func, int expireMS = 20);

        Task<T> TryGetOrCreateDistributelyAsync<T>(string key, Func<T> func, int expireMS = 20);
    }
}
