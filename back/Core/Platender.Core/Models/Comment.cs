using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Core.Models
{
	public class Comment
	{
		public Guid Id { get; private set; }
		public string Content { get; private set; }
		public string AddingUserName { get; private set; } // W przyszłosic powinien być to idk usera, na ten moment nie robie usera 
		public int Sequence { get; private set; }
		public int LikeCount { get; private set; }
		public int DislikeCount { get; private set; }


        public Comment(
			string content,
			string userName,
			int sequence)
        {
			SetContent(content);
			SetAddingUserName(userName);
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

		private void SetAddingUserName(string addingUserName)
		{
			if(string.IsNullOrWhiteSpace(addingUserName)) 
			{ 
				throw new ArgumentNullException("Username cannot be null or empty");
			}

			if(addingUserName.Length > 31)
			{
				throw new ArgumentOutOfRangeException("UserName cannot be longer than 32 chars");
			}

			AddingUserName = addingUserName;  
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
