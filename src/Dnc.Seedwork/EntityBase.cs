using System;

namespace Dnc.Seedwork
{
    public class EntityBase<TKey>
        : IEntity
    {

        public EntityBase()
        {
            CreatedAt = DateTime.Now;
        }
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Creator { get; set; }
    }
}
