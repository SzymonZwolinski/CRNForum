namespace Platender.Core.Models
{
    public class EventUser
    {
        public Event Event { get; set; }
        public Guid EventId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public EventUser()
        {
            
        }

        public EventUser(Event @event)
        {
            Event = @event;
        }
    }
}
