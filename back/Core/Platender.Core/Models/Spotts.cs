namespace Platender.Core.Models
{
    public class Spotts
    {
        public Guid Id { get; private set; }
        public byte[] Image { get; private set; }
        public string Description { get; private set; }
        public Plate Plate { get; private set; }
        public User User { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IEnumerable<SpottLike> SpottLikes => _spottLikes;
        private List<SpottLike> _spottLikes { get;  set; } = new();

        public Spotts(){}

        public Spotts(
            User user,
            byte[] image,
            string description)
        {
            SetUser(user);
            SetDescription(description);
            Image = image; //TODO: LIMIT MAX SIZE / RESIZE TO MAX
            CreatedAt = DateTime.UtcNow;
        }

        #region setters
        private void SetUser(User user)
        {
            if(user is null) 
            {
                throw new ArgumentNullException("User cannot be null");
            }

            User = user;
        }

        private void SetDescription(string description) 
        {
            if(description.Length > 255) 
            {
                throw new ArgumentOutOfRangeException("Description cannot be longer than 255 chars");
            }

            Description = description;
        }
        #endregion

        public void AddLike(SpottLike spottLike)
            => _spottLikes.Add(spottLike);

        public void RemoveLike(SpottLike spottLike)
            => _spottLikes.Remove(spottLike);
    }
}
