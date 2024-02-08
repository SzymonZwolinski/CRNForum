namespace Platender.Front.Dto
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
    }
}
