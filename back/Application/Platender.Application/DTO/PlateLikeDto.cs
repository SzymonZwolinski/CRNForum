namespace Platender.Application.DTO
{
    public class PlateLikeDto
    {
        public int Count { get; set; }
        public Guid PlateId { get; set; }
        public string Numbers { get; set; }
        public string? Culture { get; set; }

        public PlateLikeDto(
            int count,
            Guid plateId, 
            string numbers,
            string? culture)
        {
            Count = count;
            PlateId = plateId;
            Numbers = numbers;
            Culture = culture;
        }
    }
}
