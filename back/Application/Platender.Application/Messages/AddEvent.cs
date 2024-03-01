namespace Platender.Application.Messages
{
    public class AddEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Longtitude { get; set; }
        public float Latitude { get; set; }
        public DateTime EventAt { get; set; }
        public float TimeZone { get; set; }
    }
}
