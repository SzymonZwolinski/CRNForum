using Platender.Core.Enums;

namespace Platender.Core.Models
{
	public class Plate
	{
		public Guid Id { get; private set; }
		public string Number { get; private set; }
		public CultureCode? Culture { get; private set; }
        public IEnumerable<Comment> Comments => _comments;
        private List<Comment> _comments { get; } = new List<Comment>();
		public IEnumerable<PlateLike> PlateLikes => _plateLikes;
		private List<PlateLike> _plateLikes { get; set; } = new();
        public IEnumerable<UserFavouritePlates> UserFavouritePlates => _userFavouritePlates;
        private List<UserFavouritePlates> _userFavouritePlates { get; set; } = new();

        public Plate(){}

        public Plate(string number, CultureCode? culture) 
		{
			SetNumber(number);
			SetCultureCode(culture);
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
		public void AddLike(PlateLike plateLike)
			=> _plateLikes.Add(plateLike);

		public void RemoveLike(PlateLike plateLike)
			=> _plateLikes.Remove(plateLike);

		public void AddSpott(Comment spot)
		{
			if(spot is null)
			{
				throw new ArgumentNullException("Spot cannot be null");
			}

			_comments.Add(spot);
		}

		public void RemoveSpot(Comment spot)
		{
			if(spot is null)
			{
				throw new ArgumentNullException("Spot cannot be null");
			}

			_comments.Remove(spot);
		}
		#endregion
	}
}
