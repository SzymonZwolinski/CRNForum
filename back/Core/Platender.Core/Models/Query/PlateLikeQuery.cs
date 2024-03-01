namespace Platender.Core.Models.Query
{
    public class PlateLikeQuery
    {
        public int Count { get; set; }
        public Guid PlateId { get; set; }
        public string Number { get; set; }
        public string? Culture { get; set; }
    }
}
