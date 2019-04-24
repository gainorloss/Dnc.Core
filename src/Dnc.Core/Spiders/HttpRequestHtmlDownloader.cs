using PuppeteerSharp;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class HttpRequestHtmlDownloader
        : IHtmlDownloader
    {
        public async Task<string> DownloadHtmlContentAsync(string url,
            Func<Page, Task> beforeGetContentHandler = null,
            string agent = null)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;//模拟请求
                request.Timeout = 30 * 1000;//设置30s的超时
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                request.ContentType = "text/html; charset=utf-8";// "text/html;charset=gbk";// 
                //request.Host = "host";
                //request.Headers.Add("Cookie", cookie);

                //request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                //request.Headers.Add("Referer", "http://list.yhd.com/c0-0/b/a-s1-v0-p1-price-d0-f0-m1-rt0-pid-mid0-kiphone/");

                //Encoding enc = Encoding.GetEncoding("GB2312"); //如果是乱码就改成 utf-8 / GB2312

                using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)//发起请求
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        return null;
                    try
                    {
                        StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        html = sr.ReadToEnd();//读取数据
                        sr.Close();
                    }
                    catch (Exception ex)
                    {
                        html = null;
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Equals("远程服务器返回错误: (306)。"))
                    return null;
            }
            catch (Exception ex)
            {
                html = null;
            }
            return html;
        }
    }
}
