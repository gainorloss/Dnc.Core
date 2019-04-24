using Dnc.Dispatcher;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class DefaultAgentPoolJob
         : AbstractJob
    {
        public override async Task ExecuteJobAsync(IJobExecutionContext context)
        {
            var agentGetter = mServiceProvider.GetRequiredService<IAgentGetter>();
            var agentPool = mServiceProvider.GetRequiredService<IAgentPool>();

            var agents = await agentGetter.GetProxiesAsync<BaseAgentSpiderItem>();
            agents = agents.Where(a => agentGetter.VerifyProxyAsync(a.Host).Result).ToList();
            await agentPool.ClearAndRefreshAgentPoolAsync(agents.ToArray());
            mOutput.Info($"清空代理池并放入代理{agents.Count}个");
        }
    }
}
