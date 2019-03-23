using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Serializers
{
    /// <summary>
    /// Implement for <see cref="IMessageSerializer"/> using json.net;
    /// </summary>
    public class NewtonsoftJsonSerializer
        : IMessageSerializer
    {
        public T DeserializeObject<T>(string value)
           where T:class,new()
        {
            var rt = JsonConvert.DeserializeObject<T>(value);
            return rt;
        }

        public string SerializeObject(object value)
        {
            var json = JsonConvert.SerializeObject(value);
            return json;
        }
    }
}
