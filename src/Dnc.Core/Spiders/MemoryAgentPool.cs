using Dnc.Dispatcher;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class MemoryAgentPool
        : IAgentPool
    {
        #region Private memebers.
        private readonly IAgentGetter _agentGetter;
        private static IList<BaseAgentSpiderItem> mAgents = new List<BaseAgentSpiderItem>();
        private static object _lock = new object();
        #endregion

        #region Default ctor.
        public MemoryAgentPool(IAgentGetter agentGetter)
        {
            _agentGetter = agentGetter;
        }
        #endregion

        public async Task<T> GetAgentAsync<T>() where T : BaseAgentSpiderItem, new()
        {
            var random = new Random(DateTime.Now.GetHashCode()).Next(0, mAgents.Count());

            return await Task.FromResult(mAgents.ElementAt(random) as T);
        }

        public async Task<int> ClearAndRefreshAgentPoolAsync<T>() where T : BaseAgentSpiderItem, new()
        {
            var agents = await _agentGetter.GetProxiesAsync<BaseAgentSpiderItem>();
            agents = agents.Where(a => _agentGetter.VerifyProxyAsync(a.Host).Result).ToList();
            if (agents != null && agents.Any())
            {
                lock (_lock)
                {
                    mAgents.Clear();
                    foreach (var item in agents)
                    {
                        mAgents.Add(item);
                    }
                }
            }
            return agents.Count;
        }
    }
}
