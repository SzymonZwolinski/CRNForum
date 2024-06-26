﻿namespace Platender.Core.Models
{
    public class Comment
    {
        public Guid Id { get; private set; }
        public byte[]? Image { get; private set; }
        public string? Description { get; private set; }
        public Plate Plate { get; private set; }
        public User User { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IEnumerable<CommentsLike> CommentLike => _commentLike;
        private List<CommentsLike> _commentLike { get;  set; } = new();
        public bool IsSpott => Image?.Length > 0;

        public Comment(){}

        public Comment(
            User user,
            byte[]? image,
            string? description)
        {
            SetUser(user);
            Image = image; //TODO: LIMIT MAX SIZE / RESIZE TO MAX
            SetDescription(description);
            
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

        private void SetDescription(string? description) 
        {
            if(!IsSpott && (string.IsNullOrWhiteSpace(description) || description.Length > 1023)) 
            {
                throw new ArgumentOutOfRangeException("Description cannot be empty or longer than 255 chars");
            }

            Description = description;
        }
        #endregion

        public void AddLike(CommentsLike spottLike)
            => _commentLike.Add(spottLike);

        public void RemoveLike(CommentsLike spottLike)
            => _commentLike.Remove(spottLike);
    }
}
