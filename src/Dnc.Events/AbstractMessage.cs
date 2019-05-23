using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Events
{
    public abstract class AbstractMessage
        : IMessage
    {
        public AbstractMessage()
        {
            UniqueId = Guid.NewGuid().ToString("N");
            Version = 1;
            Seq = 1;
            Timestamp = DateTime.UtcNow;
        }
        public string UniqueId { get; set; }
        public int Version { get; set; }
        public DateTime Timestamp { get; set; }
        public int Seq { get; set; }
    }
}
