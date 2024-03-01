namespace Platender.Core.Models
{
	public class Comment
	{
		public Guid Id { get; private set; }
		public Plate Plate { get; private set; }
		public string Content { get; private set; }
		public User User { get; private set; } 
		public int Sequence { get; private set; }
		public int LikeCount { get; private set; }
		public int DislikeCount { get; private set; }
		public DateTime CreatedAt { get; private set; }

        public Comment(){}

        public Comment(
			string content,
			User user,
			int sequence)
        {
			SetContent(content);
			SetUser(user);
			Sequence = sequence;
			CreatedAt = DateTime.UtcNow;
			LikeCount = 0;
			DislikeCount = 0;
		}

		#region Setters
		private void SetContent(string content)
		{
			if(string.IsNullOrWhiteSpace(content))
			{
				throw new ArgumentNullException("Comment content cannot be null or empty");
			}

			if(content.Length > 1023)
			{
				throw new ArgumentOutOfRangeException("Comment cannot be longer than 1024 chars");
			}

			Content = content;
		}

		private void SetUser(User user)
		{
			if(user is null)
			{
				throw new ArgumentNullException("User cannot be null");
			}

			User = user;
		}

		#endregion
		#region GettersAndControlMethods
		public void AddLike()
		{
			LikeCount++;
		}

		public void RemoveLike()
		{
			LikeCount--;
		}

		public void AddDislike() 
		{
			DislikeCount++;
		}

		public void RemoveDislike()
		{
			DislikeCount--; 
		}
		#endregion
	}
}
