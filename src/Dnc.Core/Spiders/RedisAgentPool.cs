using Dnc.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class RedisAgentPool
        : IAgentPool
    {
        #region Private memebers.
        private readonly IRedis _redis;
        private readonly IAgentGetter _agentGetter;
        private readonly string mKey = "Spider:redisAgentPool";
        private readonly int mExpireMS = 60 * 60 * 1000;
        #endregion

        #region Default ctor.
        public RedisAgentPool(IRedis redis,
            IAgentGetter agentGetter)
        {
            _redis = redis;
            _agentGetter = agentGetter;
        }
        #endregion

        public async Task ClearAndRefreshAgentPoolAsync<T>(params T[] proxies) where T : BaseAgentSpiderItem, new()
        {
            await _redis.ClearAsync(mKey);

            var rt = await _agentGetter.GetProxiesAsync<T>();
            await _redis.SetAsync(mKey, rt, mExpireMS);
        }

        public async Task<T> GetAgentAsync<T>() where T : BaseAgentSpiderItem, new()
        {
            var mAgents = await _redis.TryGetOrCreateAsync(mKey, async () => await _agentGetter.GetProxiesAsync<T>(), mExpireMS);
            var random = new Random(DateTime.Now.GetHashCode()).Next(0, mAgents.Count);

            return await Task.FromResult(mAgents.ElementAt(random) as T);
        }
    }
}
