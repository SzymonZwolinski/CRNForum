namespace Platender.Front.Dto
{
    public class CommentLikeDto
    {
        public int Count { get; set; }
        public Guid SpottId { get; set; }
        public Guid PlateId { get; set; }
        public string Number { get; set; }
        public string Culture { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
