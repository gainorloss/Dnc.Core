using Dnc.ObjectId;

namespace Dnc.Seedwork
{
    public class CombinedGuidEntity
        :EntityBase<string>
    {
        public CombinedGuidEntity()
        {
            Id = Fx.Resolve<IObjectIdGenerator>().StringCombinedGuid();
        }
    }
}
