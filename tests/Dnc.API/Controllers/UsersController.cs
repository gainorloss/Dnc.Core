using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dnc.API.Models;
using Dnc.API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dnc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        //private readonly IValidator<UserInputVm> _validator;
        private readonly IUserAppService _userAppService;
        public UsersController(
            //IValidator<UserInputVm> validator
            IUserAppService userAppService
            )
        {
            _userAppService = userAppService;
            //_validator = validator;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]UserInputVm value)
        {
           
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
