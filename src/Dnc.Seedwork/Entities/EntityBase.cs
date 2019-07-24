using Dnc.Serializers;
using System;

namespace Dnc.Seedwork
{
    [Serializable]
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

        #region 新增：IClone实现 2019-07-24 （张建）.
        public object Clone() => MemberwiseClone();

        public object DeepClone()
        {
            var serializer = Fx.Resolve<IObjectSerializer>();
            return serializer.BytesToObject<object>(serializer.ObjectToBytes(this));
        }

        public object ShallowClone() => Clone();
        #endregion
    }
}
