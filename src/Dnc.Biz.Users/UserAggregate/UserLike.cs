using Dnc.Seedwork;

namespace Dnc.Biz.Users
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
