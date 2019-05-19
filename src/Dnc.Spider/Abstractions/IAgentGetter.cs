using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spider
{
    /// <summary>
    /// Proxy agent getter.
    /// </summary>
    public interface IAgentGetter
    {
        Task<IList<T>> GetProxiesAsync<T>(string url= "https://www.xicidaili.com/nn/")
            where T: BaseAgentSpiderItem,new();

        Task<bool> VerifyProxyAsync(string ip);
    }
}
