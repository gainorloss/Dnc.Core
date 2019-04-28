using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Models
{
    public class AjaxResult
    {
        public AjaxResult()
        { }
        public AjaxResult(bool status,
            StatusCode statusCode,
            string msg)
        {
            Status = status;
            Code = statusCode;
            Msg = msg;
        }
        public bool Status { get; set; }
        public StatusCode Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
        public int Count { get; set; }
    }
}
