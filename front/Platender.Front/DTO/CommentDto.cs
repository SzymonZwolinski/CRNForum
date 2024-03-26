namespace Platender.Front.DTO
{
    public class CommentDto
    {
        public Guid PlateId { get; set; }
        public byte[]? Image { get; set; }
        public string Description { get; set; }
    }
}
