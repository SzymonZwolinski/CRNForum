namespace Platender.Application.Messages
{
    public class AddEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Longtitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime EventAt { get; set; }
        public decimal TimeZone { get; set; }
    }
}
