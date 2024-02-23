using Platender.Core.Enums;
using Platender.Core.Models.Abstract;
using System.Net;

namespace Platender.Core.Models
{
    public class PlateLike : Like
    {
        public Plate Plate { get; private set; }
        public Guid PlateId { get; private set; }

        public PlateLike() {}

        public PlateLike(
            Plate plate,
            IPAddress iPAddress,
            LikeType likeType)
        {
            Plate = plate;
            UserIPAddress = iPAddress;
            LikeType = likeType; 
        }
    }
}
