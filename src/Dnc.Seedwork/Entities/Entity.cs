using Dnc.ObjectId;

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
