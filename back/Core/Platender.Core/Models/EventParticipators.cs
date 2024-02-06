namespace Platender.Core.Models
{
    public class EventParticipators
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }      
        public Event Event { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public EventParticipators(Event @event, User user)
        {
            Event = @event;
            User = user;
        }
    }
}
