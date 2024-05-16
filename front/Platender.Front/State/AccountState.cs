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

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
