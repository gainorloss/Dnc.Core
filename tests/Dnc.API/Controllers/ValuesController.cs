using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dnc.API.Models;
using Dnc.ObjectId;
using Dnc.SeedWork;
using Dnc.Serializers;
using Microsoft.AspNetCore.Mvc;

namespace Dnc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMockRepository _mockRepository;
        private readonly IObjectIdGenerator _objectIdGenerator;
        private readonly IMessageSerializer _messageSerializer;
        public ValuesController(IMockRepository mockRepository,
            IObjectIdGenerator objectIdGenerator,
            IMessageSerializer messageSerializer)
        {
            _mockRepository = mockRepository;
            _objectIdGenerator = objectIdGenerator;
            _messageSerializer = messageSerializer;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var abc = _mockRepository.Create<ABC>();
            var abcs = _mockRepository.CreateMultiple<ABC>();
            var id = _objectIdGenerator.CombinedGuid();
            return Ok(new { Status=0,Code=200,Msg="请求成功",Data=new { abc, id, abcs } });
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
