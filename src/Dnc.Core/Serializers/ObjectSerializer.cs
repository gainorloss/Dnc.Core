using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dnc.Serializers
{
    /// <summary>
    /// Implement for <see cref="IObjectSerializer"/> using json.net;
    /// </summary>
    public class ObjectSerializer
        : IObjectSerializer
    {
        public T DeserializeObject<T>(string value)
           where T : class, new()
        {
            var rt = JsonConvert.DeserializeObject<T>(value);
            return rt;
        }

        public string SerializeObject(object value)
        {
            var json = JsonConvert.SerializeObject(value);
            return json;
        }

        /// <summary> 
        /// 将一个object对象序列化，返回一个byte[]         
        /// </summary> 
        /// <param name="obj">能序列化的对象</param>         
        /// <returns></returns> 
        public byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        /// <summary> 
        /// 将一个序列化后的byte[]数组还原         
        /// </summary>
        /// <param name="Bytes"></param>         
        /// <returns></returns> 
        public T BytesToObject<T>(byte[] Bytes) where T : class, new()
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                IFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
