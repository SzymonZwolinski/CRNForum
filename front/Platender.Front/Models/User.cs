using Platender.Front.Services;

namespace Platender.Front.Models
{
    public class User
    {
        public string Username { get; private set; }
        public UserState UserState { get; private set; }

        public User()
        {
            
        }

        public User(string? username)
        {
            SetUserName(username);
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
