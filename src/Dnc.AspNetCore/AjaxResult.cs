using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore
{
    public class AjaxResult
    {
        public AjaxResult()
        { }
        public AjaxResult(bool status,
            HttpStatusCodes statusCode,
            string msg)
        {
            Status = status;
            Code = statusCode;
            Msg = msg;
        }
        public bool Status { get; set; }
        public HttpStatusCodes Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
        public int Count { get; set; }

    }
}
