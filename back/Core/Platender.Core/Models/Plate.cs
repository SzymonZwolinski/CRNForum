using Platender.Core.Enums;

namespace Platender.Core.Models
{
	public class Plate
	{
		//Plate jest to "produkt" który może posiadać opis + komenatrze
		public Guid Id { get; private set; }
		public string Number { get; private set; }
		public int LikeRatio { get; private set; }
		public CultureCode? Culture { get; private set; }
		public IEnumerable<Comment> Comments => _comments;
		private List<Comment> _comments { get; } = new List<Comment>();

        public Plate(){}

        public Plate(string number, CultureCode? culture) 
		{
			SetNumber(number);
			SetCultureCode(culture);
			LikeRatio = 0;
		}

		#region Setters
		private void SetNumber(string number)
		{
			if(string.IsNullOrWhiteSpace(number))
			{
				throw new ArgumentNullException("Plate number cannot be null or whitespace");
			}

			if(number.Length < 5 || number.Length > 7)
			{
				throw new ArgumentOutOfRangeException("Plate number cannot be less than 5 chars and longer than 7 chars");
			}

			Number = number;
		}

		private void SetCultureCode(CultureCode? culture) 
		{
			Culture = culture;
		}

		#endregion

		#region GettersAndControlMethods
		public void AddToLikeRatio()
		{
			LikeRatio++;
		}

		public void SubtractFromLikeRatio()
		{
			LikeRatio--;
		}

		public void AddComment(Comment comment)
		{
			_comments.Add(comment);
		}

		public void RemoveComment(Guid ComentId) 
		{
			var commentToDelete = _comments.FirstOrDefault(x => x.Id == ComentId);

			if(commentToDelete is not null)
			{
				_comments.Remove(commentToDelete);
			}
		}

		public void LikeComment(Guid ComentId)
		{
			if (_comments.Any(x => x.Id == ComentId))
			{
				_comments.First(x => x.Id == ComentId).AddLike();
			}
		}

		public void DislikeComment(Guid ComentId)
		{
			if (_comments.Any(x => x.Id == ComentId))
			{
				_comments.First(x => x.Id == ComentId).AddDislike();
			}
		}

		public void UnLikeComment(Guid ComentId)
		{
			if (_comments.Any(x => x.Id == ComentId))
			{
				_comments.First(x => x.Id == ComentId).RemoveLike();
			}
		}

		public void UnDislikeComment(Guid ComentId)
		{
			if (_comments.Any(x => x.Id == ComentId))
			{
				_comments.First(x => x.Id == ComentId).RemoveDislike();
			}
		}
		#endregion
	}
}
