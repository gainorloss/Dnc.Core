using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dnc.Serializers
{

    /// <summary>
    /// Implement for <see cref="IMessageSerializer"/> using protobuf-net.
    /// </summary>
    public class ProtobufSerializer
         : IMessageSerializer
    {
        public T DeserializeObject<T>(string value)
            where T : class, new()
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(value)))
            {
                var rt = Serializer.Deserialize<T>(ms);
                return rt;
            }
        }

        public string SerializeObject(object value)
        {
            using (var ms=new MemoryStream())
            {
                Serializer.Serialize(ms,value);
                return Encoding.Unicode.GetString(ms.ToArray());
            }
        }
    }
}
