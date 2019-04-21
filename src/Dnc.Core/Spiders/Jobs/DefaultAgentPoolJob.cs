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
            var agentGetter = ServiceProvider.GetRequiredService<IAgentGetter>();
            var agentPool = ServiceProvider.GetRequiredService<IAgentPool>();

            var agents = await agentGetter.GetProxiesAsync<BaseAgentSpiderItem>();
            await agentPool.ClearAndRefreshAgentPoolAsync(agents.ToArray());
        }
    }
}
