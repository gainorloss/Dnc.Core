using Dnc.Spiders;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Spiders
{
    public class MemoryUrlManager
        : IUrlManager
    {
        #region Private memebers.
        private static IList<string> OldUrls = new List<string>();
        private static ConcurrentQueue<string> NewUrls = new ConcurrentQueue<string>();
        #endregion

        public void AddNewUrls(params string[] urls)
        {
            foreach (var url in urls)
            {
                NewUrls.Enqueue(url);
            }
        }

        public string GetNewUrl()
        {
            if (HasNewUrl())
            {
                if (NewUrls.TryDequeue(out var newUrl))
                    OldUrls.Add(newUrl);
                    return newUrl;
            }
            return null;
        }

        public bool HasNewUrl()
        {
            return !NewUrls.IsEmpty;
        }
    }
}
