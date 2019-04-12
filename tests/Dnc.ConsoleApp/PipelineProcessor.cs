using Dnc.Spiders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dnc.ConsoleApp
{
    public class PipelineProcessor
          : IPipelineProcessor
    {
        private readonly ILogger<PipelineProcessor> _logger;
        public PipelineProcessor(ILogger<PipelineProcessor> logger)
        {
            _logger = logger;
        }
        private readonly IList<string> _urls = new List<string>();
        public Task ProcessItemAsync(string url,string html)
        {
            _urls.Add(url);
            _logger.LogInformation($"//******正在处理{url},当前队列{_urls.Count}个。");
            return Task.CompletedTask;
        }
    }
}
