using Platender.Front.Models.Enums;

namespace Platender.Front.DTO
{
    public class CommentDto
    {
        public Guid PlateId { get; set; }
        public string Content { get; set; }
    }
}
