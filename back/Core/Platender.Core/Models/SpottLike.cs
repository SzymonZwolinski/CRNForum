using Platender.Core.Enums;
using Platender.Core.Models.Abstract;
using System.Net;

namespace Platender.Core.Models
{
    public class SpottLike : Like
    {
        public Spotts Spott { get; private set; }
        public Guid SpottId { get; private set; }

        public SpottLike() {}

        public SpottLike(
            Spotts spott,
            IPAddress iPAddress,
            LikeType likeType)
        {
            Spott = spott;
            UserIPAddress = iPAddress;
            LikeType = likeType;
        }
    }
}
