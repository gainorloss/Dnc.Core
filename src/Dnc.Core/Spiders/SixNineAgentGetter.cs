using Dnc.Spiders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class SixNineAgentGetter
        : IAgentGetter
    {
        #region Private members.
        private readonly IHtmlDownloader _downloader;
        private readonly IHtmlParser _parser;
        #endregion

        #region Default ctor.
        public SixNineAgentGetter(IHtmlDownloader downloader,
            IHtmlParser parser)
        {
            _downloader = downloader;
            _parser = parser;
        }
        #endregion

        #region Methods for getting proxies.
        public async Task<IList<T>> GetProxiesAsync<T>(string url = "http://www.89ip.cn/") where T : BaseAgentSpiderItem, new()
        {
            var html = await _downloader.DownloadHtmlContentAsync(url);
            if (string.IsNullOrEmpty(html))
                return null;

            var trs = await _parser.GetElementsAsync(html, "table tr");
            if (trs == null || trs.Length <= 1)
                return null;

            var proxies = new List<T>();
            for (int i = 1; i < trs.Length; i++)
            {
                var tr = trs[i];

                var tds = tr.QuerySelectorAll("td");

                if (tds == null || tds.Length != 10)
                    continue;

                var host = tds[0].TextContent.Trim();
                var port = tds[1].TextContent.Trim();
                var address = tds[2].TextContent.Trim();
                var verifyTime = tds[4].TextContent.Trim();

                var instance = new T
                {
                    Host = host,
                    Port = Convert.ToInt32(port),
                    Address = address,
                    VerifyTime = Convert.ToDateTime(verifyTime)
                };
                proxies.Add(instance);
            }
            return proxies;
        }

        public async Task<bool> VerifyProxyAsync(string ip)
        {
            var url = $"http://ip.taobao.com/service/getIpInfo2.php?ip={ip}";
            var json = await _downloader.DownloadHtmlContentAsync(url);
            return !string.IsNullOrEmpty(json);
        }
        #endregion
    }
}
