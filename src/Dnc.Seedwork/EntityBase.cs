using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class EntityBase<TKey>
        : IEntity
    {

        public EntityBase()
        {
            CreateTime = DateTime.Now;
        }
        public TKey Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateRemark { get; set; }
    }
}
