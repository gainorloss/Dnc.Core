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
        private static IList<BaseAgentSpiderItem> mAgents = new List<BaseAgentSpiderItem>();
        private static object _lock = new object();
        public async Task<T> GetAgentAsync<T>() where T : BaseAgentSpiderItem, new()
        {
            var random = new Random(DateTime.Now.GetHashCode()).Next(0, mAgents.Count());

            return await Task.FromResult(mAgents.ElementAt(random) as T);
        }

        public async Task ClearAndRefreshAgentPoolAsync<T>(params T[] proxies) where T : BaseAgentSpiderItem, new()
        {
            if (proxies != null && proxies.Any())
            {
                lock (_lock)
                {
                    mAgents.Clear();
                    foreach (var item in proxies)
                    {
                        mAgents.Add(item);
                    }
                }
            }
            await Task.FromResult(true);
        }
    }
}
