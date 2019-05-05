using Dnc.AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dnc.AspNetCore.Controllers
{
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Ajax(HttpStatusCodes statusCode,
            object data = null,
            string msg = null)
        {
            var ajaxResult = new AjaxResult()
            {
                Status = statusCode == HttpStatusCodes.Ok,
                Code = statusCode,
                Msg = msg,
                Data = data
            };

            switch (statusCode)
            {
                case HttpStatusCodes.Ok:
                    return Ok(ajaxResult);
                case HttpStatusCodes.Unauthorized:
                    return Unauthorized(ajaxResult);
                case HttpStatusCodes.NotFound:
                    return NotFound(ajaxResult);
                case HttpStatusCodes.BadRequest:
                    return BadRequest(ajaxResult);
                default:
                    return Ok(ajaxResult);
            }
        }
    }
}
