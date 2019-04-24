using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Files
{
    public class FileDownloader
        : IDownloader
    {
        public async Task<string> DownloadRemoteFileAsync(string requestUrlString,
            Func<Stream, string> streamAction)
        {
            if (requestUrlString == null)
                throw new ArgumentNullException(nameof(requestUrlString));

            if (streamAction == null)
                throw new ArgumentNullException(nameof(streamAction));

            var req = WebRequest.Create(requestUrlString) as HttpWebRequest;

            using (var res = (await req.GetResponseAsync()) as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var resStream = res.GetResponseStream();

                    return streamAction.Invoke(resStream);
                }
            }
            return null;
        }

        public async Task<string> DownloadRemoteImageAsync(string requestUrlString,
            string folder,
            string fileName = null)
        {
            return await DownloadRemoteFileAsync(requestUrlString, resStream =>
              {
                  if (!Directory.Exists(folder))
                      Directory.CreateDirectory(folder);

                  if (string.IsNullOrEmpty(fileName))
                      fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}{Guid.NewGuid().ToString("N")}.png";

                  var savePath = Path.Combine(folder, fileName);

                  var img = System.Drawing.Image.FromStream(resStream);
                  img.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);

                  return savePath;
              });
        }
    }
}
