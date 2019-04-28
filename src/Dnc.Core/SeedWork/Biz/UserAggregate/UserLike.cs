using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public class UserLike
        : Entity
    {
        public int UserId { get; set; }
        public int LikedId { get; set; }
        public LikedStatus LikedStatus { get; set; }
        public LikedType LikedType { get; set; }
    }
}
