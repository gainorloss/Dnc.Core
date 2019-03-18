using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dnc.Web
{
    /// <summary>
    /// Used for web requests.
    /// </summary>
    public static class WebRequests
    {
        public static async Task<HttpWebResponse> PostAsync(string url,
            object content = null,
            KnownContentSerializers accept = KnownContentSerializers.Json,
            KnownContentSerializers returnType = KnownContentSerializers.Json)
        {
            var req = WebRequest.CreateHttp(url);

            req.Method = HttpMethod.Post.ToString();
            req.Accept = accept.ToMimeString();
            req.ContentType = returnType.ToMimeString();

            if (content == null)
            {
                req.ContentLength = 0;
            }
            else
            {
                var contentString = string.Empty;
                if (accept == KnownContentSerializers.Json)
                {
                    contentString = JsonConvert.SerializeObject(content);
                }
                else if (accept == KnownContentSerializers.Xml)
                {
                    var xmlSerializer = new XmlSerializer(content.GetType());
                    using (var sw = new StringWriter())
                    {
                        xmlSerializer.Serialize(sw, content);
                        contentString = sw.ToString();
                    }
                }
                else
                {
                    //TODO:other type.
                }

                using (var stream = await req.GetRequestStreamAsync())
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        await sw.WriteAsync(contentString);
                    }
                }
            }

            return (HttpWebResponse)await req.GetResponseAsync();
        }
    }
}
