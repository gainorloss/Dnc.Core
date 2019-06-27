using System;

namespace Dnc.Seedwork
{
    public class EntityBase<TIdentity>
        : IEntity
    {

        public EntityBase()
        {
            CreatedAt = DateTime.Now;
        }
        public TIdentity Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Creator { get; set; }
    }
}
