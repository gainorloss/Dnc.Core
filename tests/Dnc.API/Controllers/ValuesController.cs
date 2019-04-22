using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dnc.Alarmers;
using Dnc.API.Models;
using Dnc.Data;
using Dnc.ObjectId;
using Dnc.SeedWork;
using Dnc.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dnc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
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
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogDebug("aha");
            var value = _redis.TryGetOrCreate("gainorloss", () => "gainorloss", 20);
            _logger.LogDebug($"redis:{value}");
            Thread.Sleep(3000);
            value = _redis.TryGetOrCreate("gainorloss", () => "gain", 3);
            _logger.LogDebug($"redis:{value}");
            var abc = _mockRepository.Create<ABC>();
            var abcs = _mockRepository.CreateMultiple<ABC>();
            var id = _objectIdGenerator.CombinedGuid();
            _logger.LogDebug($"redis:{value}");
            _logger.LogError(id);
            _alarmer.AlarmAdminUsingWechatAsync($"当前生成CombinedGuid:{id}", "警告");
            return Ok(new { Status = 0, Code = 200, Msg = "请求成功", Data = new { abc, id, abcs } });
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
