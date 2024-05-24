using Platender.Front.Models;

namespace Platender.Front.State
{
    public class AccountState
    {
        public event Action OnChange;

        private bool _isChangePasswordSent;
        public bool IsChangePasswordSent
        {
            get => _isChangePasswordSent;
            set
            {
                _isChangePasswordSent = value;
                NotifyStateChanged();
            }
        }

        private bool _isLoginSuccesful;
        public bool IsLoginSuccesful
        {
            get => _isLoginSuccesful;
            set
            {
                _isLoginSuccesful = value;
                NotifyStateChanged();
            }
        }

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                _isLoginSuccesful = true;
                NotifyStateChanged();
            }
        }

        public void UpdateAvatar(byte[] avatar)
        {
            _currentUser.SetAvatar(avatar);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
