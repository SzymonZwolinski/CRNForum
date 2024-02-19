using Platender.Core.Enums;
using System.Net;

namespace Platender.Core.Models
{
    public class Likes
    {
        public Guid Id { get; private set; }
        public IPAddress UserAddress { get; private set; }
        public Guid TypeId { get; private set; }
        public LikeType LikeKind { get; private set; }
        public AssociatedLikeType AssociatedLikeType { get; private set; }

        public Likes(){}

        public Likes(
            IPAddress ipAddress,
            Guid typeId,
            LikeType likeKind,
            AssociatedLikeType associatedLikeType)
        {
            SetUserAddress(ipAddress);
            TypeId = typeId;
            LikeKind = likeKind;
            AssociatedLikeType = associatedLikeType;
        }

        private void SetUserAddress( IPAddress ipAddress ) 
        {
            if(ipAddress is null)
            {
                throw new ArgumentNullException("IPAddress should not be null or empty");
            }

            UserAddress = ipAddress;
        }
    }
}
