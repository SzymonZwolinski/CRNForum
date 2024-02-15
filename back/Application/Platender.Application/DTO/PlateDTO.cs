
namespace Platender.Application.DTO
{
    public class PlateDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int LikeRatio { get; set; }
        public string Culture { get; set; }

        public PlateDto(
            Guid id,
            string number,
            int likeRatio,
            string culture)
        {
            Id = id;
            Number = number;
            LikeRatio = likeRatio;
            Culture = culture;
        }
    }
}
