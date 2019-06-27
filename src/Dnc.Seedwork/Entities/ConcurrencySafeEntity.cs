/********************************************
  CocurrencySafeEntity:并发实体

  Creator:gainorloss 创建时间:2019-06-27
  Copyright (c) gainorloss Std.
*********************************************/

using Dnc.Seedwork.Abstractions;

namespace Dnc.Seedwork.Entities
{
    public class ConcurrencySafeEntity : SnowflakeEntity, IConcurrencySafe
    {
        public ConcurrencySafeEntity()
        {
            SetVersion();
        }

        protected void SetVersion()
        {
            if (Version <= 0)
                Version = -1;
            Version++;
        }

        public int Version { get; private set; }
    }
}
