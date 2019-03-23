using Dnc.Serializers;
using Dnc.WpfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.WpfApp.Tests
{
    public class SerializerTest
    {
        private readonly IMessageSerializer _serializer;
        public SerializerTest(IMessageSerializer serializer)
        {
            _serializer = serializer;
        }

        public void Test()
        {
            var post = new Post("IMessageSerizer:同意序列化管理", "如何在三分钟实现一个统一的序列化器");

            var json = _serializer.SerializeObject(post);

            var rt = _serializer.DeserializeObject<Post>(json);
        }
    }
}
