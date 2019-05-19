using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spider
{
    public class HttpRequestHtmlDownloader
        : IHtmlDownloader
    {
        public async Task<string> DownloadHtmlContentAsync(string url,string proxy = null)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("message", nameof(url));
            var pageSource = string.Empty;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "*/*";
                request.ServicePoint.Expect100Continue = false;//加快载入速度
                request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
                request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
                request.ContentType = "application/x-www-form-urlencoded";//定义文档类型及编码
                request.AllowAutoRedirect = false;//禁止自动跳转
                                                  //设置User-Agent，伪装成Google Chrome浏览器
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
                request.Timeout = 5000;//定义请求超时时间为5秒
                request.KeepAlive = true;//启用长连接
                request.Method = "GET";//定义请求方式为GET              
                if (proxy != null) request.Proxy = new WebProxy(proxy);//设置代理服务器IP，伪装请求地址
                //request.CookieContainer = this.CookiesContainer;//附加Cookie容器
                request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数

                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {//获取请求响应

                    //foreach (Cookie cookie in response.Cookies) this.CookiesContainer.Add(cookie);//将Cookie加入容器，保存登录状态

                    if (response.ContentEncoding.ToLower().Contains("gzip"))//解压
                    {
                        using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                pageSource = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))//解压
                    {
                        using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                pageSource = reader.ReadToEnd();
                            }

                        }
                    }
                    else
                    {
                        using (Stream stream = response.GetResponseStream())//原始
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {

                                pageSource = reader.ReadToEnd();
                            }
                        }
                    }
                }
                request.Abort();
            }
            catch (Exception ex)
            { 

            }
            return pageSource;
        }
    }
}
