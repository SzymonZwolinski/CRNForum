
using Platender.Core.Enums;

namespace Platender.Application.DTO
{
    public class PlateDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Culture { get; set; }
        public int LikeAmount { get; set; }
        public int DislikeAmount { get; set; }
        public string? UserReaction { get; set; }

        public PlateDto(
            Guid id,
            string number,
            string culture,
            int likeAmount,
            int dislikeAMount,
            LikeType? userReaction)
        {
            Id = id;
            Number = number;
            Culture = culture;
            LikeAmount = likeAmount;
            DislikeAmount = DislikeAmount;
            UserReaction = userReaction.HasValue ? userReaction.ToString() : null;
        }
    }
}
