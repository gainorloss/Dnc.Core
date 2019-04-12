using Dnc.Spiders;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<MemoryUrlManager> _logger;
        #endregion

        #region Default ctor.
        public MemoryUrlManager(ILogger<MemoryUrlManager> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Methods for processing urls.
        public void AddNewUrls(params string[] urls)
        {
            foreach (var url in urls)
            {
                if (!string.IsNullOrEmpty(url) && url.StartsWith("http"))
                {
                    NewUrls.Enqueue(url);
                }
            }
            _logger.LogWarning($"//******警告:当前队列待处理项{NewUrls.Count}个。");
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
        #endregion
    }
}
