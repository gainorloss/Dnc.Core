using Dnc.ObjectId;

namespace Dnc.Seedwork
{
    public class SnowflakeEntity
        :EntityBase<long>
    {
        public SnowflakeEntity()
        {
            Id = Fx.Resolve<IObjectIdGenerator>().IntSnowflakeId();
        }
    }
}
