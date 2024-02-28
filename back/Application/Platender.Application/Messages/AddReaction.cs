using Platender.Core.Enums;
using System.Net;

namespace Platender.Application.Messages
{
    public class AddReaction
    {
        public Guid PlateId {  get; set; } 
        public Guid SpottId { get; set; } 
        public LikeType LikeType { get; set; }
        
        public AddReaction(
            Guid plateId,
            LikeType likeType)
        {
            PlateId = plateId;
            LikeType = likeType;
        }

        public AddReaction(
            Guid plateId,
            Guid spottId,
            LikeType likeType)
        {
            PlateId = plateId;
            SpottId = spottId;
            LikeType = likeType;
        }
    }
}
