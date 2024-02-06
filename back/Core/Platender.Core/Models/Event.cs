
namespace Platender.Core.Models
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Longtitude { get; private set; }
        public decimal Latitude { get; private set; }
        public User Creator { get; private set; }
        public IEnumerable<EventParticipators> Participators => _participators;
        private HashSet<EventParticipators> _participators { get; } = new();

        public Event(
            string title,
            string description,
            decimal Longtitude,
            decimal latitude,
            User creator)
        {
            SetTitle(title);
            SetDescription(description);
            SetCoordinates(Longtitude, latitude);
            SetCreator(creator);
        }

        #region Setters
        private void SetTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Event title cannot be null or whitespace");
            }

            if(title.Length > 63)
            {
                throw new ArgumentOutOfRangeException("Event title cannot be longer than 63 chars");
            }

            Title = title;
        }

        private void SetDescription(string description)
        {
            if(description.Length > 255)
            {
                throw new ArgumentOutOfRangeException("Event description cannot be longer than 255 chars");
            }

            Description = description;
        }

        private void SetCoordinates(decimal langtitude, decimal latitude) 
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
        #endregion

        public void AddParticipator(EventParticipators participator)
            => _participators.Add(participator);
        
        public void RemoveParticipator(EventParticipators participator)
        {
            if(_participators.Contains(participator))
            {
                _participators.Remove(participator);
            }
        }


    }
}
