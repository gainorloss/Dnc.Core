using Dnc.Alarmers;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.CircuitBreaker;
using Polly.Fallback;
using System;
using System.Threading.Tasks;

namespace Dnc.FaultToleranceProcessors
{
    public class PollyFaultToleranceProcessor
        : IFaultToleranceProcessor
    {
        #region Private members.
        private readonly ILogger<PollyFaultToleranceProcessor> _logger;
        private readonly IAlarmer _alarmer;
        #endregion

        #region Default ctor.
        public PollyFaultToleranceProcessor(ILogger<PollyFaultToleranceProcessor> logger,
            IAlarmer alarmer)
        {
            _logger = logger;
            _alarmer = alarmer;
        }
        #endregion

        #region Methods for process exception.
        public async Task RetryAsync(Func<Task> action, int retryCount)
        {
            var retryPolicy = Policy.Handle<Exception>()
                 .RetryAsync(retryCount, (ex, retry) =>
                 {
                     _logger.LogWarning($"正在进行第{retry}次重试;当前异常：{ex.Message}");
                 });

            var wrapPolicy = Policy.WrapAsync(BuildFallbackPolicy(), retryPolicy, BuildCircuitBreakerPolicy(retryCount));

            await wrapPolicy.ExecuteAsync(action);
        }

        public async Task WaitAndRetryAsync(Func<Task> action, int intervalStep, int retryCount)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            if (intervalStep < 1)
                throw new ArgumentException($"{nameof(intervalStep)} should greater than or equal 1");

            var fallbackPolicy = BuildFallbackPolicy();

            var waitAndRetryPolicy = Policy.Handle<Exception>()
                    .WaitAndRetryAsync(retryCount, retry =>
                    {
                        var intervalSeconds = (intervalStep * retry) - 1;
                        _logger.LogWarning($"正在进行第{retry}次重试！下一次重试将在{(intervalStep * (retry + 1)) - 1}s后");
                        return TimeSpan.FromSeconds(intervalSeconds);
                    });

            var wrapPolicy = Policy.WrapAsync(BuildFallbackPolicy(), waitAndRetryPolicy, BuildCircuitBreakerPolicy(retryCount));

            await wrapPolicy.ExecuteAsync(action);
        }
        #endregion

        #region Helpers.
        private AsyncFallbackPolicy BuildFallbackPolicy()
        {
            return Policy.Handle<Exception>()
                .FallbackAsync(async ct =>
                {
                   await _alarmer.AlarmAdminUsingWechatAsync("最终执行失败","fallback");
                    _logger.LogError($"最终执行失败");
                });
        }

        private AsyncCircuitBreakerPolicy BuildCircuitBreakerPolicy(int retryCount)
        {
            return Policy.Handle<Exception>()
                  .CircuitBreakerAsync(retryCount - 1, TimeSpan.FromSeconds(10),
                  async (ex, ts) => await Task.Run(() => _logger.LogWarning($"正在执行短路保护，将在{ts.TotalSeconds}s后继续重试")),
                  () => { });
        }
        #endregion
    }
}
