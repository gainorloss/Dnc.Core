using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.WpfApp.Models
{
    [ProtoContract]
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        public Post(string title, string content)
            : this()
        {
            Title = title;
            Content = content;
        }
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
        [ProtoMember(3)]
        public string Content { get; set; }
        [ProtoMember(4)]
        public DateTime CreateTime { get; set; }
    }
}
