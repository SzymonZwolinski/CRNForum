using Platender.Front.Helpers;

namespace Platender.Front.Dto
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
        public string? Byte64Image => Image == null ? null : CustomConverter.ConvertToBase64String(Image);
    }
}
