using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Models
{
    public class ResponseBase
    {
        /// <summary>
        ///Tag the request is success or failed <see cref="StatusCode"/>.
        /// </summary>
        public StatusCode Status { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public object Data { get; set; }
    }
}
