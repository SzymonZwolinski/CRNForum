using Platender.Core.Enums;

namespace Platender.Core.Models
{
	public class User
	{
        public Guid Id { get; private set; }    
        public string Username { get; private set; }
		public byte[] PasswordHash { get; private set; }
		public byte[] PasswordSalt { get; private set; }
        public byte[]? Avatar { get; private set; }
        public UserStatus UserStatus { get; private set; }
        public ICollection<EventUser> EventUsers { get; private set; }
        public IEnumerable<UserFavouritePlates> favouritePlates => _favouritePlates;
        private List<UserFavouritePlates> _favouritePlates { get; set; } = new();
        public User(){}

        public User(
            string userName,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            Id = Guid.NewGuid();
            SetUserName(userName);
            
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            UserStatus = UserStatus.New;
        }

        private void SetUserName(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("username cannot be null or whitepace");
            }

            if(userName.Length > 31)
            {
                throw new ArgumentOutOfRangeException("Username cannot be longer than 32 chars");
            }

            Username = userName;
        }

        public void ChangePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public void SetAvatar(byte[] avatar) 
        {
            Avatar = avatar;
        }

        public void AddFavouritePlate(Plate plate)
        {
            if(plate is null)
            {
                throw new ArgumentNullException($"FavouritePlate could not be null for user:{Username}");
            }

            if (!_favouritePlates.Any(x => x.Plate.Id == plate.Id))
            {
                _favouritePlates.Add(new UserFavouritePlates(plate));
            }
        }

        public void RemoveFavouritePlate(Plate plate)
        {
            if (plate is null)
            {
                throw new ArgumentNullException($"FavouritePlate could not be null for user:{Username}");
            }

            if (_favouritePlates.Any(x => x.Plate.Id == plate.Id))
            {
                var favouritePlate = _favouritePlates.Any(x => x.Plate.Id == plate.Id);
                _favouritePlates.Remove(favouritePlate);
            }
        }
    }
}
