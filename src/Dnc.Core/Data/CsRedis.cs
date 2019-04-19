using CSRedis;
using Dnc.Data;
using Dnc.Serializers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Data
{
    /// <summary>
    /// Uses CSRedis to connect redis.
    /// </summary>
    public class CsRedis
        : IRedis
    {
        #region Private memeber.
        private readonly CSRedisClient _client;
        #endregion

        #region Ctor.
        public CsRedis(CSRedisClient client)
        {
            _client = client;
        }
        #endregion

        public T Get<T>(string key) where T : class, new() => _client.Get<T>(key);

        public async Task<T> GetAsync<T>(string key) where T : class, new() => await _client.GetAsync<T>(key);

        public void Set<T>(string key, T t) where T : class, new() => _client.Set(key, t);

        public async Task SetAsync<T>(string key, T t) where T : class, new() => await _client.SetAsync(key, t);

        public T TryGetOrCreate<T>(string key, Func<T> func) where T : class, new()
        {
            var val = _client.Get<T>(key);
            if (val != null)
                return val;

            var rt = func();
            _client.Set(key, rt);
            return rt;
        }

        /// <summary>
        /// Try get value from cache or create into cache async. 
        /// </summary>
        /// <param name="key">key name.</param>
        /// <param name="func">Delegate used to return value.</param>
        /// <returns></returns>
        public async Task<T> TryGetOrCreateAsync<T>(string key,
            Func<Task<T>> func)
            where T : class, new()
        {
            var val = await _client.GetAsync<T>(key);

            if (val != null)
                return val;

            var rt = await func();
            await _client.SetAsync(key, _serializer.SerializeObject(rt));
            return rt;
        }
    }
}
