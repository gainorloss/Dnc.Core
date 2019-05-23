using Dnc.ObjectId;
using System;

namespace Dnc.Seedwork
{
    public class Entity
        : EntityBase<long>
    {
        public Entity()
        {
            Id = Fx.Resolve<IObjectIdGenerator>().IntGuid();
        }
    }
}
