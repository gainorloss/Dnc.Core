using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class UserLike
        : Entity
    {
        public long UserId { get; set; }
        public long LikedId { get; set; }
        public LikedStatus LikedStatus { get; set; }
        public LikedType LikedType { get; set; }
    }
}
