using Dnc.Seedwork;

namespace Dnc.Biz.Users
{
    public class UserLikeStat
        :Entity
    {
        public long LikedId { get; set; }
        public int LikedCount { get; set; }
    }
}
