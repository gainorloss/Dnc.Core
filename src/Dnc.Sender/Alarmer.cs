using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Dnc.Sender
{
    public class Alarmer
        : IAlarmer
    {
        private readonly IConfiguration _configuration;
        public Alarmer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> AlarmAdminUsingWechatAsync( string msg,string title="告警")
        {
            var serverChainKey = _configuration.GetValue<string>("ServerChainKey");
            serverChainKey = serverChainKey ?? "SCU48970T598563b88da57b90420a32531fdda7575cb55d7fb3904";

            var requestUri = $"https://sc.ftqq.com/{serverChainKey}.send?text={title}&desp={msg}";
            var res = await requestUri.GetAsync();//using flurl to request;
            return res.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
