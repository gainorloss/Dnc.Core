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
            var agentPool = mServiceProvider.GetRequiredService<IAgentPool>();

            var count = await agentPool.ClearAndRefreshAgentPoolAsync<BaseAgentSpiderItem>();
            mOutput.Info($"清空代理池并放入代理{count}个");
        }
    }
}
