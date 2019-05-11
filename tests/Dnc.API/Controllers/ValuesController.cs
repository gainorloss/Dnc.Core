using Dnc.Alarmers;
using Dnc.API.Models;
using Dnc.AspNetCore.Controllers;
using Dnc.Data;
using Dnc.ObjectId;
using Dnc.SeedWork;
using Dnc.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Dnc.API.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]/[action]")]
    public class ValuesController : BaseController
    {
        private readonly IMockRepository _mockRepository;
        private readonly IObjectIdGenerator _objectIdGenerator;
        private readonly IMessageSerializer _messageSerializer;
        private readonly IAlarmer _alarmer;
        private readonly ILogger<ValuesController> _logger;
        private readonly IRedis _redis;
        public ValuesController(IMockRepository mockRepository,
            IObjectIdGenerator objectIdGenerator,
            IMessageSerializer messageSerializer,
            IAlarmer alarmer,
            ILogger<ValuesController> logger,
            IRedis redis)
        {
            _mockRepository = mockRepository;
            _objectIdGenerator = objectIdGenerator;
            _messageSerializer = messageSerializer;
            _alarmer = alarmer;
            _logger = logger;
            _redis = redis;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("aha");
            var value = _redis.TryGetOrCreate("gainorloss", () => "gainorloss", 20);
            _logger.LogDebug($"redis:{value}");
            Thread.Sleep(3000);
            value = _redis.TryGetOrCreate("gainorloss", () => "gain", 3);
            _logger.LogDebug($"redis:{value}");
            var abc = _mockRepository.Create<ABC>();
            var abcs = _mockRepository.CreateMultiple<ABC>();
            var id = _objectIdGenerator.StringCombinedGuid();
            _logger.LogDebug($"redis:{value}");
            _logger.LogError(id);
            _alarmer.AlarmAdminUsingWechatAsync($"当前生成CombinedGuid:{id}", "警告");
            return Ajax(HttpStatusCodes.Ok, new { abc, id, abcs });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
