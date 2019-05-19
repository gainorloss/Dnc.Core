using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Dnc.Spider
{
    public class HttpRequestHtmlDownloader
        : IHtmlDownloader
    {
        public async Task<string> DownloadHtmlContentAsync(string url,string agent = null)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("message", nameof(url));
            try
            {
                //创建一个请求
                HttpWebRequest httprequst = (HttpWebRequest)WebRequest.Create(url);
                //不建立持久性链接
                httprequst.KeepAlive = true;
                //设置请求的方法
                httprequst.Method = "GET";
                //设置标头值
                httprequst.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
                httprequst.Accept = "*/*";
                httprequst.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                httprequst.ServicePoint.Expect100Continue = false;
                httprequst.Timeout = 5000;
                httprequst.AllowAutoRedirect = true;//是否允许302
                if (!string.IsNullOrWhiteSpace(agent)) httprequst.Proxy = new WebProxy(agent);
                ServicePointManager.DefaultConnectionLimit = 30;
                //获取响应
                HttpWebResponse webRes = (HttpWebResponse)await httprequst.GetResponseAsync();
                //获取响应的文本流
                string content = string.Empty;
                using (System.IO.Stream stream = webRes.GetResponseStream())
                {
                    using (System.IO.StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8")))
                    {
                        content = reader.ReadToEnd();
                    }
                }
                //取消请求
                httprequst.Abort();
                //返回数据内容
                return content;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
