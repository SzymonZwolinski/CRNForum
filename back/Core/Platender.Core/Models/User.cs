﻿using Platender.Core.Enums;

namespace Platender.Core.Models
{
	public class User
	{
        public Guid Id { get; private set; }    
        public string Username { get; private set; }
		public byte[] PasswordHash { get; private set; }
		public byte[] PasswordSalt { get; private set; }
        public UserStatus UserStatus { get; private set; }
        public IEnumerable<EventParticipators> Events => _events;
        private List<EventParticipators> _events { get; } = new();
            
        public User(){}

        public User(
            string userName,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
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
    }
}
