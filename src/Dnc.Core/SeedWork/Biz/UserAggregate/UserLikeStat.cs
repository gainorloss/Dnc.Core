using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class UserLikeStat
        :Entity
    {
        public long LikedId { get; set; }
        public int LikedCount { get; set; }
    }
}
