using Platender.Front.Helpers;
using Platender.Front.Models.Enums;

namespace Platender.Front.Models
{
    public class User
    {
        public string Username { get; private set; }
        public byte[]? Avatar { get; private set; }
        public UserState UserState { get; private set; }
        public string? Byte64Avatar 
            => Avatar == null ? null : CustomConverter.ConvertToBase64String(Avatar);

        public User()
        {
            
        }

        public User(string? username)
        {
            SetUserName(username);
        }
        
        public User(string? username, UserState? userState)
        {
            SetUserName(username);
            if(userState.HasValue)
            {
                UserState = userState.Value;
            }
        }

        public void SetAvatar(byte[] avatar)
        {
            Avatar = avatar;
        }

        private void SetUserName(string? userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                UserState = UserState.NotAuth;
                return;
            }
            
            Username = userName;
            UserState = UserState.BasicAuth;
        }
    }
}
