
namespace Platender.Core.Models
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public float Longtitude { get; private set; }
        public float Latitude { get; private set; }
        public DateTime EventAt { get; private set; }
        public float TimeZone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public User Creator { get; private set; }
        public ICollection<EventUser> Participators { get; set; } = new HashSet<EventUser>();


        public Event()
        {

        }

        public Event(
            string title,
            string description,
            float Longtitude,
            float latitude,
            DateTime eventAt,
            float timezone,
            User creator)
        {
            SetTitle(title);
            SetDescription(description);
            SetCoordinates(Longtitude, latitude);
            SetCreator(creator);
            SetEventAt(eventAt);
            SetTimeZone(timezone);

            CreatedAt = DateTime.UtcNow;
        }

        #region Setters
        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Event title cannot be null or whitespace");
            }

            if (title.Length > 63)
            {
                throw new ArgumentOutOfRangeException("Event title cannot be longer than 63 chars");
            }

            Title = title;
        }

        private void SetDescription(string description)
        {
            if (description.Length > 255)
            {
                throw new ArgumentOutOfRangeException("Event description cannot be longer than 255 chars");
            }

            Description = description;
        }

        private void SetCoordinates(float langtitude, float latitude)
        {
            Longtitude = langtitude;
            Latitude = latitude;
        }

        private void SetCreator(User creator)
        {
            if (creator is null)
            {
                throw new ArgumentNullException("Event creator cannot be null");
            }

            Creator = creator;
        }

        private void SetEventAt(DateTime eventAt)
        {
            if ((eventAt < DateTime.UtcNow) || ((eventAt - DateTime.UtcNow).TotalDays > 6 * 30))
            {
                throw new ArgumentOutOfRangeException("Event cannot be created for date less than today or more than 6 months ahead");
            }
            EventAt = eventAt;
        }

        private void SetTimeZone(float timeZone)
        {
            if(timeZone > 14 || timeZone < -12)
            {
                throw new ArgumentOutOfRangeException("Timezone cannot be more than 14 and less than -12");
            }

            TimeZone = timeZone;
        }
        #endregion

        public void AddParticipator(User participator)
            => Participators.Add(new EventUser(this));
        
        public void RemoveParticipator(User participator)
        {
            /*if(Participators.Any(x => x.UserId == participator))
            {
                var participatorToRemove = Participators
                    .FirstOrDefault(x => x.User == participator);

                Participators.Remove(participatorToRemove);
            }*/
        }


    }
}
