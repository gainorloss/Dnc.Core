using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Files
{
    public interface IDownloader
    {
        Task<string> DownloadRemoteFileAsync(string requestUrlString,
            Func<Stream,string> streamAction);

        Task<string> DownloadRemoteImageAsync(string requestUrlString,
            string folder,
            string fileName = null);
    }
}
