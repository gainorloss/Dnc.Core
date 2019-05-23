using Dnc.ObjectId;

namespace Dnc.Seedwork
{
    public class GuidEntity
        :EntityBase<string>
    {
        public GuidEntity()
        {
            Id = Fx.Resolve<IObjectIdGenerator>().StringCombinedGuid();
        }
    }
}
