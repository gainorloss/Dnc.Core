namespace Dnc.Serializers
{
    /// <summary>
    /// The interface for message serializer.
    /// </summary>
    public interface IObjectSerializer
        : IPlugin
    {
        string SerializeObject(object value);

        T DeserializeObject<T>(string value) where T : class, new();

        byte[] ObjectToBytes(object obj);

        T BytesToObject<T>(byte[] Bytes) where T : class, new();
    }
}
