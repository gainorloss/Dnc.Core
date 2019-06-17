using Dnc.ObjectId;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class RepositoryBase
        : IRepository
    {
        private readonly IObjectIdGenerator _objectIdGenerator;
        public RepositoryBase()
        {
            _objectIdGenerator = Fx.Resolve<IObjectIdGenerator>();
        }
        public long NextIdentity() => _objectIdGenerator.IntSnowflakeId();
    }
}
