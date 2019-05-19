using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spider
{
    /// <summary>
    /// Constraint for managing proxies.
    /// </summary>
    public interface IAgentPool
    {
        Task<T> GetAgentAsync<T>()
            where T:BaseAgentSpiderItem,new();

        Task<int> ClearAndRefreshAgentPoolAsync<T>() 
            where T : BaseAgentSpiderItem, new();
    }
}
