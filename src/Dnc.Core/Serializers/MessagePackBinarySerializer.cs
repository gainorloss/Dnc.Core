using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Serializers
{
    /// <summary>
    /// Implement for <see cref="IMessageSerializer"/> using messagepack;
    /// </summary>
    public class MessagePackBinarySerializer
        : IMessageSerializer
    {
        #region Static ctor.
        static MessagePackBinarySerializer()
        {
            // 全局设置无约束解析器为默认解析器
            MessagePackSerializer.SetDefaultResolver(MessagePack.Resolvers.ContractlessStandardResolver.Instance);
        }
        #endregion

        #region Deserialze.
        public T DeserializeObject<T>(string value) where T : class, new()
        {
            var json = MessagePackSerializer.FromJson(value);

            return MessagePackSerializer.Deserialize<T>(json);
        }
        #endregion

        #region Serialize.
        public string SerializeObject(object value)
        {
            //var bytes = MessagePackSerializer.Serialize(value);

            return MessagePackSerializer.ToJson(value);
        }
        #endregion
    }
}
