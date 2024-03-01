namespace Platender.Application.DTO
{
    public class EventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Longtitude { get; set; }
        public float Latitude { get; set; }
        public DateTime EventAt { get; set; }
        public float TimeZone { get; set; }
        public string Creator { get; set; }
        public int Participators { get; set; }

        public EventDto(
            string title,
            string description,
            float longtitude,
            float latitude,
            DateTime eventAt,
            float timeZone,
            string creator,
            int participators)
        {
            Title = title;
            Description = description;
            Longtitude = longtitude;
            Latitude = latitude;
            EventAt = eventAt;
            TimeZone = timeZone;
            Creator = creator;
            Participators = participators;
        }
    }
}
