namespace Platender.Core.Models.Query
{
    public class SpottLikeQuery
    {
        public int Count { get; set; }
        public Guid CommentId { get; set; }
        public Guid PlateId { get; set; }
        public string Number { get;set; }
        public string? Culture { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
