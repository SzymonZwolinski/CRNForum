
namespace Platender.Core.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<(decimal X, decimal Y)> Coordinates { get; set; }
        public User Creator { get; set; }
        public IEnumerable<User> Participators => _participators;
        private HashSet<User> _participators { get; } = new HashSet<User>();

        public Event(
            string title,
            string description,
            decimal x,
            decimal y,
            User creator)
        {
            SetTitle(title);
            SetDescription(description);
            SetCoordinates(x, y);
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
                throw new ArgumentOutOfRangeException("Event title cannot be longer than 64 chars");
            }

            Title = title;
        }

        private void SetDescription(string description)
        {
            if(description.Length > 255)
            {
                throw new ArgumentOutOfRangeException("Event description cannot be longer than 256 chars");
            }

            Description = description;
        }

        private void SetCoordinates(decimal x, decimal y) 
        {
            Coordinates.Add((x, y));
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
    }
}
