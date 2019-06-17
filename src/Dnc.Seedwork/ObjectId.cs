using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public abstract class ObjectId<TId>
    {
        public ObjectId(TId id)
        {
            Id = id;
        }
        public TId Id { get; set; }
    }
    public class ObjectId : ObjectId<long>
    {
        public ObjectId(long id)
            : base(id)
        { }
    }
}
