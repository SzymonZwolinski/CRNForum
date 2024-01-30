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

        public Comment(){}

        public Comment(
			string content,
			User user,
			int sequence)
        {
			SetContent(content);
			User = user;
			Sequence = sequence;
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
