using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DncAspNetCore.Admin.Infrastructure
{
    public class LayUIOutput
    {
        private LayUIOutput()
        { }

        public LayUIOutput(int code,string msg=null,object data=null,int count=0)
        {
            SetCode(code);
            SetMessage(msg);
            SetOutputData(data);
            SetOutputDataCount(count);
        }

        private void SetOutputDataCount(int count)
        {
            Count = count;
        }

        private void SetOutputData(object data)
        {
            Data = data;
        }

        private void SetMessage(string msg)
        {
            Msg = msg;
        }

        private void SetCode(int code)
        {
            Code = code;
        }

        public object Data { get; private set; }
        public int Count { get; private set; }
        public int Code { get; private set; }
        public string Msg { get; private set; }
    }
}
