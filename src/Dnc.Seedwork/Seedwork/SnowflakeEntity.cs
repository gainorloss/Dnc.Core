using Dnc.ObjectId;
using Dnc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Core.Seedwork
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
