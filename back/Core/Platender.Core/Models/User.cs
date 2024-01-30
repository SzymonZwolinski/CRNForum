using Platender.Core.Enums;

namespace Platender.Core.Models
{
	public class User
	{
        public Guid Id { get; set; }    
        public string Username { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
        public UserStatus userStatus { get; set; }

        public User(){}

        public User(
            string userName,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            SetUserName(userName);
            
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            userStatus = UserStatus.New;
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
    }
}
