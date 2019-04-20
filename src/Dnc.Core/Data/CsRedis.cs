using CSRedis;
using Dnc.Data;
using Dnc.Serializers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
        private readonly int _seconds = 30;
        #endregion

        #region Ctor.
        public CsRedis(CSRedisClient client, int seconds)
        {
            _client = client;
            _seconds = seconds;
        }
        #endregion

        #region Sync.
        public void Set<T>(string key, T t, int expireMS) => _client.Set(key, t, RandomExpireMS(expireMS));

        public T TryGetOrCreate<T>(string key, Func<T> func, int expireMS)
        {
            var val = _client.Get<T>(key);
            if (val != null)
                return val;

            var rt = func();
            _client.Set(key, rt, RandomExpireMS(expireMS));
            return rt;
        }

        public T TryGetOrCreateDistributely<T>(string key, Func<T> func, int expireMS)
        {
            var val = _client.Get<T>(key);
            if (val != null)
                return val;

            if (_client.Set("mutex", 1, 60 * 2, RedisExistence.Nx))
            {
                var rt = func();
                _client.Set(key, rt, RandomExpireMS(expireMS));
                _client.Del("mutex");
                return rt;
            }
            else
            {
                Thread.Sleep(50);
                return TryGetOrCreateDistributely(key, func, expireMS);
            }
        }
        #endregion

        #region Async.
        public async Task SetAsync<T>(string key, T t, int expireMS) => await _client.SetAsync(key, t, RandomExpireMS(expireMS));

        /// <summary>
        /// Try get value from cache or create into cache async. 
        /// </summary>
        /// <param name="key">key name.</param>
        /// <param name="func">Delegate used to return value.</param>
        /// <returns></returns>
        public async Task<T> TryGetOrCreateAsync<T>(string key,
            Func<Task<T>> func, int expireMS)
        {
            var val = await _client.GetAsync<T>(key);

            if (val != null)
                return val;

            var rt = await func();
            await _client.SetAsync(key, rt, RandomExpireMS(expireMS));
            return rt;
        }


        public async Task<T> TryGetOrCreateDistributelyAsync<T>(string key, Func<T> func, int expireMS)
        {
            var val = await _client.GetAsync<T>(key);
            if (val != null)
                return val;

            if (await _client.SetAsync($"mutex{key}", 1, 60 * 2, RedisExistence.Nx))
            {
                var rt = func();
                await _client.SetAsync(key, rt, RandomExpireMS(expireMS));
                await _client.DelAsync($"mutex{key}");
                return rt;
            }
            else
            {
                Thread.Sleep(50);
                return await TryGetOrCreateDistributelyAsync(key, func, expireMS);
            }
        }
        #endregion

        #region Helper.
        private int RandomExpireMS(int expireMS)
        {
            return expireMS + new Random().Next(0, _seconds + 1);
        }
        #endregion
    }
}
