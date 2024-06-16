using Platender.Application.DTO;
using Platender.Core.Enums;
using Platender.Core.Models;
using System.Net;

namespace Platender.Application.Mapper
{
    public static class PlateMapperExtension
    {
        public static PlateDto MapToPlateDto(this Plate plate, IPAddress userIp)
            => new PlateDto(
                plate.Id,
                plate.Number,
                plate.Culture.ToString(),
                plate.PlateLikes.Count(x => x.LikeType == LikeType.Lik),
                plate.PlateLikes.Count(x => x.LikeType == LikeType.Dis),
                plate.PlateLikes.FirstOrDefault(x => x.UserIPAddress.Equals(userIp))?.LikeType);

        public static PlateDto MapToPlateDto(this Plate plate)
            => new PlateDto(
                plate.Id,
                plate.Number,
                plate.Culture.ToString(),
                plate.PlateLikes.Count(x => x.LikeType == LikeType.Lik),
                plate.PlateLikes.Count(x => x.LikeType == LikeType.Dis));
    }
}
