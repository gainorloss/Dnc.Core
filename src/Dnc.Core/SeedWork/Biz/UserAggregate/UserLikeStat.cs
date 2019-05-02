using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public class UserLikeStat
        :Entity
    {
        public int LikedId { get; set; }
        public int LikedCount { get; set; }
    }
}
