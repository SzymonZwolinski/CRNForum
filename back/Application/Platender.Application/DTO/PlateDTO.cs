
namespace Platender.Application.DTO
{
    public class PlateDTO
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int LikeRatio { get; set; }
        public string Culture { get; set; }
        public IEnumerable<CommentDTO>? Comments { get; set; }

        public PlateDTO(
            Guid id,
            string number,
            int likeRatio,
            string culture,
            IEnumerable<CommentDTO> comments)
        {
            Id = id;
            Number = number;
            LikeRatio = likeRatio;
            Culture = culture;
        }
    }
}
