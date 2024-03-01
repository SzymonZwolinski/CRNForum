using Platender.Core.Enums;
using System.Net;

namespace Platender.Core.Models.Abstract
{
    public abstract class Like
    {
        public Guid Id { get; protected set; }
        public IPAddress UserIPAddress { get; protected set; }
        public LikeType LikeType { get; protected set; }

        public void ChangeLikeType()
        {
            if(LikeType is LikeType.Lik)
            {
                LikeType = LikeType.Dis;
                return;
            }

            if(LikeType is LikeType.Dis)
            {
                LikeType = LikeType.Dis;
                return;
            }
        }
    }
}
