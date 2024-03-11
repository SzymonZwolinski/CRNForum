namespace Platender.Application.DTO
{
    public class CommentLikeDto
    {
        public int Count { get; set; }
        public Guid CommentId { get; set; }
        public Guid PlateId { get; set; }
        public string Number { get; set; }
        public string Culture { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public CommentLikeDto(
            int count, 
            Guid commentId,
            Guid plateId, 
            string number,
            string culture,
            byte[] image,
            string description)
        {
            Count = count;
			CommentId = commentId;
			PlateId = plateId;
            Number = number;
            Culture = culture;
            Image = image;
            Description = description;
        }
    }
}
