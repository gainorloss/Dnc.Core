using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Serializers
{
    /// <summary>
    /// The interface for message serializer.
    /// </summary>
    public interface IMessageSerializer
        :IPlugin
    {
        string SerializeObject(object value);

        T DeserializeObject<T>(string value)
            where T:class,new();
    }
}
