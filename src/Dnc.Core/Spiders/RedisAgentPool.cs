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
        private readonly int mExpireMS = 5 * 60 * 60 * 1000;
        #endregion

        #region Default ctor.
        public RedisAgentPool(IRedis redis,
            IAgentGetter agentGetter)
        {
            _redis = redis;
            _agentGetter = agentGetter;
        }
        #endregion

        public async Task<int> ClearAndRefreshAgentPoolAsync<T>() where T : BaseAgentSpiderItem, new()
        {
            var agents = await _agentGetter.GetProxiesAsync<BaseAgentSpiderItem>();
            agents = agents.Where(a => _agentGetter.VerifyProxyAsync(a.Host).Result).ToList();

            await _redis.ClearAsync(mKey);
            await _redis.SetAsync(mKey, agents.Take(20), mExpireMS);
            return agents.Count;
        }

        public async Task<T> GetAgentAsync<T>() where T : BaseAgentSpiderItem, new()
        {
            var mAgents = await _redis.TryGetOrCreateAsync(mKey, async () =>
            {
                var agents = await _agentGetter.GetProxiesAsync<BaseAgentSpiderItem>();
                agents = agents.Where(a => _agentGetter.VerifyProxyAsync(a.Host).Result).Take(20).ToList();
                return agents;
            }, mExpireMS);
            var random = new Random(DateTime.Now.GetHashCode()).Next(0, mAgents.Count);

            return await Task.FromResult(mAgents.ElementAt(random) as T);
        }
    }
}
